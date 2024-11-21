var abp = abp || {};
(function () {

    // Check if SignalR is defined
    if (!signalR) {
        return;
    }

    // Create namespaces
    abp.signalr = abp.signalr || {};
    abp.signalr.hubs = abp.signalr.hubs || {};
    abp.signalr.reconnectTime = abp.signalr.reconnectTime || 5000;
    abp.signalr.maxTries = abp.signalr.maxTries || 8;
    abp.signalr.increaseReconnectTime = abp.signalr.increaseReconnectTime || function (time) {
        return time * 2;
    };
    abp.signalr.withUrlOptions = abp.signalr.withUrlOptions || {};

    // Configure the connection for abp.signalr.hubs.common
    function configureConnection(connection) {
        // Set the common hub
        abp.signalr.hubs.common = connection;

        let reconnectTime = abp.signalr.reconnectTime;

        // Register to get notifications
        connection.on('getNotification', function (notification) {
            abp.event.trigger('abp.notifications.received', notification);
        });
    }

    // Connect to the server for abp.signalr.hubs.common
    function connect() {
        var url = abp.signalr.url || (abp.appPath + 'signalr');

        // Start the connection
        startConnection(url, configureConnection)
            .then(function (connection) {
                abp.log.debug('Connected to SignalR server!'); //TODO: Remove log
                abp.event.trigger('abp.signalr.connected');
                // Call the Register method on the hub
                connection.invoke('register').then(function () {
                    abp.log.debug('Registered to the SignalR server!'); //TODO: Remove log
                });
            })
            .catch(function (error) {
                abp.log.debug(error.message);
            });
    }

    // Starts a connection with transport fallback - if the connection cannot be started using
    // the webSockets transport the function will fallback to the serverSentEvents transport and
    // if this does not work it will try longPolling. If the connection cannot be started using
    // any of the available transports the function will return a rejected Promise.
    function startConnection(url, configureConnection) {
        if (abp.signalr.remoteServiceBaseUrl) {
            url = abp.signalr.remoteServiceBaseUrl + url;
        }

        // Add query string: https://github.com/aspnet/SignalR/issues/680
        if (abp.signalr.qs) {
            url += (url.indexOf('?') == -1 ? '?' : '&') + abp.signalr.qs;
        }

        return function start(transport) {
            abp.log.debug('Starting connection using ' + signalR.HttpTransportType[transport] + ' transport');
            abp.signalr.withUrlOptions.transport = transport;
            var connection = new signalR.HubConnectionBuilder()
                .withAutomaticReconnect({
                    nextRetryDelayInMilliseconds: retryContext => {
                        abp.log.debug('Retry to connect to SignalR');
                        if (retryContext.previousRetryCount > maxTries) {
                            abp.log.debug('Max retries reached');
                            return null;
                        }
                        reconnectTime *= 2;
                        abp.log.debug('Waiting ' + reconnectTime + 'ms before retrying');
                        return reconnectTime;
                    }
                })
                .withUrl(url, abp.signalr.withUrlOptions)
                .build();

            if (configureConnection && typeof configureConnection === 'function') {
                configureConnection(connection);
            }

            return connection.start()
                .then(function () {
                    return connection;
                })
                .catch(function (error) {
                    abp.log.debug('Cannot start the connection using ' + signalR.HttpTransportType[transport] + ' transport. ' + error.message);
                    if (transport !== signalR.HttpTransportType.LongPolling) {
                        return start(transport + 1);
                    }

                    return Promise.reject(error);
                });
        }(signalR.HttpTransportType.WebSockets);
    }

    abp.signalr.autoConnect = abp.signalr.autoConnect === undefined ? true : abp.signalr.autoConnect;
    abp.signalr.autoReconnect = abp.signalr.autoReconnect === undefined ? true : abp.signalr.autoReconnect;
    abp.signalr.connect = abp.signalr.connect || connect;
    abp.signalr.startConnection = abp.signalr.startConnection || startConnection;

    if (abp.signalr.autoConnect && !abp.signalr.hubs.common) {
        abp.signalr.connect();
    }
})();

(function ($) {

    $(function() {
        var _$productList = $('#ProductList');

        $('#GetProductsButton')
            .click(function (e) {
                e.preventDefault();

                abp.services.app.product.getAllProducts()
                    .done(function (result) {
                        _$productList.empty();
                        for (var i = 0; i < result.items.length; i++) {
                            var product = result.items[i];

                            $('<li>')
                                .attr('data-id', product.id)
                                .attr('data-category-id', product.categoryId)
                                .html(product.name + " - " + product.price)
                                .appendTo(_$productList);
                        }
                    });
            });
    });

})(jQuery);
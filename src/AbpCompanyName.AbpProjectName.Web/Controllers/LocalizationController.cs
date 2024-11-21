using Abp;
using Abp.AspNetCore.Mvc.Controllers;
using Abp.AspNetCore.Mvc.Extensions;
using Abp.Auditing;
using Abp.Extensions;
using Abp.Timing;
using Abp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Linq;
using IUrlHelper = Abp.Web.Http.IUrlHelper;

namespace AbpCompanyName.AbpProjectName.Web.Controllers
{
    public class LocalizationController : AbpController
    {
        private readonly IUrlHelper _urlHelper;

        public LocalizationController(IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
        }

        [DisableAuditing]
        public virtual ActionResult ChangeCulture(string cultureName, string returnUrl = "")
        {
            if (!IsValidCultureCode(cultureName))
            {
                throw new AbpException("Unknown language: " + cultureName + ". It must be a valid culture!");
            }

            var cookieValue = CookieRequestCultureProvider.MakeCookieValue(
                new RequestCulture(cultureName, cultureName)
            );

            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                cookieValue,
                new CookieOptions
                {
                    Expires = Clock.Now.AddYears(2),
                    HttpOnly = true
                }
            );

            if (Request.IsAjaxRequest())
            {
                return Json(new AjaxResponse());
            }

            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                return LocalRedirect("/");
            }

            var escapedReturnUrl = Uri.EscapeDataString(returnUrl);
            var localPath = _urlHelper.LocalPathAndQuery(escapedReturnUrl, Request.Host.Host, Request.Host.Port);
            if (!string.IsNullOrWhiteSpace(localPath))
            {
                var unescapedLocalPath = Uri.UnescapeDataString(localPath);
                if (Url.IsLocalUrl(unescapedLocalPath))
                {
                    return LocalRedirect(unescapedLocalPath);
                }
            }

            return LocalRedirect("/");
        }

        private static bool IsValidCultureCode(string cultureCode)
        {
            if (cultureCode.IsNullOrWhiteSpace())
            {
                return false;
            }

            try
            {
                return CultureInfo.GetCultures(CultureTypes.AllCultures)
                    .Any(e => e.Name.ToLowerInvariant() == cultureCode.ToLowerInvariant());
            }
            catch (CultureNotFoundException)
            {
                return false;
            }
        }
    }
}
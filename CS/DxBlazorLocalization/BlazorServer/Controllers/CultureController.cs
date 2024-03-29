using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Localization;

namespace BlazorServer.Controllers {
    [Route("[controller]/[action]")]
    public class CultureController : Controller {
        public IActionResult Set(string culture, string redirectUri) {
            if (culture != null) {
                HttpContext.Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(
                        new RequestCulture(culture, culture)));
            }
            return LocalRedirect(redirectUri);
        }
    }
}

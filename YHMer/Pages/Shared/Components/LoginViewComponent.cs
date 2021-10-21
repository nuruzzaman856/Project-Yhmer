using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YHmer.Pages.Shared.Components
{
    public class LoginViewComponent : ViewComponent
    {
        private readonly IHttpContextAccessor _HttpContextAccessor;

        public LoginViewComponent(IHttpContextAccessor HttpContextAccessor)
        {
            _HttpContextAccessor = HttpContextAccessor;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (_HttpContextAccessor.HttpContext.Session.GetString("_Token") != null)
            {
                return View("SignedIn");
            }
            return View("SignedOut");
        }
    }
}

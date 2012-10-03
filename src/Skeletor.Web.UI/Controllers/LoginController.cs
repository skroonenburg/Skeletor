using System;
using System.Web.Mvc;
using AppHarbor.Web.Security;
using Skeletor.Web.UI.ViewModels;

namespace Skeletor.Web.UI.Controllers
{

    public class User 
    {
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
    }


    public class LoginController : Controller
    {

        private readonly IAuthenticator _authenticator;

        public LoginController(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
        }

        [HttpGet]
        public ActionResult Index(string returnUrl)
        {
            return View(new LoginViewModel{ ReturnUrl = returnUrl });
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            User user = null;
            if (ModelState.IsValid)
            {
                //user = _repository.GetAll<User>().SingleOrDefault(x => x.Username == sessionViewModel.Username);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, string.Format("Unable to locate user '{0}'", loginViewModel.Username));
                }
            }

            if (ModelState.IsValid)
            {
                if (!BCrypt.Net.BCrypt.Verify(loginViewModel.Password, user.Password))
                {
                    ModelState.AddModelError(string.Empty, "Computer says no.");
                }
            }

            if (ModelState.IsValid)
            {
                _authenticator.SetCookie(user.Username);
                var returnUrl = loginViewModel.ReturnUrl;
                if (returnUrl != null)
                {
                    Uri returnUri;
                    if (Uri.TryCreate(returnUrl, UriKind.Relative, out returnUri))
                    {
                        return Redirect(loginViewModel.ReturnUrl);
                    }
                }

                return RedirectToAction("Index", "Home");
            }

            return View("Index", loginViewModel);
        }

        [HttpPost]
        public ActionResult Destroy()
        {
            _authenticator.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

    }
}

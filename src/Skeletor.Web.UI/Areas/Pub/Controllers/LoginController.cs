using System;
using System.Web.Mvc;
using AppHarbor.Web.Security;
using Skeletor.Core.Security;
using Skeletor.Web.UI.Pub.ViewModels;

namespace Skeletor.Web.UI.Areas.Pub.Controllers
{

    public class LoginController : Controller
    {
      private readonly IAuthenticator authenticator;

        public LoginController(IAuthenticator authenticator)
        {
            this.authenticator = authenticator;
        }

        [HttpGet]
        public ActionResult Index(string returnUrl)
        {
            return View(new LoginViewModel{ ReturnUrl = returnUrl });
        }

        [HttpGet]
        [ActionName("Sign-Up")]
        public ActionResult SignUp()
        {
            return View();
        }


        [HttpPost]
        [ActionName("Sign-In")]
        public ActionResult SignIn(LoginViewModel loginViewModel)
        {
            User user = null;
            if (ModelState.IsValid)
            {
                //user = _repository.GetAll<User>().SingleOrDefault(x => x.Username == sessionViewModel.Username);
                ModelState.AddModelError(string.Empty, string.Format("Unable to locate user '{0}'", loginViewModel.Username));
            }

            if (ModelState.IsValid)
            {
                if (!BCrypt.Net.BCrypt.Verify(loginViewModel.Password, user.Password.Text))
                {
                    ModelState.AddModelError(string.Empty, "Computer says no.");
                }
            }

            if (ModelState.IsValid)
            {
                authenticator.SetCookie(user.Username.Name);
                var returnUrl = loginViewModel.ReturnUrl;
                if (returnUrl != null)
                {
                    Uri returnUri;
                    if (Uri.TryCreate(returnUrl, UriKind.Relative, out returnUri))
                        return Redirect(loginViewModel.ReturnUrl);
                }

                return RedirectToAction("Index", "Home");
            }

            return View("Index", loginViewModel);
        }

        [HttpPost]
        public ActionResult Destroy()
        {
            authenticator.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

    }
}

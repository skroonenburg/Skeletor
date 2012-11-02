using System;
using System.Web.Mvc;
using Skeletor.Core.Security;
using Skeletor.Web.UI.Areas.Installation.ViewModels;

namespace Skeletor.Web.UI.Areas.Installation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICreateAdminUserAccountCommandHandler _handler;

        public HomeController(ICreateAdminUserAccountCommandHandler handler)
        {
            _handler = handler;
        }

        public ActionResult Index()
        {
            return View(new AdminAccountViewModel());
        }

        [HttpPost]
        public ActionResult CreateAdminAccount(AdminAccountViewModel viewModel)
        {

            if (!ModelState.IsValid)
                return View("Index", viewModel);


            _handler.Handle(new CreateAdminUserAccountCommand(viewModel.Username, viewModel.FirstName,
                                                              viewModel.LastName, viewModel.Email, viewModel.Password));



            return View("Complete");
        }


        public ActionResult Complete()
        {
            return View();
        }

    }
}

using HAHotel.Areas.Base;
using HAHotel.Helpers;
using HAHotel.Models;
using HAHotel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HAHotel.Areas.Admin.Controllers
{
    [Authorize]
    public class LoginController : BaseController
    {
        private readonly IAccountRepository _accountRepository;

        public LoginController(IAccountRepository accountRepository)
        {
            this._accountRepository = accountRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            SetPageTitle("Đăng nhập");
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Create(string username, string password)
        {
            _accountRepository.CreateAccount(new Account
            {
                UserName = username,
                Password = AccountUtils.HashPassword(password)
            });
            return RedirectToAction("Index");
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(Account account)
        {
            if (!ModelState.IsValid)
            {
                SetPageTitle("Đăng nhập");

                return View("~/Areas/Admin/Views/Login/Index.cshtml");
            }

            var validateResult = _accountRepository.Validate(account);
            if (validateResult == null)
            {
                SetFailedNotification("Tên đăng nhập hoặc mật khẩu không chính xác");

                return RedirectToAction("Index");
            }
            SetAccountSession(validateResult);

            return Redirect(Url.Action("Index", "Home", new { Area = "Admin" }));
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Logout()
        {
            HttpContext.Session[Constants.AccountSessionKey] = string.Empty;

            return RedirectToAction("Index");
        }
    }
}
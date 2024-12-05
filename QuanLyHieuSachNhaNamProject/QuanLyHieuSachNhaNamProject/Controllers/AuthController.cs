﻿using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class AuthController : BaseController
    {
        public AuthController(INotyfService notyfService, IHttpContextAccessor httpContextAccessor, ILogger<BaseController> logger, IMapper mapper) : base(notyfService, httpContextAccessor, logger, mapper)
        {
        }

        [HttpGet]
        public IActionResult Login()
        {
            //if (Request.Cookies.ContainsKey(UserConstant.AccessToken))
            //{
            //    string role = Request.Cookies[UserConstant.Role];
            //    if (!string.IsNullOrEmpty(role) && role == ((int)TypeUserConstant.Role.ADMIN).ToString())
            //    {
            //        return RedirectToAction("Index", "Dashboard");
            //    }
            //}
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Login(Login model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await ApiClient.PostAsync<LoginResponse>(Request, "Auth/Login", JsonConvert.SerializeObject(model));
        //        if (result.Success)
        //        {
        //            if (result.Data.User.IsAdmin == true)
        //            {
        //                LoginSuccess(result.Data);
        //                this._notyfService.Success("Đăng nhập thành công!");
        //                return RedirectToAction("Index", "Dashboard");
        //            }
        //        }
        //        else
        //        {
        //            this._notyfService.Error("Sai tên đăng nhập hoặc mật khẩu");
        //        }
        //    }
        //    else
        //    {
        //        var errors = ModelState.Values.SelectMany(v => v.Errors);
        //        foreach (var error in errors)
        //        {
        //            this._notyfService.Error(error.ErrorMessage);
        //        }
        //    }
        //    return View(model);
        //}

        //public void LoginSuccess(TblTaikhoan model)
        //{
        //    ApiClient.SetCookie(Response, UserConstant.AccessToken, loginRes.AccessToken);
        //    ApiClient.SetCookie(Response, UserConstant.Role, loginRes.User?.IsAdmin == true ? "1" : "0");
        //    ApiClient.SetCookie(Response, UserConstant.UserId, loginRes.User.Id.ToString() ?? "");
        //    ApiClient.SetCookie(Response, UserConstant.AccountName, loginRes.User.Email);
        //}
    }
}

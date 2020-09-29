using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Umbraco.Web.Mvc;
using UmbracoInlUppg1.Models;

namespace UmbracoInlUppg1.Controllers
{
    public class MemberController : SurfaceController
    {
        public ActionResult RenderLogin()

        {

            return PartialView("_Login", new LoginViewModel());

        }



        [HttpPost]

        [ValidateAntiForgeryToken]

        public ActionResult SubmitLogin(LoginViewModel model, string returnUrl)

        {

            if (ModelState.IsValid)

            {

                if (Membership.ValidateUser(model.Username, model.Password))

                {

                    FormsAuthentication.SetAuthCookie(model.Username, false);

                    //UrlHelper myHelper = new UrlHelper(HttpContext.Request.RequestContext);

                    //if (myHelper.IsLocalUrl(returnUrl))

                    //{

                    // return Redirect(returnUrl);

                    //}

                    //else

                    //{

                    // return Redirect("/login/");

                    //}

                    return Redirect("/");

                }

                else

                {

                    ModelState.AddModelError("", "The username or password provided is incorrect");

                }

            }

            return CurrentUmbracoPage();

        }



        public ActionResult RenderLogout()

        {

            return PartialView("_Logout", null);

        }



        public ActionResult SubmitLogout()

        {

            TempData.Clear();

            Session.Clear();

            FormsAuthentication.SignOut();

            return RedirectToCurrentUmbracoPage();

        }
    }
}
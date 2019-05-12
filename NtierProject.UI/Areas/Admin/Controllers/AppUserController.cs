using NtierProject.Model.Option;
using NtierProject.Service.Option;
using NtierProject.UI.Areas.Admin.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NtierProject.UI.Areas.Admin.Controllers
{
    public class AppUserController : Controller
    {
        // GET: Admin/AppUser
        AppUserService _appUserService;
        public AppUserController()
        {
            _appUserService = new AppUserService();
        }
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(AppUser data)
        {
            if (ModelState.IsValid)
            {
                data.Status = Core.Enum.Status.Active;

                _appUserService.Add(data);

                return Redirect("/Admin/AppUser/List");
            }
            else
            {
                return View();
            }
        }
        public ActionResult List()
        {
            List<AppUser> model = _appUserService.GetActive();
            return View(model);
        }
        public RedirectResult Delete(Guid id)
        {
            _appUserService.Remove(id);
            return Redirect("/Admin/AppUser/List");
        }
        public ActionResult Update(Guid id)
        {

            AppUser user = _appUserService.GetByID(id);

            UsersDTO model = new UsersDTO();

            model.ID = user.ID;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.UserName = user.UserName;
            model.Email = user.Email;
            model.Address = user.Address;
            model.PhoneNumber = user.PhoneNumber;
            model.Password = user.Password;
            model.Role = user.Role;

            return View(model);

        }
        [HttpPost]
        public ActionResult Update(UsersDTO data)
        {
            AppUser update = _appUserService.GetByID(data.ID);

            

            update.FirstName = data.FirstName;
            update.LastName = data.LastName;
            update.UserName = data.UserName;
            update.Email = data.Email;
            update.Address = data.Address;
            update.Password = data.Password;
            update.PhoneNumber = data.PhoneNumber;
            update.DateTime = data.Datetime;
            update.Role = data.Role;

            _appUserService.Update(update);

            return Redirect("/Admin/AppUser/List");


        }
    }
}
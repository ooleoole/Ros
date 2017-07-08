using Domain.Entities;
using Domain.Interfaces.Entities;
using Domain.Services.AggregatRoots.UserServices;
using Ros.Mapping.Mappers;
using Ros.WebApplication.Models.ViewModels.UserViewModels;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Ros.WebApplication.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                using (var userService = new UserService())
                {
                    var foundUser = userService.EagerDisconnectedService.FindByInclude(
                        x => x.Id == id.Value && x.Active, a => a.Address, p => p.PhoneNumber);
                    if (!foundUser.Any())
                        throw new Exception("No users found.");
                    var user = foundUser.First();
                    var IdetailsViewModel = ModelMapper.MappFrom(user);
                    var detailsViewModel = new UserDetailsViewModel(IdetailsViewModel);
                    return View(detailsViewModel);
                }
            }
            catch (Exception e)
            {
                TempData["ResultMessage"] = e.Message;
                return View("Error");
            }
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserCreateEditViewModel userCreateViewModel)
        {
            try
            {
                userCreateViewModel.Address.Type = "Home";
                userCreateViewModel.PhoneNumber.Type = "Mobile";
                var user = DTOMapper.MappFrom((IUser)userCreateViewModel);
                user.Active = true;
                using (UserService userService = new UserService())
                {
                    userService.EagerDisconnectedService.Add(user, null);
                }
                return RedirectToAction("LoginSession", "LoginSession");
            }
            catch (Exception e)
            {
                TempData["ResultMessage"] = e.Message;
                return View("Error");
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }
            try
            {
                using (var userService = new UserService())
                {
                    var foundUser = userService.EagerDisconnectedService.FindByInclude(
                        x => x.Id == id.Value && x.Active, a => a.Address, p => p.PhoneNumber);
                    if (!foundUser.Any())
                        throw new Exception("No users found.");
                    var userToEdit = foundUser.First();
                    var editViewModel = ModelMapper.MappFrom(userToEdit);
                    var arne = new UserCreateEditViewModel(editViewModel);
                    return View(arne);
                }
            }
            catch (Exception e)
            {
                TempData["ResultMessage"] = e.Message;
                return View("Error");
            }
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(UserCreateEditViewModel createEditViewModel)
        {
            try
            {
                using (var userService = new UserService())
                {
                    if (createEditViewModel == null)
                    {
                        throw new NullReferenceException();
                    }
                    createEditViewModel.Address.Id = createEditViewModel.AddressId;
                    createEditViewModel.PhoneNumber.Id = createEditViewModel.PhoneNumberId;
                    var convertedViewModel = DTOMapper.MappFrom((IUser)createEditViewModel);
                    userService.EagerDisconnectedService.Update(Session[convertedViewModel.Id] as UserDTO, convertedViewModel);
                }

                return RedirectToAction("LoginSession", "LoginSession");
            }
            catch (Exception e)
            {
                TempData["ResultMessage"] = e.Message;
                return View("Error");
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                using (var userService = new UserService())
                {
                    var foundUser = userService.EagerDisconnectedService.FindByInclude(
                        x => x.Id == id.Value && x.Active, a => a.Address, p => p.PhoneNumber);
                    if (!foundUser.Any())
                        throw new Exception("No users found.");
                    var user = foundUser.First();
                    var IdeleteViewModel = ModelMapper.MappFrom(user);
                    var deleteViewModel = new UserDeleteViewModel(IdeleteViewModel);
                    return View(deleteViewModel);
                }
            }
            catch (Exception e)
            {
                TempData["ResultMessage"] = e.Message;
                return View("Error");
            }
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, UserDeleteViewModel userDeleteViewModel)
        {
            try
            {
                using (var userService = new UserService())
                {
                    if (userDeleteViewModel == null)
                    {
                        throw new NullReferenceException();
                    }
                    userDeleteViewModel.AddressId = userService.EagerDisconnectedService.FindBy(u => u.Id == id).First().AddressId;
                    userDeleteViewModel.Address.Id = userDeleteViewModel.AddressId;
                    userDeleteViewModel.PhoneNumber.Id = userService.EagerDisconnectedService.FindBy(u => u.Id == id).First().PhoneNumberId;
                    userDeleteViewModel.PhoneNumber.Id = userDeleteViewModel.PhoneNumberId;
                    var convertedViewModel = DTOMapper.MappFrom((IUser)userDeleteViewModel);

                    userService.EagerDisconnectedService.Delete(Session[convertedViewModel.Id] as UserDTO, convertedViewModel);
                }

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["ResultMessage"] = e.Message;
                return View("Error");
            }
        }

        public ActionResult Navigations()
        {
            return View();
        }
    }
}
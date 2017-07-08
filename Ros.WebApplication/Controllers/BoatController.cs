using AutoMapper;
using Domain.Entities;
using Domain.Services.BoatServices;
using Ros.WebApplication.Models.ViewModels.BoatViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Domain.Services.AggregatRoots.UserServices;

namespace Ros.WebApplication.Controllers
{
    public class BoatController : Controller
    {
        public ActionResult Index()
        {
            var boatList = new List<BoatIndexViewModel>();
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BoatDTO, BoatIndexViewModel>();
            });

            using (var boatService = new BoatService())
            {
                try
                {
                    var allBoatsDto = boatService.EagerDisconnectedService.GetAll();
                    if (allBoatsDto == null)
                    {
                        throw new NullReferenceException();
                    }
                    allBoatsDto = allBoatsDto.Where(x => x.Active);
                    if (allBoatsDto.Any())
                    {
                        var mapper = mapperConfig.CreateMapper();
                        mapper.Map(allBoatsDto, boatList);
                        return View(boatList.OrderBy(b => b.SailNo));
                    }
                    throw new Exception("Could not find any boats.");
                }
                catch (Exception e)
                {
                    TempData["ResultMessage"] = e.Message;
                    return View("Error");
                }
            }
        }

        public ActionResult Create()
        {
            //try
            //{
            //    var boatRegistrationViewModel = new BoatRegistrationViewModel();
            //    //BoatDTO boat = new BoatDTO(boatRegistrationViewModel.SailNo, boatRegistrationViewModel.Name, boatRegistrationViewModel.Type, boatRegistrationViewModel.Handicap);
            //    var mapperConfig = new MapperConfiguration(cfg => cfg.CreateMap<BoatRegistrationViewModel, BoatDTO>());
            //    var mapper = mapperConfig.CreateMapper();
            //    mapper.Map(boatRegistrationViewModel, boat);
            //    UserDTO user;
            //    using (var userService = new UserService())
            //    {
            //        user = userService.EagerDisconnectedService.FindBy(u => u.Login == Session["Login"].ToString()).First();
            //    }
            //    using (var boatService = new BoatService())
            //    {
            //        boatService.EagerDisconnectedService.Add(user, boat);
            //    }
            //    return View(boatRegistrationViewModel);
            //}
            //catch (Exception e)
            //{
            //    TempData["ResultMessage"] = e.Message;
            //    return View("Error");
            //}
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BoatRegistrationViewModel boatRegistrationViewModel) //TODO kolla i databas om det sparas
        {
            try
            {
                BoatDTO boat = new BoatDTO(boatRegistrationViewModel.SailNo, boatRegistrationViewModel.Name, boatRegistrationViewModel.Type, boatRegistrationViewModel.Handicap);
                var mapperConfig = new MapperConfiguration(cfg => cfg.CreateMap<BoatRegistrationViewModel, BoatDTO>());
                var mapper = mapperConfig.CreateMapper();
                mapper.Map(boatRegistrationViewModel, boat);
                UserDTO user;
                using (var userService = new UserService())
                {
                    var loginUser = Session["Login"].ToString();
                    user = userService.EagerDisconnectedService.FindBy(u => u.Login == loginUser).First();
                }
                using (var boatService = new BoatService())
                {
                    boatService.EagerDisconnectedService.Add(user, boat);
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["ResultMessage"] = e.Message;
                return View("Error");
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BoatDTO, BoatEditViewModel>();
            });
            try
            {
                using (var boatService = new BoatService())
                {
                    var boatList = boatService.EagerDisconnectedService.FindBy(x => x.Id == id);
                    if (boatList == null)
                    {
                        return HttpNotFound();
                    }
                    var boat = new BoatEditViewModel();
                    var mapper = mapperConfig.CreateMapper();
                    mapper.Map(boatList.First(), boat);
                    return View(boat);
                }
            }
            catch (Exception e)
            {
                TempData["ResultMessage"] = e.Message;
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BoatEditViewModel boatEditViewModel) //TODO Kolla i databas om det sparas
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //BoatDTO boat = new BoatDTO();
                    //var mapperConfig = new MapperConfiguration(cfg => cfg.CreateMap<BoatEditViewModel, BoatDTO>());
                    //var mapper = mapperConfig.CreateMapper();
                    //mapper.Map(boatEditViewModel, boat);

                    //using (var boatService = new BoatService())
                    //{
                    //    boatService.EagerDisconnectedService.Update(boat);
                    //}
                }
                catch (Exception e)
                {
                    TempData["ResultMessage"] = e.Message;
                    return View("Error");
                }
            }
            return View("Index");
        }

        //TODO fix boatDropDownListViewModel
        public ActionResult DropDownList()
        {
            //ViewBag.BoatId = new SelectList(db.Boats, "Id", "Name");

            var boatList = new List<BoatDropDownListViewModel>();
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BoatDTO, BoatDropDownListViewModel>();
            });

            using (var boatService = new BoatService())
            {
                try
                {
                    var allBoatsDto = boatService.EagerDisconnectedService.GetAll().Where(x => x.Active);
                    if (allBoatsDto == null)
                    {
                        throw new NullReferenceException();
                    }
                    var mapper = mapperConfig.CreateMapper();
                    mapper.Map(allBoatsDto, boatList);

                    ViewBag.BoatId = new SelectList(boatList.OrderBy(b => b.FullBoatName), "Id", "FullBoatName");
                    return View();
                }
                catch (Exception e)
                {
                    TempData["ResultMessage"] = e.Message;
                    return View("Error");
                }
            }
        }

        public ActionResult Delete(int? id) //TODO kolla i databas om boat blir Active = false
        {
            if (id == null || id == 0)
            {
                throw new NullReferenceException();
            }
            try
            {
                using (var boatService = new BoatService())
                {
                    var foundBoatToDelete = boatService.EagerDisconnectedService.FindBy(x => x.Id == id.Value);
                    if (foundBoatToDelete == null)
                    {
                        throw new NullReferenceException();
                    }
                    var arne = foundBoatToDelete.First();
                    // boatService.EagerDisconnectedService.Delete(arne);
                    //boatService.EagerDisconnectedService.Delete(foundBoatToDelete.First());
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
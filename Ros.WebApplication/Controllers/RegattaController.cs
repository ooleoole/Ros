using AutoMapper;
using Domain.Entities;
using Domain.Services.AggregatRoots.RegattaServices;
using Ros.WebApplication.Models.ViewModels.AddressViewModels;
using Ros.WebApplication.Models.ViewModels.ClubViewModels;
using Ros.WebApplication.Models.ViewModels.RegattaViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Ros.WebApplication.Controllers
{
    public class RegattaController : Controller
    {
        // GET: Regatta
        public ActionResult Index()
        {
            var regattaList = new List<RegattaIndexViewModel>();
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RegattaDTO, RegattaIndexViewModel>();
                cfg.CreateMap<AddressDTO, AddressDisplayViewModel>();
                cfg.CreateMap<ClubDTO, ClubDisplayViewModel>();
            });
            using (var regattaService = new RegattaService())
            {
                try
                {
                    //var allClubsDto = regattaService.EagerDisconnectedService.GetAll();
                    var allClubsDto = regattaService.EagerDisconnectedService.FindByInclude(x => x.Active, p => p.Address, c => c.Club); //TODO ola fixar metod
                    if (allClubsDto == null)
                    {
                        throw new NullReferenceException();
                    }
                    if (allClubsDto.Any())
                    {
                        var mapper = mapperConfig.CreateMapper();
                        mapper.Map(allClubsDto, regattaList);
                        return View(regattaList.OrderBy(r => r.Name)); // Och Order by Start Date?
                    }
                    throw new Exception("Could not find any Regattas. lol");
                }
                catch (Exception e)
                {
                    TempData["ResultMessage"] = e.Message;
                    return View("Error");
                }
            }
        }

        // GET: Regatta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //var regattaList = new List<RegattaIndexViewModel>();
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RegattaDTO, RegattaIndexViewModel>();
                cfg.CreateMap<AddressDTO, AddressDisplayViewModel>();
                cfg.CreateMap<ClubDTO, ClubDisplayViewModel>();
            });
            try
            {
                using (var regattaService = new RegattaService())
                {
                    //var regattaList = regattaService.EagerDisconnectedService.FindBy(x => x.Id == id); //Something is borke
                    var regattaList = regattaService.EagerDisconnectedService.FindBy(i => i.Id == id /*, x => x.Active, p => p.Address, c => c.Club*/);
                    if (regattaList == null)
                    {
                        return HttpNotFound();
                    }
                    var regatta = new RegattaDetailsViewModel();
                    var mapper = mapperConfig.CreateMapper();
                    mapper.Map(regattaList.First(), regatta);
                    return View(regatta);
                }
            }
            catch (Exception e)
            {
                TempData["ResultMessage"] = e.Message;
                return View("Error");
            }
        }

        // GET: Regatta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Regatta/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Regatta/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Regatta/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Regatta/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Regatta/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Navigations()
        {
            return View();
        }
    }
}
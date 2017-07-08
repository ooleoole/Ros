using AutoMapper;
using Domain.Entities;
using Domain.Services.AggregatRoots.SocialEventServices;
using Ros.WebApplication.Models.ViewModels.RegattaViewModels;
using Ros.WebApplication.Models.ViewModels.SocialEventViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Ros.WebApplication.Controllers
{
    public class SocialEventsController : Controller
    {
        // GET: SocialEvents
        public ActionResult Index()
        {
            var raceEventList = new List<SocialEventIndexViewModel>();
            //return View(raceEventList);

            var mapperConfig = new MapperConfiguration(cfg =>
             {
                 cfg.CreateMap<SocialEventDTO, SocialEventIndexViewModel>();
                 cfg.CreateMap<RegattaDTO, RegattaDisplayViewModel>();
             });
            using (var raceEventService = new SocialEventService())
            {
                try
                {
                    var allRaceEventDto = raceEventService.EagerDisconnectedService.FindByInclude(x => x.Active, r => r.Regatta);
                    if (allRaceEventDto == null)
                    {
                        throw new NullReferenceException();
                    }
                    if (allRaceEventDto.Any())
                    {
                        var mapper = mapperConfig.CreateMapper();
                        mapper.Map(allRaceEventDto, raceEventList);
                        return View(raceEventList.OrderBy(r => r.Name));
                    }
                    throw new Exception("Could not find any SocialEvents.");
                }
                catch (Exception e)
                {
                    TempData["ResultMessage"] = e.Message;
                    return View("Error");
                }
            }
        }

        // GET: SocialEvents/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SocialEvents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SocialEvents/Create
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

        // GET: SocialEvents/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SocialEvents/Edit/5
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

        // GET: SocialEvents/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SocialEvents/Delete/5
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
    }
}
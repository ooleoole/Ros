using AutoMapper;
using Domain.Entities;
using Domain.Services.AggregatRoots.RaceEventServices;
using Ros.WebApplication.Models.ViewModels.RaceEventModels;
using Ros.WebApplication.Models.ViewModels.RegattaViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Ros.WebApplication.Controllers
{
    public class RaceEventsController : Controller
    {
        // GET: RaceEvents
        public ActionResult Index()
        {
            var raceEventList = new List<RaceEventIndexViewModel>();
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RaceEventDTO, RaceEventIndexViewModel>();
                cfg.CreateMap<RegattaDTO, RegattaDisplayViewModel>();
            });
            using (var raceEventService = new RaceEventService())
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
                    throw new Exception("Could not find any RaceEvents.");
                }
                catch (Exception e)
                {
                    TempData["ResultMessage"] = e.Message;
                    return View("Error");
                }
            }
        }

        // GET: RaceEvents/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RaceEvents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RaceEvents/Create
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

        // GET: RaceEvents/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RaceEvents/Edit/5
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

        // GET: RaceEvents/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RaceEvents/Delete/5
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
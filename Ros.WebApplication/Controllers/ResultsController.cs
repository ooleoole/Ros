using AutoMapper;
using Domain.Entities;
using Domain.Services.ResultServices;
using Ros.WebApplication.Models.ViewModels.EntryViewModels;
using Ros.WebApplication.Models.ViewModels.RaceEventModels;
using Ros.WebApplication.Models.ViewModels.ResultViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Ros.WebApplication.Controllers
{
    public class ResultsController : Controller
    {
        // GET: Results
        public ActionResult Index()
        {
            var resultList = new List<ResultIndexViewModel>();
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ResultDTO, ResultIndexViewModel>();
                cfg.CreateMap<EntryDTO, EntryDisplayViewModel>();
                cfg.CreateMap<RaceEventDTO, RaceEventDisplayViewModel>();
            });

            using (var resultService = new ResultService())
            {
                try
                {
                    var allResultsDto = resultService.EagerDisconnectedService.FindByInclude(x => x.Active, e => e.Entry, r => r.RaceEvent);
                    if (allResultsDto == null)
                    {
                        throw new NullReferenceException();
                    }

                    if (allResultsDto.Any())
                    {
                        var mapper = mapperConfig.CreateMapper();
                        mapper.Map(allResultsDto, resultList);
                        return View(resultList.OrderBy(r => r.Name));
                    }
                    throw new Exception("Could not find any results.");
                }
                catch (Exception e)
                {
                    TempData["ResultMessage"] = e.Message;
                    return View("Error");
                }
            }
            //var resultList = new List<ResultIndexViewModel>();
            //return View(resultList);
        }

        // GET: Results/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Results/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Results/Create
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

        // GET: Results/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Results/Edit/5
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

        // GET: Results/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Results/Delete/5
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
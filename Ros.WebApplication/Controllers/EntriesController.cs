using AutoMapper;
using Domain.Entities;
using Domain.Services.AggregatRoots.ClubServices;
using Domain.Services.AggregatRoots.EntryServices;
using Domain.Services.AggregatRoots.RegattaServices;
using Domain.Services.BoatServices;
using Ros.WebApplication.Models.ViewModels.BoatViewModels;
using Ros.WebApplication.Models.ViewModels.ClubViewModels;
using Ros.WebApplication.Models.ViewModels.EntryViewModels;
using Ros.WebApplication.Models.ViewModels.RegattaViewModels;
using Ros.WebApplication.Models.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Domain.Services.AggregatRoots.UserServices;

namespace Ros.WebApplication.Controllers
{
    public class EntriesController : Controller
    {
        // GET: Entries
        public ActionResult Index()
        {
            var entryList = new List<EntryIndexViewModel>();
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EntryDTO, EntryIndexViewModel>();
                cfg.CreateMap<BoatDTO, BoatDisplayViewModel>();
                cfg.CreateMap<ClubDTO, ClubDisplayViewModel>();
                cfg.CreateMap<UserDTO, UserDisplayViewModel>();
                cfg.CreateMap<RegattaDTO, RegattaDisplayViewModel>();
            });

            using (var entryService = new EntryService())
            {
                try
                {
                    var allEntriesDto = entryService.EagerDisconnectedService.FindByInclude(x => x.Active, b => b.Boat, c => c.Club, u => u.User, r => r.Regatta);
                    if (allEntriesDto == null)
                    {
                        throw new NullReferenceException();
                    }

                    if (allEntriesDto.Any())
                    {
                        var mapper = mapperConfig.CreateMapper();
                        mapper.Map(allEntriesDto, entryList);
                        return View(entryList.OrderBy(e => e.EntryName));
                    }
                    throw new Exception("Could not find any results.");
                }
                catch (Exception e)
                {
                    TempData["ResultMessage"] = e.Message;
                    return View("Error");
                }
            }
        }

        // GET: Entries/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Entries/Create
        public ActionResult Create()
        {
            EntryCreateViewModel entryCreateViewModel = new EntryCreateViewModel();

            var boatList = new List<BoatDropDownListViewModel>();
            var clubList = new List<ClubDropDownListViewModel>();
            var regattaList = new List<RegattaDropDownListViewModel>();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BoatDTO, BoatDropDownListViewModel>();
                cfg.CreateMap<ClubDTO, ClubDropDownListViewModel>();
                cfg.CreateMap<RegattaDTO, RegattaDropDownListViewModel>();
            });

            using (var boatService = new BoatService())
            using (var clubService = new ClubService())
            using (var regattaService = new RegattaService())
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

                    var allclubsDto = clubService.EagerDisconnectedService.FindByInclude(x => x.Active);
                    if (allclubsDto == null)
                    {
                        throw new NullReferenceException();
                    }
                    var mapper2 = mapperConfig.CreateMapper();
                    mapper.Map(allclubsDto, clubList);

                    var allregattasDto = regattaService.EagerDisconnectedService.FindByInclude(x => x.Active);
                    if (allregattasDto == null)
                    {
                        throw new NullReferenceException();
                    }
                    var mapper3 = mapperConfig.CreateMapper();
                    mapper.Map(allregattasDto, regattaList);

                    ViewBag.BoatDropDownList = new SelectList(boatList.OrderBy(b => b.FullBoatName), "Id", "FullBoatName");
                    ViewBag.ClubDropDownList = new SelectList(clubList.OrderBy(c => c.Name), "Id", "Name");
                    ViewBag.RegattaDropDownList = new SelectList(regattaList.OrderBy(c => c.Name), "Id", "Name");
                    
                    return View();
                }
                catch (Exception e)
                {
                    TempData["ResultMessage"] = e.Message;
                    return View("Error");
                }
            }
        }

        // POST: Entries/Create
        [HttpPost]
        public ActionResult Create(EntryCreateViewModel entryCreateViewModel)
        {
            try
            {
                EntryDTO entryDto = new EntryDTO(entryCreateViewModel.EntryNo, entryCreateViewModel.EntryName, DateTime.Now, 0, entryCreateViewModel.BoatId, entryCreateViewModel.RegattaId, entryCreateViewModel.ClubRepresentationId);
                UserDTO user;
                using (var userService = new UserService())
                {
                    var loginUser = Session["Login"].ToString();
                    user = userService.EagerDisconnectedService.FindBy(u => u.Login == loginUser).First();
                }
                using (var entryService = new EntryService())
                {
                    entryService.EagerDisconnectedService.Add(user, entryDto);
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["ResultMessage"] = e.Message;
                return View("Error");
            }
        }

        // GET: Entries/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Entries/Edit/5
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

        // GET: Entries/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Entries/Delete/5
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
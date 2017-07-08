using AutoMapper;
using Domain.Entities;
using Domain.Services.AggregatRoots.ClubServices;
using Ros.WebApplication.Models.ViewModels.AddressViewModels;
using Ros.WebApplication.Models.ViewModels.ClubViewModels;
using Ros.WebApplication.Models.ViewModels.PhoneNumberViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Ros.WebApplication.Controllers
{
    public class ClubsController : Controller
    {
        // GET: Clubs
        public ActionResult Index()
        {
            var clubList = new List<ClubIndexViewModel>();
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClubDTO, ClubIndexViewModel>();
                cfg.CreateMap<AddressDTO, AddressDisplayViewModel>();
                //cfg.CreateMap<PhoneNumberDisplayViewModel, PhoneNumberDTO>();
            });

            using (var clubService = new ClubService())
            {
                try
                {
                    var allClubsDto = clubService.EagerDisconnectedService.FindByInclude(x => x.Active, p => p.Address /*, f => f.PhoneNumbers*/).ToList();
                    if (allClubsDto == null)
                    {
                        throw new NullReferenceException();
                    }
                    //allClubsDto = allClubsDto.Where(x => x.Active);
                    //var clubAddressIdtemp = allClubsDto.FirstOrDefault(x => x.Id.Equals(true));
                    //foreach (var club in allClubsDto)
                    //{
                    //    club.GetPhoneNumbers();
                    //}

                    if (allClubsDto.Any())
                    {
                        var mapper = mapperConfig.CreateMapper();
                        mapper.Map(allClubsDto, clubList);
                        return View(clubList.OrderBy(b => b.Name));
                    }
                    throw new Exception("Could not find any clubs.");
                }
                catch (Exception e)
                {
                    TempData["ResultMessage"] = e.Message;
                    return View("Error");
                }
            }
        }

        // GET: Clubs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClubDTO, ClubDetailsViewModel>();
            });
            try
            {
                using (var clubService = new ClubService())
                {
                    var clubList = clubService.EagerDisconnectedService.FindBy(x => x.Id == id);
                    if (clubList == null)
                    {
                        return HttpNotFound();
                    }
                    var club = new ClubDetailsViewModel();
                    var mapper = mapperConfig.CreateMapper();
                    mapper.Map(clubList.First(), club);
                    return View(club);
                }
            }
            catch (Exception e)
            {
                TempData["ResultMessage"] = e.Message;
                return View("Error");
            }
        }

        // GET: Clubs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clubs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClubCreateViewModel clubCreateViewModel)
        {
            try
            {
                //var club = new ClubDTO();
                //var mapperConfig = new MapperConfiguration(cfg =>
                //{
                //    cfg.CreateMap<ClubCreateViewModel, ClubDTO>();
                //    cfg.CreateMap<AddressDisplayViewModel, AddressDTO>();
                //});
                //var mapper = mapperConfig.CreateMapper();
                //mapper.Map(clubCreateViewModel, club);
                //club.Active = true;
                //club.Address.Active = true;
                //club.Address.Type = "Röv";
                //club.RegistrationDate = DateTime.Now;
                //using (var clubService = new ClubService())
                //{
                //    clubService.EagerDisconnectedService.Add(club);
                //}
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["ResultMessage"] = e.Message;
                return View("Error");
            }
        }

        // GET: Clubs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClubDTO, ClubEditViewModel>();
            });
            try
            {
                using (var clubService = new ClubService())
                {
                    var clubList = clubService.LazyConnectedService.FindBy(x => x.Id == id);
                    if (clubList == null)
                    {
                        return HttpNotFound();
                    }
                    var club = new ClubEditViewModel();
                    var mapper = mapperConfig.CreateMapper();
                    mapper.Map(clubList.First(), club);
                    return View(club);
                }
            }
            catch (Exception e)
            {
                TempData["ResultMessage"] = e.Message;
                return View("Error");
            }
        }

        // POST: Clubs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClubEditViewModel clubEditViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ////TODO fix
                    //var mapperConfig = new MapperConfiguration(cfg =>
                    //{
                    //    cfg.CreateMap<ClubEditViewModel, ClubDTO>();
                    //    cfg.CreateMap<AddressDisplayViewModel, AddressDTO>();
                    //    cfg.CreateMap<PhoneNumberDisplayViewModel, PhoneNumberDTO>();
                    //});

                    //ClubDTO club = new ClubDTO();
                    //var mapper = mapperConfig.CreateMapper();
                    //mapper.Map(clubEditViewModel, club);
                    //using (var clubService = new ClubService())
                    //{
                    //    ClubDTO clubDto = new ClubDTO(club);
                    //    clubService.LazyConnectedService.Update(clubDto);
                    //}
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    TempData["ResultMessage"] = e.Message;
                    return View("Error");
                }
            }
            return View(clubEditViewModel);
        }

        // GET: Clubs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClubDTO, ClubDeleteViewModel>();
            });
            try
            {
                using (var clubService = new ClubService())
                {
                    var clubList = clubService.EagerDisconnectedService.FindBy(x => x.Id == id);
                    if (clubList == null)
                    {
                        return HttpNotFound();
                    }
                    var club = new ClubDeleteViewModel();
                    var mapper = mapperConfig.CreateMapper();
                    mapper.Map(clubList.First(), club);
                    return View(club);
                }
            }
            catch (Exception e)
            {
                TempData["ResultMessage"] = e.Message;
                return View("Error");
            }
        }

        // POST: Clubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            try
            {
                using (var clubService = new ClubService())
                {
                    //var addressService = new AddressService();

                    var foundClubToDelete = clubService.EagerDisconnectedService.FindBy(x => x.Id == id.Value);
                    if (foundClubToDelete == null)
                    {
                        throw new NullReferenceException();
                    }
                    var selectedClub = foundClubToDelete.First();
                    //TODO Find Address and "Delete"
                    // clubService.EagerDisconnectedService.Delete(selectedClub);
                    //addressService.EagerDisconnectedService.Delete(new AddressDTO(address));
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
using AutoMapper;
using Domain.Entities;
using Domain.Services.AggregatRoots.EntryServices;
using Domain.Services.AggregatRoots.TeamServices;
using Ros.WebApplication.Models.ViewModels.EntryViewModels;
using Ros.WebApplication.Models.ViewModels.TeamViewModels;
using Ros.WebApplication.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Domain.Services.AggregatRoots.UserServices;
using Ros.Mapping.DomainModels;

namespace Ros.WebApplication.Controllers
{
    public class TeamsController : Controller
    {
        // GET: Teams
        public ActionResult Index()
        {
            var teamList = new List<TeamIndexViewModel>();
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TeamDTO, TeamIndexViewModel>();
                cfg.CreateMap<EntryDTO, EntryDisplayViewModel>();
            });

            using (var teamService = new TeamService())
            {
                try
                {
                    var allTeamsDto = teamService.EagerDisconnectedService.FindByInclude(x => x.Active, e => e.Entry);
                    if (allTeamsDto == null)
                    {
                        throw new NullReferenceException();
                    }

                    if (allTeamsDto.Any())
                    {
                        var mapper = mapperConfig.CreateMapper();
                        mapper.Map(allTeamsDto, teamList);
                        return View(teamList.OrderBy(r => r.TeamName));
                    }
                    throw new Exception("Could not find any Teams.");
                }
                catch (Exception e)
                {
                    TempData["ResultMessage"] = e.Message;
                    return View("Error");
                }
            }
        }

        // GET: Teams/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Teams/Create
        public ActionResult Create()
        {
            TeamCreateViewModel teamCreateViewModel = new TeamCreateViewModel();
            var entryList = new List<EntryDropDownListViewModel>();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EntryDTO, EntryDropDownListViewModel>();
            });

            using (var entryService = new EntryService())
            {
                try
                {
                    var user = SessionLoginUtilities.GetLoggedInUser(Session);
                    var allEntryDto = user.Permissions.GetEntryAdminPermissons<EntryDTO>();
                    if (allEntryDto == null)
                    {
                        throw new NullReferenceException();
                    }
                    var mapper = mapperConfig.CreateMapper();
                    mapper.Map(allEntryDto, entryList);

                    ViewBag.EntryDropDownList = new SelectList(entryList.OrderBy(b => b.FullEntryName), "Id", "FullEntryName");

                    return View();
                }
                catch (Exception e)
                {
                    TempData["ResultMessage"] = e.Message;
                    return View("Error");
                }
            }
        }

        // POST: Teams/Create
        [HttpPost]
        public ActionResult Create(TeamCreateViewModel teamCreateViewModel)
        {
            try
            {
                TeamDTO teamDto = new TeamDTO(teamCreateViewModel.TeamNo, teamCreateViewModel.TeamName, teamCreateViewModel.EntryId);
                var user = SessionLoginUtilities.GetLoggedInUser(Session);
                using (var teamService = new TeamService())
                {
                    teamService.EagerDisconnectedService.Add(user, teamDto);
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["ResultMessage"] = e.Message;
                return View("Error");
            }
        }

        // GET: Teams/AddUsers/5

        public ActionResult AddUsers(int id)
        {
            try
            {
                using (var teamService = new TeamService())
                using (var entryService = new EntryService())
                {
                    var foundTeam = teamService.EagerDisconnectedService.FindBy(x => x.Id == id).First();
                    var foundUsers =
                        entryService.EagerDisconnectedService.FindBy(x => x.Id == foundTeam.EntryId)
                            .First()
                            .GetEntryMembers();
                    if (foundUsers == null)
                    {
                        throw new NullReferenceException();
                    }

                    var users = new List<AddUserToTeamViewModel>();
                    //users.Id = id;
                    //users.UserList = foundUsers;

                    var mapperConfig = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<UserDTO, AddUserToTeamViewModel>();
                    });
                    var mapper = mapperConfig.CreateMapper();
                    mapper.Map(foundUsers, users);

                    ViewBag.UserList = new SelectList(users.OrderBy(b => b.FullUserName), "Id", "FullUserName");
                }
                return View();
            }
            catch (Exception e)
            {
                TempData["ResultMessage"] = e.Message;
                return View("Error");
            }

        }

        // GET: Teams/AddUsers/5
        [HttpPost]
        public ActionResult AddUsers(AddUserToTeamViewModel addUserToTeamViewModel)
        {
            //TODO Post av users
            //using (var teamService = new TeamService())
            //using (var entryService = new EntryService())
            //{
            //    var foundTeam = teamService.EagerDisconnectedService.FindBy(x => x.Id == id).First();
            //    var foundUsers =
            //        entryService.EagerDisconnectedService.FindBy(x => x.Id == foundTeam.EntryId)
            //            .First()
            //            .GetEntryMembers();

            //    var users = new List<AddUserToTeamViewModel>();
            //    //users.Id = id;
            //    //users.UserList = foundUsers;

            //    var mapperConfig = new MapperConfiguration(cfg =>
            //    {
            //        cfg.CreateMap<UserDTO, AddUserToTeamViewModel>();
            //    });
            //    var mapper = mapperConfig.CreateMapper();
            //    mapper.Map(foundUsers, users);

            //    ViewBag.UserList = new SelectList(users.OrderBy(b => b.FullUserName), "Id", "FullUserName");
            return View();

        }


        // POST: Teams/AddUsers/5
        public ActionResult AddUsersToTeam(AddUserToTeamViewModel user)
        {
            try
            {
                using (var userService = new UserService())
                {
                    
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["ResultMessage"] = e.Message;
                return View("Error");
            }
        }

        // GET: Teams/Edit/5
        public ActionResult Edit(int id)
        {
            //ska ha in alla users.
            //två listor
            //en med alla users
            //den andra ska ha bli det lagat av de som blir laget
            //ska ha ut ett team.
            //lägg till teams och användare kolla Olas services


            return View();
        }

        // POST: Teams/Edit/5
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

        // GET: Teams/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Teams/Delete/5
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
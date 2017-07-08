using System;
using System.Linq;
using Domain.Entities;
using Domain.Services.AggregatRoots.ClubServices;
using Domain.Services.AggregatRoots.UserServices;

namespace Console_PlayGround
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Demo flöde användare skapar entry och anmäler sig till regatta");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();


            using (var clubService = new ClubService())
            using (var userService = new UserService())
            {
                var user = userService.EagerDisconnectedService.FindBy(u => u.Login == "test@gmail.com").FirstOrDefault();

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"--------Användaren skapad av Jacob I GUIT--------");
                Console.WriteLine($"Namn:{user.FullName}\nLogin: {user.Login}");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("");
                Console.WriteLine($"-------Entry admin permission----------");
                foreach (var permissionTarget in user.Permissions.GetEntryAdminPermissons<EntryDTO>())
                {
                    var entry = (EntryDTO)permissionTarget;
                    Console.WriteLine(entry.EntryName);
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"-------Team admin permission----------");
                foreach (var permissionTarget in user.Permissions.GetEntryAdminPermissons<TeamDTO>())
                {
                    var team = (TeamDTO)permissionTarget;
                    Console.WriteLine(team.TeamName);
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"-------Boat admin permission----------");
                foreach (var permissionTarget in user.Permissions.GetEntryAdminPermissons<BoatDTO>())
                {
                    var boat = (BoatDTO)permissionTarget;
                    Console.WriteLine(boat.Name);
                }
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"-------RaceEvent registration permission----------");
                foreach (var permissionTarget in user.Permissions.GetRaceEventRegistrationPermissions())
                {
                    var raceEvent = (RaceEventDTO)permissionTarget;
                    Console.WriteLine(raceEvent.Name);
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"-------RaceEvent attendance permission----------");
                foreach (var permissionTarget in user.Permissions.GetRaceEventRegistrationPermissions())
                {
                    var raceEvent = (RaceEventDTO)permissionTarget;
                    Console.WriteLine(raceEvent.Name);
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"-------SocialEvent attendance permission----------");
                foreach (var permissionTarget in user.Permissions.GetAttendancePermissions<SocialEventDTO>())
                {
                    var socailEvent = (SocialEventDTO)permissionTarget;
                    Console.WriteLine(socailEvent.Name);
                }
                Console.ResetColor();
                //var club = clubService.EagerDisconnectedService.GetAll().FirstOrDefault();
                //club.RoleHandler.

            }


            Console.ReadKey();
        }
    }
}
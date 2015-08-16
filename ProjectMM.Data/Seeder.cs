using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProjectMM.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMM.Data
{
    public static class Seeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            context.Props.AddOrUpdate(
                p => p.PropId,
                new Prop() { PropName = "Sharpie" },
                new Prop() { PropName = "Coin" },
                new Prop() { PropName = "Playing Cards" },
                new Prop() { PropName = "Coffee Mug" },
                new Prop() { PropName = "Phone" },
                new Prop() { PropName = "Keys" },
                new Prop() { PropName = "Sunglasses" },
                new Prop() { PropName = "Headphones" },
                new Prop() { PropName = "Ring" },
                new Prop() { PropName = "Lighter" }
                );

            context.Theories.AddOrUpdate(
                t => t.TheoryId,
                new Theory()
                {
                    TheoryName = "Production",
                    TheoryDescription = "Make it appear out of nowhere!"
                },
                new Theory()
                {
                    TheoryName = "Vanish",
                    TheoryDescription = "Make it vanish into thin air!"
                },
                new Theory()
                {
                    TheoryName = "Transportation",
                    TheoryDescription = "Make it vanish, and then reappear somewhere impossible!"
                },
                new Theory()
                {
                    TheoryName = "Transformation", // This uses TWO props
                    TheoryDescription = "Cause one of these items to change into the other item!"
                },
                new Theory()
                {
                    TheoryName = "Multiplication",
                    TheoryDescription = "Magically duplicate this item again and again!"
                },
                new Theory()
                {
                    TheoryName = "Penetration", // This uses TWO props
                    TheoryDescription = "Cause the two items to inexplicably pass through each other"
                },
                new Theory()
                {
                    TheoryName = "Restoration",
                    TheoryDescription = "Destroy the item in some way. Restore it."
                },
                new Theory()
                {
                    TheoryName = "Levitation",
                    TheoryDescription = "Make the item float in mid-air!"
                });

//////////////////////////////////////////// The following seeds user data

            // ApplicationUser table seeder
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(context);
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(userStore);

            RoleStore<Role> roleStore = new RoleStore<Role>(context);
            RoleManager<Role> roleManager = new RoleManager<Role>(roleStore);

            if (!roleManager.RoleExists("Admin"))
                roleManager.Create(new Role { Name = "Admin" });

            if (!roleManager.RoleExists("User"))
                roleManager.Create(new Role { Name = "User" });

            IdentityResult result = null; // Sets the result to null. Used for error checking.

/////////// Admin (1)
            ApplicationUser admin1 = userManager.FindByName("MagicRawb");

            if (admin1 == null)
            {
                admin1 = new ApplicationUser
                {
                    FirstName = "Rob",
                    LastName = "Greenlee",
                    UserName = "MagicRawb",
                    Gender = Gender.Male
                };
            }

            result = userManager.Create(admin1, "asdfasdf");
            if (!result.Succeeded)
            {
                string error = result.Errors.FirstOrDefault();
                throw new Exception(error);
            }

            userManager.AddToRole(admin1.Id, "Admin"); // Add user1 to Admin role
            admin1 = userManager.FindByName("MagicRawb"); // Assign user1 data to variable user1

/////////// Admin (2)
            ApplicationUser admin2 = userManager.FindByName("admin2");

            if (admin2 == null)
            {
                admin2 = new ApplicationUser
                {
                    FirstName = "Bekah",
                    LastName = "Sells",
                    UserName = "admin2",
                    Gender = Gender.Female
                };
            }

            result = userManager.Create(admin2, "asdfasdf");
            if (!result.Succeeded)
            {
                string error = result.Errors.FirstOrDefault();
                throw new Exception(error);
            }

            userManager.AddToRole(admin2.Id, "Admin"); // Add user1 to Admin role
            admin1 = userManager.FindByName("admin2"); // Assign user1 data to variable user1

/////////// User (1)
            ApplicationUser user1 = userManager.FindByName("user1");

            if (user1 == null)
            {
                user1 = new ApplicationUser
                {
                    FirstName = "Lance",
                    LastName = "Burton",
                    UserName = "user1",
                    Gender = Gender.Male
                };
            }

            result = userManager.Create(user1, "asdfasdf");
            if (!result.Succeeded)
            {
                string error = result.Errors.FirstOrDefault();
                throw new Exception(error);
            }

            userManager.AddToRole(user1.Id, "User"); // Add user1 to Admin role
            user1 = userManager.FindByName("user1"); // Assign user1 data to variable user1

/////////// User (2)
            ApplicationUser user2 = userManager.FindByName("user2");

            if (user2 == null)
            {
                user2 = new ApplicationUser
                {
                    FirstName = "David",
                    LastName = "Stone",
                    UserName = "user2",
                    Gender = Gender.Male
                };
            }

            result = userManager.Create(user2, "asdfasdf");
            if (!result.Succeeded)
            {
                string error = result.Errors.FirstOrDefault();
                throw new Exception(error);
            }

            userManager.AddToRole(user1.Id, "User"); // Add user1 to Admin role
            user2 = userManager.FindByName("user2"); // Assign user1 data to variable user1
        }
    }
}   

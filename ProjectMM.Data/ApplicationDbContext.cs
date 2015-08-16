using Microsoft.AspNet.Identity.EntityFramework;
using ProjectMM.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMM.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public IDbSet<Prop> Props { get; set; }
        public IDbSet<Theory> Theories { get; set; }
        public IDbSet<NewTrick> NewTricks { get; set; }

        public System.Data.Entity.DbSet<ProjectMM.Data.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}

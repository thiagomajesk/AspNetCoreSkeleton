using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BootstrapProject.Web.Data
{
    public class DatabaseInitializer : DropCreateDatabaseAlways<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            // Usuario exemplo
            context.Users.Add(new Models.User
            {
                Email = "user@mailme.com",
                Password = "mypassword",
            });

            context.SaveChanges();
        }
    }
}
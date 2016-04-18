using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CorridorSystem.Models.DAL
{
    public class UserInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ModelContext>
    {
        protected override void Seed(ModelContext context)
        {
            var users = new List<User>
            {
                new User { UserName="viktor", UserType=2, Email="viktor@viktor.com", FirstName="Viktor", LastName="Bjornlund"},
                new User { UserName="filip", UserType=1, Email="filip@viktor.com", FirstName="Filip", LastName="Olsson"}
            };

            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();
        }
    }
}
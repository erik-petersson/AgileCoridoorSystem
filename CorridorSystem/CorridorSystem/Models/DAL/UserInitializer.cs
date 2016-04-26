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
            var users = new List<CorrUser>
            {
                //new CorrUser { UserName="viktor", UserType=2, Email="viktor@viktor.com", FirstName="Viktor", LastName="Bjornlund"},
                //new CorrUser { UserName="filip", UserType=1, Email="filip@viktor.com", FirstName="Filip", LastName="Olsson"}
            };

            context.SaveChanges();
        }
    }
}
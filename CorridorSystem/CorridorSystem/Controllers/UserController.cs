using CorridorSystem.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using CorridorSystem.Models;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace CorridorSystem.Controllers
{
    public class UserController : ApiController
    {
        // Get a specific user by userId
        // GET: api/User/userId
        [Authorize]
        [RoutePrefix("api/User/{uId}")]
        public IHttpActionResult Get(String uId)
        {
            ClaimsIdentity claimsIdentity = (ClaimsIdentity)User.Identity;
            Claim userClaim = claimsIdentity.FindFirst(ClaimTypes.Name);
            string myUsername = userClaim.Value;
            using (var db = new ModelContext())
            {
                User matchingUser = db.Users.Where(x => x.UserName == uId).FirstOrDefault<User>();
                if (matchingUser.UserName == uId)
                {
                    return Ok(matchingUser);
                    //remove me!
                }
                else
                {
                    return NotFound();
                }
            }
        }

        //returns all users of that type
        // GET: api/Users/{type}
        [Authorize]
        [RoutePrefix("api/Users/{uType}")]
        public IHttpActionResult Get(int uType)
        {
            ClaimsIdentity claimsIdentity = (ClaimsIdentity)User.Identity;
            Claim userClaim = claimsIdentity.FindFirst(ClaimTypes.Name);
            string myUsername = userClaim.Value;
            using (var db = new ModelContext())
            {
                List<User> allUsers = db.Users.Where(x => x.UserType == uType).ToList();
                return Ok(allUsers);
            }
            
        }

        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        //Update info for one user
        // PUT: api/User/{uId}
        public IHttpActionResult Put(String uId, [FromBody]string newValues)
        {
            using(var db = new ModelContext())
            {
                var userToUpdate = db.Users.Where(x => x.UserName == uId).FirstOrDefault<User>();

                foreach (var value in newValues.GetType().GetProperties())
                {
                    var newValue = value.GetValue(newValues, null);
                    var oldValue = userToUpdate.GetType().GetProperty(value.Name).GetValue(userToUpdate, null);
                    if (value.Name != "id")
                    {
                        userToUpdate.GetType().GetProperty(value.Name).SetValue(userToUpdate, newValue.ToString());
                    }
                }

                db.Users.AddOrUpdate();
                db.SaveChanges();
                return Ok();
            }
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}

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
        [Route("api/User/{uId}")]
        public IHttpActionResult Get(int uId)
        {
            ClaimsIdentity claimsIdentity = (ClaimsIdentity)User.Identity;
            Claim userClaim = claimsIdentity.FindFirst(ClaimTypes.Name);
            string myUsername = userClaim.Value;
            using (var db = new ModelContext())
            {
                User matchingUser = db.Users.Where(x => x.Id == uId).FirstOrDefault<User>();
                if (matchingUser.Id == uId)
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
        [Route("api/Users/{uType}")]
        public IHttpActionResult Get1(int uType)
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
        [Authorize]
        [Route("api/Users/{uId}")]
        public IHttpActionResult Put(int uId, [FromBody]string newValues)
        {
            using(var db = new ModelContext())
            {
                var userToUpdate = db.Users.Where(x => x.Id == uId).FirstOrDefault<User>();

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

        // Deactivate a user
        // DELETE: api/User/{uId}
        [Authorize]
        [Route("api/Users/{uId}")]
        public IHttpActionResult Delete(int uId)
        {
            using (var db = new ModelContext())
            {
                var userToDeactivate = db.Users.Where(x => x.Id == uId).FirstOrDefault<User>();
                RemovedUsers rmUser = new RemovedUsers();

                foreach (var value in userToDeactivate.GetType().GetProperties()){

                    var newValue = value.GetValue(userToDeactivate, null);

                    rmUser.GetType().GetProperty(value.Name).SetValue(rmUser, newValue.ToString());
                }

                db.Users.Remove(userToDeactivate);
                db.RmUsers.AddOrUpdate();
                db.Users.AddOrUpdate();
                db.SaveChanges();
                return Ok();
                
            }

        }
    }
}

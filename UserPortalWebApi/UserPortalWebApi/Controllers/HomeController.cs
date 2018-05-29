using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserPortalWebApi.Models;

namespace UserPortalWebApi.Controllers
{
    public class HomeController : ApiController
    {
        [Authorize]
        public List<User> Get()
        {
            using (var db = new Context())
            {
                return db.Users.ToList();
            }
        }

        [HttpPost]
        public void Add(User user)
        {
            using (var db = new Context())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }
        [HttpPut]
        public void Update(User user)
        {
            User dbUser;
            using (var db = new Context())
            {
                dbUser = db.Users.SingleOrDefault(x => x.ID == user.ID);
                dbUser.Firstname = user.Firstname;
                dbUser.Lastname = user.Lastname;
                dbUser.Email = user.Email;
                dbUser.Phonenumber = user.Phonenumber; 
                dbUser.Password = user.Password; 

                db.SaveChanges();
            }
        }
    }
}

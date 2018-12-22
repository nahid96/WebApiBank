using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WepApiBank.Models;

namespace WepApiBank.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class WebApiBankController : ApiController
    {
        private ApplicationDbContext _context;

        public WebApiBankController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        [Route("api/GetAllUser")]
        public IHttpActionResult GetAllUser()
        {
            List<User> users = _context.Users.ToList();

            return Ok(users);
        }

        [HttpPost]
        [Route("api/AddNewUser")]
        public IHttpActionResult AddNewUser(User user)
        {

            if (user == null)
            {
                return NotFound();
            }
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok();

        }


        //To create multiple users at a time
        [HttpPost]
        [Route("api/AddNewUsers")]
        public IHttpActionResult AddNewUsers(List<User> users)
        {

            if (users == null)
            {
                return NotFound();
            }
            _context.Users.AddRange(users);
            _context.SaveChanges();
            return Ok();

        }

        [HttpPut]
        [Route("api/EditUser")]
        public IHttpActionResult EditUser(User user)
        {
            User editedUser = _context.Users.FirstOrDefault(p => p.Id == user.Id);

            if (user == null)
            {
                return NotFound();
            }

            editedUser.Balance = user.Balance;
            
            _context.SaveChanges();
            return Ok();

        }
    }
}

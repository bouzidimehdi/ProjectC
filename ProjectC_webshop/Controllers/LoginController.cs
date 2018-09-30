using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using Authentication;
using Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectC_webshop.Controllers
{
    [Route("api/authenticate")]
    public class Logincontroller : Controller
    {
        // Conectie met de webshopcontext.
        private readonly WebshopContext _context;

        // Create Expres methods for login or register.
        private expres_methods_login Loginmethode;

        public Logincontroller(WebshopContext webshopContext)
        {
            _context = webshopContext;
            Loginmethode = new expres_methods_login(_context);
        }

        // POST api/authenticate/login
        [HttpPost("login")]
        public user_frontend Post([FromBody] Login_credentials login_credentials)
        {
            return Loginmethode.Login(login_credentials);
        }

        // POST api/authenticate/register
        [HttpPost("register")]
        public user_frontend Post([FromBody] user_register User)
        {
            return Loginmethode.register(User);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Base.Services.IRepositories;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace Base.WebUI.Controllers
{
    public class UserController : Controller
    {
        [Dependency]
        public IUserRepository UserRepository { get; set; }
        
        //
        // GET: /Articles/
        public ActionResult Index()
        {
            var items = this.UserRepository.GetAll();
            return View(items);
        }
    }
}

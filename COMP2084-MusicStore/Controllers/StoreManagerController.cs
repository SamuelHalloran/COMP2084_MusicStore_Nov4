using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace COMP2084_MusicStore.Controllers
{
    public class StoreManagerController : Controller
    {
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Administrator"))
            {
                return Ok("This should only be visible to LOGGED IN administrators");
            }
            else if (User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }
            else
            {
                return Redirect("/Identity/Account/Login");
            }
        }
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLeasing.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Web.Controllers
{
    [Authorize(Roles = "Manager")]
    public class LesseesController : Controller
    {
        private readonly DataContext _dataContext;

        public LesseesController(

            DataContext dataContext
        )
       
        {
           _dataContext = dataContext;
        }

       

        public IActionResult Index()
        {
            return View(_dataContext.Lessees
                .Include(o => o.User)
                .Include(o => o.Contracts));
        }
    }
}

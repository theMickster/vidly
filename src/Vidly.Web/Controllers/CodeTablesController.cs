using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.DataServices.DbContexts;

namespace Vidly.Web.Controllers
{
    public class CodeTablesController : Controller
    {
        private VidlyDbContext _context = new VidlyDbContext();
        // GET: CodeTables
        public ActionResult Index()
        {
            return View();
        }
    }
}
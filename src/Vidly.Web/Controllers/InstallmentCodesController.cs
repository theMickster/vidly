using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.DataServices.DbContexts;

namespace Vidly.Web.Controllers
{
    public class InstallmentCodesController : Controller
    {
        private readonly VidlyDbContext _context;

        public InstallmentCodesController()
        {
            _context = new VidlyDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var installmentCodes = _context.InstallmentCodes.ToList();

            return View(installmentCodes);
        }
    }
}
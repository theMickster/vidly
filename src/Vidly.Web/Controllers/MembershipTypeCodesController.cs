using System.Linq;
using System.Web.Mvc;
using Vidly.DataServices.DbContexts;

namespace Vidly.Web.Controllers
{
    public class MembershipTypeCodesController : Controller
    {
        private readonly VidlyDbContext _context;

        public MembershipTypeCodesController()
        {
            _context = new VidlyDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var membershipTypeCodes = _context.MembershipTypeCodes.ToList();

            return View(membershipTypeCodes);
        }
    }
}
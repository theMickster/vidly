using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Vidly.DataServices.DbContexts;
using Vidly.DataServices.Models;
using Vidly.DataServices.Services;
using Vidly.Web.ViewModels;

namespace Vidly.Web.Controllers
{
    public class RolesController : Controller
    {
        private VidlyIdentityDbContext _context;
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;

        public RolesController()
        {
            _context = new VidlyIdentityDbContext();
        }

        public RolesController(ApplicationUserManager userManager,ApplicationRoleManager roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }

        
        public ApplicationUserManager UserManager
        {
            get => _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            set => _userManager = value;
        }

        
        public ApplicationRoleManager RoleManager
        {
            get => _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            private set => _roleManager = value;
        }

        public ActionResult Index()
        {
            return View(RoleManager.Roles);
        }

        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = await RoleManager.FindByIdAsync(id);
            // Get the list of Users in this Role
            var users = new List<ApplicationUser>();

            // Get the list of Users in this Role
            foreach (var user in UserManager.Users.ToList())
            {
                if (await UserManager.IsInRoleAsync(user.Id, role.Name))
                {
                    users.Add(user);
                }
            }

            ViewBag.Users = users;
            ViewBag.UserCount = users.Count();
            return View(role);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(RoleEditViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                var role = new ApplicationRole(roleViewModel.Name) {RoleDescription = roleViewModel.RoleDescription};
                var roleresult = await RoleManager.CreateAsync(role);
                if (!roleresult.Succeeded)
                {
                    ModelState.AddModelError("", roleresult.Errors.First());
                    return View();
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = await RoleManager.FindByIdAsync(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            RoleEditViewModel roleModel = new RoleEditViewModel
            {
                Id = role.Id,
                Name = role.Name,
                RoleDescription = role.RoleDescription
            };
            return View(roleModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Name,Id,RoleDescription")] RoleEditViewModel roleModel)
        {
            if (!ModelState.IsValid)
                return View();

            var role = await RoleManager.FindByIdAsync(roleModel.Id);
            role.Name = roleModel.Name;
            role.RoleDescription = roleModel.RoleDescription;
            await RoleManager.UpdateAsync(role);
            return RedirectToAction("Index");
        }
    }
}
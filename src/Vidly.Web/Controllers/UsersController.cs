using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    [Authorize(Roles = "GLOBAL ADMINISTRATOR")]
    public class UsersController : Controller
    {
        private VidlyIdentityDbContext _context;
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;

        public UsersController()
        {
            _context = new VidlyIdentityDbContext();
        }

        public UsersController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
        {
            _context = new VidlyIdentityDbContext();
            UserManager = userManager;
            RoleManager = roleManager;
        }
        
        public ApplicationUserManager UserManager
        {
            get => _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            private set => _userManager = value;
        }
        
        public ApplicationRoleManager RoleManager
        {
            get => _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            private set => _roleManager = value;
        }

        public async Task<ActionResult> Index()
        {
            return View(await UserManager.Users.ToListAsync());
        }

        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await UserManager.FindByIdAsync(id);

            ViewBag.RoleNames = await UserManager.GetRolesAsync(user.Id);

            return View(user);
        }

        public async Task<ActionResult> Create()
        {
            ViewBag.RoleId = new SelectList(await RoleManager.Roles.ToListAsync(), "Name", "Name");
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(RegisterViewModel userViewModel, params string[] selectedRoles)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = userViewModel.Email,
                    Email =userViewModel.Email,                    
                    FirstName = userViewModel.FirstName,
                    LastName = userViewModel.LastName,
                    DriversLicenseId = userViewModel.DriversLicenseId
                };
                var adminresult = await UserManager.CreateAsync(user, userViewModel.Password);

                if (adminresult.Succeeded)
                {
                    if (selectedRoles == null)
                        return RedirectToAction("Index");

                    var result = await UserManager.AddToRolesAsync(user.Id, selectedRoles);
                    if (result.Succeeded)
                        return RedirectToAction("Index");

                    ModelState.AddModelError("", result.Errors.First());
                    ViewBag.RoleId = new SelectList(await RoleManager.Roles.ToListAsync(), "Name", "Name");
                    return View();
                }

                ModelState.AddModelError("", adminresult.Errors.First());
                ViewBag.RoleId = new SelectList(RoleManager.Roles, "Name", "Name");
                return View();
            }
            ViewBag.RoleId = new SelectList(RoleManager.Roles, "Name", "Name");
            return View();
        }

        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await UserManager.FindByIdAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            var userRoles = await UserManager.GetRolesAsync(user.Id);

            return View(new UserEditViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DriversLicenseId = user.DriversLicenseId,
                RolesList = RoleManager.Roles.ToList().Select(x => new SelectListItem()
                {
                    Selected = userRoles.Contains(x.Name),
                    Text = x.Name,
                    Value = x.Name
                })
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Email,Id,FirstName,LastName,DriversLicenseId")] UserEditViewModel editUser, params string[] selectedRole)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByIdAsync(editUser.Id);
                if (user == null)
                {
                    return HttpNotFound();
                }

                user.UserName = editUser.Email;
                user.Email = editUser.Email;
                user.FirstName = editUser.FirstName;
                user.LastName = editUser.LastName;
                user.DriversLicenseId = editUser.DriversLicenseId;

                var userRoles = await UserManager.GetRolesAsync(user.Id);

                selectedRole = selectedRole ?? new string[] { };

                var result = await UserManager.AddToRolesAsync(user.Id, selectedRole.Except(userRoles).ToArray<string>());

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return View();
                }

                result = await UserManager.RemoveFromRolesAsync(user.Id, userRoles.Except(selectedRole).ToArray<string>());

                if (result.Succeeded)
                        return RedirectToAction("Index");

                ModelState.AddModelError("", result.Errors.First());
                return View();
            }

            ModelState.AddModelError("", "Something failed.");
            return View();
        }
    }
}
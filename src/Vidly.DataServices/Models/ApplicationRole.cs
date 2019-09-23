﻿using Microsoft.AspNet.Identity.EntityFramework;

namespace Vidly.DataServices.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string name) : base(name){}
        public string RoleDescription { get; set; }
    }
}

using System.Collections.Generic;
using Vidly.DataServices.Models;

namespace Vidly.Web.ViewModels
{
    public class CustomerEditViewModel
    {
        public IEnumerable<MembershipTypeCode> MembershipTypeCodes { get; set; }
        public Customer Customer { get; set; }
    }
}
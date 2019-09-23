using AutoMapper;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.DataServices.DbContexts;
using Vidly.DataServices.Models;
using Vidly.WebAPI.Dtos;

namespace Vidly.WebAPI.Controllers
{
    /// <summary>
    /// Our API methods to perform actions on Membership Type Code DTOs.
    /// </summary>
    public class MembershipTypeCodesController : ApiController
    {
        private readonly VidlyDbContext _context;

        /// <summary>
        /// .....
        /// </summary>
        public MembershipTypeCodesController()
        {
            _context = new VidlyDbContext();
        }

        /// <summary>
        /// Call this API method to retrieve a list of all membership type codes.
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetMembershipTypeCodes()
        {
            var membershipTypeCodeDtos = _context.MembershipTypeCodes
                .ToList()
                .Select(Mapper.Map<MembershipTypeCode, MembershipTypeCodeDto>);

            return Ok(membershipTypeCodeDtos);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult GetMembershipTypeCode(int id)
        {
            var membershipTypeCode = _context.MembershipTypeCodes
                .SingleOrDefault(m => m.MembershipTypeCodeId == id);

            if (membershipTypeCode == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(Mapper.Map<MembershipTypeCode, MembershipTypeCodeDto>(membershipTypeCode));
        }
    }
}

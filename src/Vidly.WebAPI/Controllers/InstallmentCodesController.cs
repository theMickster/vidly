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
    /// Our API methods to perform actions on Installment Code DTOs.
    /// </summary>
    public class InstallmentCodesController : ApiController
    {
        private readonly VidlyDbContext _context;

        /// <summary>
        /// .....
        /// </summary>
        public InstallmentCodesController()
        {
            _context = new VidlyDbContext();            
        }

        /// <summary>
        /// Call this API method to retrieve a list of all installment codes.
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetInstallmentCodes()
        {
            var installmentCodeDtos = _context.InstallmentCodes
                .ToList()
                .Select(Mapper.Map<InstallmentCode, InstallmentCodeDto>);
            return Ok(installmentCodeDtos);
        }

        /// <summary>
        /// Call this API method to retrieve a single installment code. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult GetInstallmentCode(int id)
        {
            var installmentCode = _context.InstallmentCodes
                .SingleOrDefault(i => i.Id == id);

            if (installmentCode == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(Mapper.Map<InstallmentCode, InstallmentCodeDto>(installmentCode));
        }
    }
}

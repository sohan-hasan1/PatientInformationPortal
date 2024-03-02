using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientInformationPortalAPI.DAL.IRepository;
using PatientInformationPortalAPI.DAL.Repository;
using PatientInformationPortalAPI.Models.ContextModels;

namespace PatientInformationPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NCDController : ControllerBase
    {
        private readonly INCDRepository _iNCDRepository;
        public NCDController(INCDRepository iNCDRepository)
        {
            _iNCDRepository = iNCDRepository;
        }
        [HttpGet]
        public async Task<List<NCD>> GetNCDInformation()
        {
            return await _iNCDRepository.GetAll();
        }
    }
}

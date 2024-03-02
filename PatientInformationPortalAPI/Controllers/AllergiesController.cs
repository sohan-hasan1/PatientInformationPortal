using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientInformationPortalAPI.DAL.IRepository;
using PatientInformationPortalAPI.DAL.Repository;
using PatientInformationPortalAPI.Models.ContextModels;

namespace PatientInformationPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergiesController : ControllerBase
    {
        private readonly IAllergiesRepository _iallergiesRepository;
        public AllergiesController(IAllergiesRepository iallergiesRepository)
        {
            _iallergiesRepository = iallergiesRepository;
        }
        [HttpGet]
        public async Task<List<Allergies>> GetAllergiesInformation()
        {
            return await _iallergiesRepository.GetAll();
        }
    }
}

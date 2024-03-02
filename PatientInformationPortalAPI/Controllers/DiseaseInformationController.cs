using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientInformationPortalAPI.DAL.IRepository;
using PatientInformationPortalAPI.DAL.Repository;
using PatientInformationPortalAPI.Models.ContextModels;

namespace PatientInformationPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseaseInformationController : ControllerBase
    {
        private readonly IDiseaseInformationRepository _iDiseaseInformationRepository;
        public DiseaseInformationController(IDiseaseInformationRepository iDiseaseInformationRepository)
        {
            _iDiseaseInformationRepository = iDiseaseInformationRepository;
        }
        [HttpGet]
        public async Task<List<DiseaseInformation>> GetDiseaseInformationInformation()
        {
            return await _iDiseaseInformationRepository.GetAll();
        }
    }
}

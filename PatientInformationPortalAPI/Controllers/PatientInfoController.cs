using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PatientInformationPortalAPI.DAL.IRepository;
using PatientInformationPortalAPI.DAL.Repository;
using PatientInformationPortalAPI.Models.ContextModels;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
namespace PatientInformationPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientInfoController : ControllerBase
    {
        private readonly IPatientInfoRepository _ipatientInfoRepository;
        public PatientInfoController(IPatientInfoRepository ipatientInfoRepository)
        {
            _ipatientInfoRepository = ipatientInfoRepository;
        }
        [HttpGet]
        public async Task<List<PatientInformation>> GetPatientInformation()
        {
            return await _ipatientInfoRepository.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetPatientInformation(int id)
        {
            PatientInformation patientInformation = await _ipatientInfoRepository.GetById(id);

            return Ok(patientInformation);
        }
        [HttpPost]
        public async Task<ActionResult<PatientInformation>> PostPatientInformation([FromBody] PatientInformation patientInformation)
        {
            try
            {
                await _ipatientInfoRepository.Create(patientInformation);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> PutPatientInfo(int id, [FromBody] PatientInformation patientInformation)
        {
            if (id != patientInformation.PatientID)
            {
                return BadRequest();
            }
            try
            {
                await _ipatientInfoRepository.Update(patientInformation);
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            };
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var patientToDelete = await _ipatientInfoRepository.GetById(id);
            if (patientToDelete == null)
            {
                return NotFound();
            }
            await _ipatientInfoRepository.Delete(patientToDelete.PatientID);
            return Ok();
        }
    }
}

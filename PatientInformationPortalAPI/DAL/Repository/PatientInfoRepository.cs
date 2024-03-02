using Microsoft.EntityFrameworkCore;
using PatientInformationPortalAPI.DAL.IRepository;
using PatientInformationPortalAPI.Enums;
using PatientInformationPortalAPI.Models;
using PatientInformationPortalAPI.Models.ContextModels;

namespace PatientInformationPortalAPI.DAL.Repository
{
    public class PatientInfoRepository : IPatientInfoRepository
    {
        private readonly PatientInfoContext _context;
        public PatientInfoRepository(PatientInfoContext context)
        {
            _context = context;
        }
        public async Task<List<PatientInformation>> GetAll()
        {
            return await _context.PatientsInformation.ToListAsync();
        }
        public async Task<PatientInformation> GetById(int id)
        {

            PatientInformation patientInformation = await _context.PatientsInformation.FirstOrDefaultAsync(obj => obj.PatientID == id);
            if (patientInformation != null)
            {
                patientInformation.NCDDetails = await _context.NCD_Details.Where(ncd => ncd.PatientID == id).Select(e => new NCDDetail
                {
                    ID = e.ID,
                    PatientID = e.PatientID,
                    NCDID = e.NCDID,
                    NCD = e.NCD,
                }).ToListAsync();
                patientInformation.AllergiesDetails = await _context.Allergies_Details.Where(al => al.PatientID == id).Select(e => new AllergiesDetail
                {
                    ID = e.ID,
                    PatientID = e.PatientID,
                    AllergiesID = e.AllergiesID,
                    Allergies = e.Allergies,
                }).ToListAsync();
            }
            return patientInformation;
        }
        public async Task Create(PatientInformation entity)
        {
                await _context.PatientsInformation.AddAsync(entity);
                await Save();
        }
        public async Task Update(PatientInformation entity)
        {
            var result = await _context.PatientsInformation.FirstOrDefaultAsync(h => h.PatientID == entity.PatientID);;
            if (result != null)
            {
                var ncdDetails = _context.NCD_Details.Where(e => entity.PatientID == entity.PatientID);
                _context.NCD_Details.RemoveRange(ncdDetails);

                var algDetails = _context.Allergies_Details.Where(obj => obj.PatientID == entity.PatientID);
                _context.Allergies_Details.RemoveRange(algDetails);

                result.Name = entity.Name;
                result.EpilepsyStatus = entity.EpilepsyStatus;
                result.DiseaseID = entity.DiseaseID;
                result.AllergiesDetails = entity.AllergiesDetails; ;
                result.NCDDetails = entity.NCDDetails;

                await Save();
            }
        }
        public async Task Delete(int id)
        {
                var result = await _context.PatientsInformation.FirstOrDefaultAsync(p => p.PatientID == id);
                if (result != null)
                {
                    _context.PatientsInformation.Remove(result);
                    await Save();
                }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}

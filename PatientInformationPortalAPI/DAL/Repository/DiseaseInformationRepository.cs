using Microsoft.EntityFrameworkCore;
using PatientInformationPortalAPI.DAL.IRepository;
using PatientInformationPortalAPI.Models;
using PatientInformationPortalAPI.Models.ContextModels;

namespace PatientInformationPortalAPI.DAL.Repository
{
    public class DiseaseInformationRepository : IDiseaseInformationRepository
    {
        private readonly PatientInfoContext _context;
        public DiseaseInformationRepository(PatientInfoContext context)
        {
            _context = context;
        }
        public async Task<List<DiseaseInformation>> GetAll()
        {
            return await _context.DiseaseInformation.ToListAsync();
        }
    }
}

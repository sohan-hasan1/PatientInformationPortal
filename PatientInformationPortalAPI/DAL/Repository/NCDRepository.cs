using Microsoft.EntityFrameworkCore;
using PatientInformationPortalAPI.DAL.IRepository;
using PatientInformationPortalAPI.Models;
using PatientInformationPortalAPI.Models.ContextModels;

namespace PatientInformationPortalAPI.DAL.Repository
{
    public class NCDRepository : INCDRepository
    {
        private readonly PatientInfoContext _context;
        public NCDRepository(PatientInfoContext context)
        {
            _context = context;
        }
        public async Task<List<NCD>> GetAll()
        {
            return await _context.NCD.ToListAsync();
        }
    }
}

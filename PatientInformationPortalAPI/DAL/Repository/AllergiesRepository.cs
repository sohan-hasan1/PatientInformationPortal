using Microsoft.EntityFrameworkCore;
using PatientInformationPortalAPI.DAL.IRepository;
using PatientInformationPortalAPI.Models;
using PatientInformationPortalAPI.Models.ContextModels;

namespace PatientInformationPortalAPI.DAL.Repository
{
    public class AllergiesRepository : IAllergiesRepository
    {
        private readonly PatientInfoContext _context;
        public AllergiesRepository(PatientInfoContext context)
        {
            _context = context;
        }
        public async Task<List<Allergies>> GetAll()
        {
            return await _context.Allergies.ToListAsync();
        }
    }
}

using PatientInformationPortalAPI.Models.ContextModels;

namespace PatientInformationPortalAPI.DAL.IRepository
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAll();
    }
    public interface IPatientInfoRepository : IRepository<PatientInformation>
    {
        Task<PatientInformation> GetById(int id);
        Task Create(PatientInformation entity);
        Task Update(PatientInformation entity);
        Task Delete(int id);
        Task Save();
    }

    public interface INCDRepository : IRepository<NCD>
    {
        // You can add specific methods related to patient information if needed
    }
    public interface IDiseaseInformationRepository : IRepository<DiseaseInformation>
    {
        // You can add specific methods related to patient information if needed
    }
    public interface IAllergiesRepository : IRepository<Allergies>
    {
        // You can add specific methods related to patient information if needed
    }
}

using Microsoft.EntityFrameworkCore;
using PatientInformationPortalAPI.Models.ContextModels;

namespace PatientInformationPortalAPI.Models
{
    public class PatientInfoContext : DbContext
    {
        public PatientInfoContext(DbContextOptions<PatientInfoContext> options) : base(options)
        {

        }
        public DbSet<PatientInformation> PatientsInformation { get; set; }
        public DbSet<DiseaseInformation> DiseaseInformation { get; set; }
        public DbSet<NCD> NCD { get; set; }
        public DbSet<Allergies> Allergies { get; set; }
        public DbSet<NCDDetail> NCD_Details { get; set; }
        public DbSet<AllergiesDetail> Allergies_Details { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientInformation>()
                .HasOne(pi => pi.DiseaseInformation)
                .WithMany(di => di.PatientInformations)
                .HasForeignKey(pi => pi.DiseaseID);

            modelBuilder.Entity<NCDDetail>()
               .HasOne(nd => nd.PatientInformation)
               .WithMany(p => p.NCDDetails)
               .HasForeignKey(nd => nd.PatientID);

            modelBuilder.Entity<NCDDetail>()
                .HasOne(nd => nd.NCD)
                .WithMany()
                .HasForeignKey(nd => nd.NCDID);

            modelBuilder.Entity<AllergiesDetail>()
                .HasOne(ad => ad.PatientInformation)
                .WithMany(p => p.AllergiesDetails)
                .HasForeignKey(ad => ad.PatientID);

            modelBuilder.Entity<AllergiesDetail>()
                .HasOne(ad => ad.Allergies)
                .WithMany()
                .HasForeignKey(ad => ad.AllergiesID);
            modelBuilder.Entity<NCD>().HasData(
                  new NCD { NCDID = 1, NCDName = "Diabetes" },
                  new NCD { NCDID = 2, NCDName = "Hypertension" },
                  new NCD { NCDID = 3, NCDName = "Obesity" },
                  new NCD { NCDID = 4, NCDName = "Asthma" },
                  new NCD { NCDID = 5, NCDName = "Heart Disease" },
                  new NCD { NCDID = 6, NCDName = "Cancer" },
                  new NCD { NCDID = 7, NCDName = "Stroke" },
                  new NCD { NCDID = 8, NCDName = "Chronic Kidney Disease" }
             );
            modelBuilder.Entity<Allergies>().HasData(
              new Allergies { AllergiesID = 1, AllergiesName = "Peanuts" },
              new Allergies { AllergiesID = 2, AllergiesName = "Shellfish" },
              new Allergies { AllergiesID = 3, AllergiesName = "Fish" },
              new Allergies { AllergiesID = 4, AllergiesName = "Oniments" },
              new Allergies { AllergiesID = 5, AllergiesName = "Eggs" },
              new Allergies { AllergiesID = 6, AllergiesName = "Tree nuts" },
              new Allergies { AllergiesID = 7, AllergiesName = "Others" },
              new Allergies { AllergiesID = 8, AllergiesName = "No Allergies" }
             );

            modelBuilder.Entity<DiseaseInformation>().HasData(
               new DiseaseInformation { DiseaseID = 1, DiseaseName = "Dengue Fever" },
               new DiseaseInformation { DiseaseID = 2, DiseaseName = "Malaria" },
               new DiseaseInformation { DiseaseID = 3, DiseaseName = "Typhoid fever" },
               new DiseaseInformation { DiseaseID = 4, DiseaseName = "COVID-19" }
            );

        }
    }
}

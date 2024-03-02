using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using PatientInformationPortalWeb.Enums;
using PatientInformationPortalWeb.Helper;
using PatientInformationPortalWeb.Models;
using PatientInformationPortalWeb.Models.ViewModels;

namespace PatientInformationPortalWeb.Controllers
{
    public class PatientInfoController : Controller
    {
        PatientInformationAPI _api = new PatientInformationAPI();
        public async Task<IActionResult> Index()
        {
            List<PatientInformation> patientInformation = new List<PatientInformation>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/PatientInfo");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                patientInformation = JsonConvert.DeserializeObject<List<PatientInformation>>(result);
            }
            return View(patientInformation);
        }
        [HttpGet]
        public async Task<IActionResult> AddPatient()
        {
            PatientInfoViewModel patientInformationViewModel = new PatientInfoViewModel();
            try
            {
                await BindViewModel(patientInformationViewModel);
            }
            catch (Exception ex)
            { }

            return View(patientInformationViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> AddPatient(PatientInfoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PatientInformation patientInformation = new PatientInformation();
                    patientInformation.Name = model.Name;
                    patientInformation.DiseaseID = model.SelectedDiseaseInformation;
                    patientInformation.EpilepsyStatus = (EpilepsyStatus)model.SelectedEpilepsyStatus;
                    patientInformation.NCDDetails = new List<NCDDetail>();
                    if (model.SelectedRightNCDs != null)
                    {
                        foreach (var item in model.SelectedRightNCDs)
                        {
                            patientInformation.NCDDetails.Add(new NCDDetail { NCDID = item });
                        }
                    }

                    patientInformation.AllergiesDetails = new List<AllergiesDetail>();
                    if (model.SelectedRightAllergies != null)
                    {
                        foreach (var item in model.SelectedRightAllergies)
                        {
                            patientInformation.AllergiesDetails.Add(
                                new AllergiesDetail { AllergiesID = item }
                            );
                        }
                    }
                    HttpClient client = _api.Initial();
                    var postTask = client.PostAsJsonAsync("api/PatientInfo", patientInformation);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "PatientInfo");
                    }
                }

                await BindViewModel(model);
            }
            catch (Exception ex)
            { }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            PatientInfoViewModel patientInformationViewModel = new PatientInfoViewModel();
            try
            {
                PatientInformation patientInformation = await GetPatientById(id);
                if (patientInformation == null)
                {
                    return RedirectToAction("Index", "PatientInfo");
                }

                patientInformationViewModel.Name = patientInformation.Name;
                patientInformationViewModel.PatientID = patientInformation.PatientID;
                patientInformationViewModel.SelectedDiseaseInformation = patientInformation.DiseaseID;
                patientInformationViewModel.SelectedEpilepsyStatus = Convert.ToInt32(patientInformation.EpilepsyStatus);

                patientInformationViewModel.RightNCDSelectList = new SelectList(
                    patientInformation.NCDDetails.Select(ncd => new { Id = ncd.NCDID, Name = ncd.NCD.NCDName }),
                    "Id",
                    "Name"
                );
                patientInformationViewModel.RightAllergiesSelectList = new SelectList(
                    patientInformation.AllergiesDetails.Select(al => new { Id = al.AllergiesID, Name = al.Allergies.AllergiesName }),
                    "Id",
                    "Name"
                );
                await BindViewModel(patientInformationViewModel);

                List<int> ncdIDsToRemove = patientInformation.NCDDetails.Select(ncd => ncd.NCDID).ToList();
                List<SelectListItem> ncdSelectListItem = patientInformationViewModel.LeftNCDSelectList
                 .Where(item => !ncdIDsToRemove.Contains(Convert.ToInt32(item.Value)))
                    .ToList();
                patientInformationViewModel.LeftNCDSelectList = new SelectList(ncdSelectListItem, "Value", "Text");


                List<int> allergiesIDsToRemove = patientInformation.AllergiesDetails.Select(allergy => allergy.AllergiesID).ToList();
                List<SelectListItem> algSelectListItem = patientInformationViewModel.LeftAllergiesSelectList
                 .Where(item => !allergiesIDsToRemove.Contains(Convert.ToInt32(item.Value)))
                    .ToList();
                patientInformationViewModel.LeftAllergiesSelectList = new SelectList(algSelectListItem, "Value", "Text");

            }
            catch (Exception ex)
            { }
            return View(patientInformationViewModel);
        }

        private async Task<PatientInformation> GetPatientById(int id)
        {
            PatientInformation patientInformation = new PatientInformation();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/PatientInfo/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                patientInformation = JsonConvert.DeserializeObject<PatientInformation>(result);
            }
            return patientInformation;
        }
        [HttpPost]
        public async Task<IActionResult> Edit(PatientInfoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PatientInformation patientInformation = new PatientInformation();
                    patientInformation.PatientID = model.PatientID;
                    patientInformation.Name = model.Name;
                    patientInformation.DiseaseID = model.SelectedDiseaseInformation;
                    patientInformation.EpilepsyStatus = (EpilepsyStatus)model.SelectedEpilepsyStatus;
                    patientInformation.NCDDetails = new List<NCDDetail>();
                    if (model.SelectedRightNCDs != null)
                    {
                        foreach (var item in model.SelectedRightNCDs)
                        {
                            patientInformation.NCDDetails.Add(new NCDDetail { NCDID = item });
                        }
                    }

                    patientInformation.AllergiesDetails = new List<AllergiesDetail>();
                    if (model.SelectedRightAllergies != null)
                    {
                        foreach (var item in model.SelectedRightAllergies)
                        {
                            patientInformation.AllergiesDetails.Add(
                                new AllergiesDetail { AllergiesID = item }
                            );
                        }
                    }
                    HttpClient client = _api.Initial();
                    var test = JsonConvert.SerializeObject( patientInformation );
                    var postTask = client.PutAsJsonAsync($"api/PatientInfo/{model.PatientID}", patientInformation);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "PatientInfo");
                    }
                }

                await BindViewModel(model);
            }
            catch (Exception ex)
            { }

            return View(model);
        }
        public async Task<IActionResult> Delete(PatientInfoViewModel model)
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"api/PatientInfo/{model.PatientID}");
            return RedirectToAction("Index", "PatientInfo");
        }
        private async Task BindViewModel(PatientInfoViewModel model)
        {
            try
            {
                List<DiseaseInformation> diseaseList = await GetAllDiseaseInfo();
                model.DiseaseInformationSelectList = new SelectList(
                    diseaseList.Select(
                        disease => new { Id = disease.DiseaseID, Name = disease.DiseaseName }
                    ),
                    "Id",
                    "Name"
                );
                model.EpilepsyStatusSelectList = new List<SelectListItem>
                {
                    new SelectListItem
                    {
                        Value = Convert.ToInt32(EpilepsyStatus.Yes).ToString(),
                        Text = EpilepsyStatus.Yes.ToString()
                    },
                    new SelectListItem
                    {
                        Value = Convert.ToInt32(EpilepsyStatus.No).ToString(),
                        Text = EpilepsyStatus.No.ToString()
                    }
                };

                List<NCD> ncdList = await GetAllNCD();
                model.LeftNCDSelectList = new SelectList(
                    ncdList.Select(ncd => new { Id = ncd.NCDID, Name = ncd.NCDName }),
                    "Id",
                    "Name"
                );

                List<Allergies> allergies = await GetAllAllergies();
                model.LeftAllergiesSelectList = new SelectList(
                    allergies.Select(
                        allergy => new { Id = allergy.AllergiesID, Name = allergy.AllergiesName }
                    ),
                    "Id",
                    "Name"
                );
            }
            catch (Exception ex)
            { }
        }
        public async Task<List<DiseaseInformation>> GetAllDiseaseInfo()
        {
            List<DiseaseInformation> diseaseInformation = new List<DiseaseInformation>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/DiseaseInformation");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                diseaseInformation = JsonConvert.DeserializeObject<List<DiseaseInformation>>(result);
            }
            return diseaseInformation;
        }
        public async Task<List<NCD>> GetAllNCD()
        {
            List<NCD> nCDs = new List<NCD>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/NCD");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                nCDs = JsonConvert.DeserializeObject<List<NCD>>(result);
            }
            return nCDs;
        }
        public async Task<List<Allergies>> GetAllAllergies()
        {
            List<Allergies> allergies = new List<Allergies>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Allergies");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                allergies = JsonConvert.DeserializeObject<List<Allergies>>(result);
            }
            return allergies;
        }
    }
}

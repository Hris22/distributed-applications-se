using CryptoTrMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CryptoTrMVC.Controllers
{
    public class CryptoController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7085/api");
        private readonly HttpClient _httpClient;
        public CryptoController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<CryptoViewModel> list = new List<CryptoViewModel>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress
                + "/CryptoData").Result;
            if (response.IsSuccessStatusCode) 
            {
                string data= response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<CryptoViewModel>>(data);
            }
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(CryptoViewModel model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(data,Encoding.UTF8,"application/json");
            HttpResponseMessage httpResponseMessage = _httpClient.PostAsync(_httpClient.BaseAddress+
                "/CryptoData", stringContent).Result;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
        
        [HttpGet]
        public  async Task<IActionResult> Edit(int id)
        {
            CryptoViewModel cryptoView = new CryptoViewModel();
            
            HttpResponseMessage response = await _httpClient.GetAsync($"/cryptodata/{id}");

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                cryptoView = JsonConvert.DeserializeObject<CryptoViewModel>(data);
            }

            return View(cryptoView);
        }

        [HttpPost]
        public IActionResult Edit(CryptoViewModel cryptoView) 
        {
            string data = JsonConvert.SerializeObject(cryptoView);
            StringContent stringContent = new StringContent(data,Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.PutAsync(_httpClient.BaseAddress +
                "/CryptoData", stringContent).Result; 
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            CryptoViewModel cryptoView = new CryptoViewModel();
            HttpResponseMessage httpResponseMessage= _httpClient.GetAsync(_httpClient.BaseAddress
                + "/CryptoData" + id).Result;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
               string data = httpResponseMessage.Content.ReadAsStringAsync().Result;
                cryptoView = JsonConvert.DeserializeObject<CryptoViewModel>(data);
            }
            return View(cryptoView);
        }

        [HttpPost]//,ActionName("DeleteCryptoData")]
        public IActionResult DeleteConfirmet(int id)
        {
            HttpResponseMessage httpResponse = _httpClient.DeleteAsync(_httpClient.BaseAddress +
                "/CryptoData"+id).Result;
            if (httpResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

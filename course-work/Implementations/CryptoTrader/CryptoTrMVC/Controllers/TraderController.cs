using CryptoTrMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CryptoTrMVC.Controllers
{
    public class TraderController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7085/api");
        private readonly HttpClient _httpClient;
        public TraderController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<TraderViewModel> list = new List<TraderViewModel>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress
                + "/traderData").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<TraderViewModel>>(data);
            }
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(TraderViewModel model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = _httpClient.PostAsync(_httpClient.BaseAddress +
                "/traderData", stringContent).Result;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            TraderViewModel cryptoView = new TraderViewModel();

            HttpResponseMessage response = await _httpClient.GetAsync($"/traderdata/{id}");

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                cryptoView = JsonConvert.DeserializeObject<TraderViewModel>(data);
            }

            return View(cryptoView);
        }

        [HttpPost]
        public IActionResult Edit(TraderViewModel cryptoView)
        {
            string data = JsonConvert.SerializeObject(cryptoView);
            StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.PutAsync(_httpClient.BaseAddress +
                "/traderData", stringContent).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            TraderViewModel cryptoView = new TraderViewModel();
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync(_httpClient.BaseAddress
                + "/traderData" + id).Result;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string data = httpResponseMessage.Content.ReadAsStringAsync().Result;
                cryptoView = JsonConvert.DeserializeObject<TraderViewModel>(data);
            }
            return View(cryptoView);
        }

        [HttpPost]//,ActionName("DeleteCryptoData")]
        public IActionResult DeleteConfirmet(int id)
        {
            HttpResponseMessage httpResponse = _httpClient.DeleteAsync(_httpClient.BaseAddress +
                "/traderData" + id).Result;
            if (httpResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

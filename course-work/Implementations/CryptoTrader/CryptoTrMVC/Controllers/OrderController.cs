using CryptoTrMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CryptoTrMVC.Controllers
{
    public class OrderController : Controller
    {

        Uri baseAddress = new Uri("https://localhost:7085/api");
        private readonly HttpClient _httpClient;
        public OrderController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<OrderViewModel> list = new List<OrderViewModel>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress
                + "/orderData").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<OrderViewModel>>(data);
            }
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(OrderViewModel model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = _httpClient.PostAsync(_httpClient.BaseAddress +
                "/orderData", stringContent).Result;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            OrderViewModel cryptoView = new OrderViewModel();

            HttpResponseMessage response = await _httpClient.GetAsync($"/orderdata/{id}");

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                cryptoView = JsonConvert.DeserializeObject<OrderViewModel>(data);
            }

            return View(cryptoView);
        }

        [HttpPost]
        public IActionResult Edit(OrderViewModel cryptoView)
        {
            string data = JsonConvert.SerializeObject(cryptoView);
            StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.PutAsync(_httpClient.BaseAddress +
                "/orderData", stringContent).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            OrderViewModel cryptoView = new OrderViewModel();
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync(_httpClient.BaseAddress
                + "/orderData" + id).Result;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string data = httpResponseMessage.Content.ReadAsStringAsync().Result;
                cryptoView = JsonConvert.DeserializeObject<OrderViewModel>(data);
            }
            return View(cryptoView);
        }

        [HttpPost]//,ActionName("DeleteCryptoData")]
        public IActionResult DeleteConfirmet(int id)
        {
            HttpResponseMessage httpResponse = _httpClient.DeleteAsync(_httpClient.BaseAddress +
                "/orderData" + id).Result;
            if (httpResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

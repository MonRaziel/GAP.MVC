using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GAP.Prueba.Web.Controllers
{
    public class StoreController : Controller
    {
        public async Task<ActionResult> Index()
        {
            InventarioDTO.Results.ResultStore model = null;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", Helpers.HelperUrlServices.GetCredential());
                HttpResponseMessage response = await client.GetAsync(Helpers.HelperUrlServices.GetUrlServiceStore());

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync().Result;
                    model = JsonConvert.DeserializeObject<InventarioDTO.Results.ResultStore>(jsonString);
                }
            }

            return View(model.stores);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(InventarioDTO.Store model)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", Helpers.HelperUrlServices.GetCredential());
                var contentBody = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(Helpers.HelperUrlServices.GetUrlServiceStore(), contentBody);

                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.showFailAlert = true;
                }
                else
                {
                    ViewBag.showSuccessAlert = true;
                }
            }

            return View(model);
        }

        public async Task<ActionResult> Edit(long id)
        {
            InventarioDTO.Results.ResultStore model = null;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", Helpers.HelperUrlServices.GetCredential());
                HttpResponseMessage response = await client.GetAsync(Path.Combine(Helpers.HelperUrlServices.GetUrlServiceStore(), id.ToString()));

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync().Result;
                    model = JsonConvert.DeserializeObject<InventarioDTO.Results.ResultStore>(jsonString);
                }
            }

            if (model.total_elements == 1)
            {
                return View(model.stores[0]);
            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        public async Task<ActionResult> Edit(InventarioDTO.Store model)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", Helpers.HelperUrlServices.GetCredential());
                var contentBody = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync(Helpers.HelperUrlServices.GetUrlServiceStore(), contentBody);

                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.showFailAlert = true;
                }
                else
                {
                    ViewBag.showSuccessAlert = true;
                }
            }

            return View(model);
        }
    }
}
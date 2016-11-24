using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GAP.Prueba.Web.Controllers
{
    public class ArticleController : Controller
    {
        public async Task<ActionResult> Index()
        {
            InventarioDTO.Results.ResultArticle model = null;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", Helpers.HelperUrlServices.GetCredential());
                HttpResponseMessage response = await client.GetAsync(Helpers.HelperUrlServices.GetUrlServiceArticle());
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync().Result;
                    model = JsonConvert.DeserializeObject<InventarioDTO.Results.ResultArticle>(jsonString);
                }
            }

            return View(model.articles);
        }


        public async Task<ActionResult> Create()
        {
            ViewData["stores"] = await GetStore(null);
            return View();
        }

        private async Task<SelectList> GetStore(string selected)
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

            if (string.IsNullOrEmpty(selected))
            {
                return new SelectList(model.stores, "Store_Id", "Name");
            }
            else
            {
                return new SelectList(model.stores, "Store_Id", "Name", selected);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(InventarioDTO.Article model)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", Helpers.HelperUrlServices.GetCredential());
                var contentBody = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(Helpers.HelperUrlServices.GetUrlServiceArticle(), contentBody);

                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.showFailAlert = true;
                }
                else
                {
                    ViewBag.showSuccessAlert = true;
                }
                ViewData["stores"] = await GetStore(null);
            }

            return View(model);
        }

        public async Task<ActionResult> Edit(long id)
        {
            InventarioDTO.Results.ResultArticle model = null;
            ViewData["stores"] = await GetStore(id.ToString());

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", Helpers.HelperUrlServices.GetCredential());
                HttpResponseMessage response = await client.GetAsync(Path.Combine(Helpers.HelperUrlServices.GetUrlServiceArticle(), id.ToString()));

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync().Result;
                    model = JsonConvert.DeserializeObject<InventarioDTO.Results.ResultArticle>(jsonString);
                }
            }

            if (model.total_elements == 1)
            {
                return View(model.articles[0]);
            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        public async Task<ActionResult> Edit(InventarioDTO.Article model)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", Helpers.HelperUrlServices.GetCredential());
                var contentBody = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync(Helpers.HelperUrlServices.GetUrlServiceArticle(), contentBody);

                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.showFailAlert = true;
                }
                else
                {
                    ViewBag.showSuccessAlert = true;
                }
            }

            ViewData["stores"] = await GetStore(null);
            return View(model);
        }
    }
}

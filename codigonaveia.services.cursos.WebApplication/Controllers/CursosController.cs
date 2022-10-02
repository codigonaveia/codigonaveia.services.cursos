using codigonaveia.services.cursos.WebApplication.enumVerbs;
using codigonaveia.services.cursos.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;
using System.Configuration;
using System.Net;
using System.Text;

namespace codigonaveia.services.cursos.WebApplication.Controllers
{
    public class CursosController : Controller
    {
        readonly string apiUri;
        private readonly IConfiguration _config;
      
        public CursosController(IConfiguration config)
        {
            _config = config;
           apiUri = _config.GetValue<string>("Uri");
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Registrar() {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registrar(CursosViewModel mod)
        {

            using(HttpClient client = new HttpClient())
            {

                StringContent content = new StringContent(JsonConvert.SerializeObject(mod), Encoding.UTF8, "application/json");
                string endpoint = apiUri + enumActions.Register;
                using(var response = await client.PostAsync(endpoint, content))
                {
                    if(response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = JsonConvert.SerializeObject(mod);
                        return RedirectToAction(nameof(ListaCursos), result);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Erro ao fazer o registro");
                    }
                }
                
            }

            return View();
        }


        public async Task<IActionResult> ListaCursos()
        {
            return View(await GetCursos());
        }

        public async Task<IEnumerable<CursosViewModel>?> GetCursos()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var cursos = new CursosViewModel();

                HttpResponseMessage response = await httpClient.GetAsync(apiUri + enumActions.ObterTodosCursos);
                if (response.IsSuccessStatusCode)
                {
                    var dados = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IEnumerable<CursosViewModel>>(dados);

                    
                }
                return new List<CursosViewModel>();
            }
        }

    }
}

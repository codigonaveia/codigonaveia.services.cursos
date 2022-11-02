using codigonaveia.services.cursos.WebApplication.Interfaces;
using codigonaveia.services.cursos.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace codigonaveia.services.cursos.WebApplication.Controllers
{
    public class CursosController : Controller
    {
        readonly string apiUri;
        private readonly IConfiguration _config;
        private readonly ICursosRepository _cursosRepository;

        public CursosController(IConfiguration config, ICursosRepository cursosRepository)
        {
            _config = config;
            _cursosRepository = cursosRepository;
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

            //using(HttpClient client = new HttpClient())
            //{

            //    StringContent content = new StringContent(JsonConvert.SerializeObject(mod), Encoding.UTF8, "application/json");
            //    string endpoint = apiUri + enumActions.Register;
            //    using(var response = await client.PostAsync(endpoint, content))
            //    {
            //        if(response.StatusCode == HttpStatusCode.OK)
            //        {
            //            var result = JsonConvert.SerializeObject(mod);
            //            return RedirectToAction(nameof(ListaCursos));
            //        }
            //        else
            //        {
            //            ModelState.AddModelError("", "Erro ao fazer o registro");
            //        }
            //    }

            //}
            await _cursosRepository.Registrar(mod);
            return RedirectToAction(nameof(ListaCursos));

            //return View();
        }


        public async Task<IActionResult> ListaCursos()
        {
            return View(await _cursosRepository.ObterCursos());
        }
        public async Task Excluir(int Id)
        {
            await _cursosRepository.Excluir(Id);
        }
        public async Task<IActionResult> Update(int Id)
        {
            var result = await _cursosRepository.ObterCursosPorId(Id);

            return View(result);
        }
        [HttpPost, ActionName("Update")]
        public async Task<IActionResult> UpdatePost(int Id, CursosViewModel mod)
        {
            if (ModelState.IsValid)
            {
                if (Id > 0)
                {
                    await _cursosRepository.Update(Id, mod);
                    TempData["Msg"] = $" Curso de Id: {Id} atualizado com sucesso";
                    return RedirectToAction(nameof(ListaCursos));
                }
                else
                {
                    ModelState.AddModelError("", "houve um erro ao tentar editar o curso");
                }
            }
           

            return View(mod);
        }

        public async Task<IActionResult> Detalhes(int Id)
        {
            var result = await _cursosRepository.ObterCursosPorId(Id);

            return View(result);
        }
        //public async Task<IEnumerable<CursosViewModel>?> GetCursos()
        //{
        //    using (HttpClient httpClient = new HttpClient())
        //    {
        //        var cursos = new CursosViewModel();

        //        HttpResponseMessage response = await httpClient.GetAsync(apiUri + enumActions.ObterTodosCursos);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            var dados = await response.Content.ReadAsStringAsync();
        //            return JsonConvert.DeserializeObject<IEnumerable<CursosViewModel>>(dados);


        //        }
        //        return new List<CursosViewModel>();
        //    }
        //}

    }
}

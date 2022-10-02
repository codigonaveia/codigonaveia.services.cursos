using codigonaveia.services.cursos.Domain.Entities;
using codigonaveia.services.cursos.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace codigonaveia.services.cursos.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly ICursosRepository _cursoRepository;

        public CursosController(ICursosRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(EntidadeCursos entidadeCursos)
        {
            if(entidadeCursos == null)
            {
                return BadRequest($"{entidadeCursos} não pode ser nulo");

            }
            await _cursoRepository.Insert(entidadeCursos);
            return Ok("Curso registrado com sucesso!");
        }

        [HttpGet("ObterTodosCursos")]
        public async Task<IActionResult> ObterTodosCursos()
        {

            var resultado = await _cursoRepository.GetAll();
            return Ok(resultado.ToList());
        }

        [HttpGet("ObterCursoPorId/{Id}")]
        public async Task<IActionResult> ObterCursoPorId(int Id)
        {

            var resultado = await _cursoRepository.GetById(Id);
            if(resultado == null)
            {
                return NotFound($"{Id}, não encontrado");
            }
            return Ok(resultado);
        }
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var resultado = await _cursoRepository.GetById(Id);
            if(resultado == null)
            {
                return NotFound($"{Id}, não encontrado");
            }
            await _cursoRepository.Delete(Id);
            return Ok($"{Id}, excluido com sucesso!");
        }
       
        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, EntidadeCursos entidadeCursos)
        {
                       

            if (Id != entidadeCursos.Id)
            {
                return BadRequest($"O Código {Id}, não encontrado");
            }
            try
            {
                
                await _cursoRepository.Update(Id, entidadeCursos);
            }
            catch (DbUpdateConcurrencyException ex)
            {

                throw new Exception(ex.Message);
            }

            return Ok($"Dados atualizado com sucesso!");
        }
    }
}

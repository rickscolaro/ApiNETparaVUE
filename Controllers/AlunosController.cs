using ApiNETparaVUE.Context;
using ApiNETparaVUE.Models;
using ApiNETparaVUE.Service;
using Microsoft.AspNetCore.Mvc;

namespace ApiNETparaVUE.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class AlunosController : Controller {

        private IAlunoService _alunoService;

        public AlunosController(IAlunoService alunoService) {
            _alunoService = alunoService;
        }


        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunos() {

            try {
                var alunos = await _alunoService.GetAlunos();
                return Ok(alunos);
            } catch {

                //return BadRequest("Request inválido");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter alunos");
            }
        }

        [HttpGet("AlunosPorNome")]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunosByName([FromQuery] string nome) {

            try {
                var alunos = await _alunoService.GetAlunosByNome(nome);


                if (alunos == null) {
                    return NotFound($"Não existe alunos com o critério {nome}");
                }

                return Ok(alunos);
            } catch {

                return BadRequest("Request inválido");
                //return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter alunos");
            }
        }


        [HttpGet("{id:int}", Name = "GetAlunosByID")]
        public async Task<ActionResult<Aluno>> GetAlunosByID(int id) {

            try {
                var aluno = await _alunoService.GetAlunoId(id);

                if (aluno == null) {
                    return NotFound($"Não existe aluno com id={id}");
                }
                return Ok(aluno);

            } catch {

                return BadRequest("Request inválido");
                //return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter alunos");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Aluno>> Criar(Aluno aluno) {

            try {

                await _alunoService.CreateAluno(aluno);
                return CreatedAtRoute(nameof(GetAlunosByID), new { id = aluno.AlunoId }, aluno);


            } catch {

                return BadRequest("Request inválido");
                //return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter alunos");
            }
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<Aluno>> Editar(int id, [FromBody] Aluno aluno) {

            try {

                if (aluno.AlunoId == id) {
                    await _alunoService.UpdateAluno(aluno);
                    return Ok($"Aluno com id={id} foi atualizado com sucesso");
                } else {
                    return BadRequest("Dados inconsistentes");
                }
            } catch {

                return BadRequest("Request inválido");
                //return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter alunos");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Aluno>> Deletar(int id) {

            try {

                var aluno = await _alunoService.GetAlunoId(id);

                if (aluno != null) {
                    await _alunoService.DeleteAluno(aluno);
                    return Ok($"Aluno com id={id} foi excluído com sucesso");
                } else {
                    return NotFound($"Aluno com id={id} não encontrado");
                }
            } catch {

                return BadRequest("Request inválido");
                //return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter alunos");
            }
        }


    }
}
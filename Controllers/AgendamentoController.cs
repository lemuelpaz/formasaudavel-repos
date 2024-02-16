using API.Model.Data;
using API.Source.Base.Contracts.Service;
using API.Source.Base.Middleware;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentoController : BaseController
    {
        #region Constructor
        private readonly IAgendamentoService _service;
        public AgendamentoController(IAgendamentoService service)
        {
            _service = service;
        }
        #endregion

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create([FromBody] Agendamento createDTO)
        {
            try
            {
                var agendamento = BuildResponse(await _service.Create(createDTO));
                return agendamento;
            }
            catch (Exception ex)
            {
                return BuildResponse(message: ex.Message, success: false);
            }
        }


        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var agendamento = BuildResponse(await _service.Get(id));
                return agendamento;
            }
            catch (Exception ex)
            {
                return BuildResponse(message: ex.Message, success: false);
            }
        }


        [HttpGet("GetByProfissional/{profissionalId}")]
        [Authorize]
        public async Task<ActionResult> GetByProfissional(int profissionalId)
        {
            try
            {
                var agendamento = BuildResponse(await _service.GetByProfissional(profissionalId));
                return agendamento;
            }
            catch (Exception ex)
            {
                return BuildResponse(message: ex.Message, success: false);
            }
        }

        [HttpGet("list")]
        [Authorize]
        public async Task<ActionResult> List()
        {
            try
            {
                var agendamento = BuildResponse(await _service.List());
                return agendamento;
            }
            catch (Exception ex)
            {
                return BuildResponse(message: ex.Message, success: false);
            }
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> Update([FromBody] Agendamento updateDTO)
        {
            try
            {
                var agendamento = BuildResponse(await _service.Update(updateDTO));
                return agendamento;
            }
            catch (Exception ex)
            {
                return BuildResponse(message: ex.Message, success: false);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var agendamento = BuildResponse(await _service.Delete(id));
                return agendamento;
            }
            catch (Exception ex)
            {
                return BuildResponse(message: ex.Message, success: false);
            }
        }
    }
}

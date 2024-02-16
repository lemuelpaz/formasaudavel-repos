using API.Model.Data;
using API.Source.Base.Contracts.Service;
using API.Source.Base.Middleware;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataAgendamentoController : BaseController
    {
        #region Constructor
        private readonly IDataAgendamentoService _service;
        public DataAgendamentoController(IDataAgendamentoService service)
        {
            _service = service;
        }
        #endregion

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create([FromBody] HoraAgendamento createDTO)
        {
            try
            {
                var hora = BuildResponse(await _service.Create(createDTO));
                return hora;
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
                var hora = BuildResponse(await _service.Get(id));
                return hora;
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
                var hora = BuildResponse(await _service.List());
                return hora;
            }
            catch (Exception ex)
            {
                return BuildResponse(message: ex.Message, success: false);
            }
        }


        [HttpGet("list/{profissionalId}")]
        [Authorize]
        public async Task<ActionResult> List(int? profissionalId)
        {
            try
            {
                var hora = BuildResponse(await _service.ListByProfissional(profissionalId));
                return hora;
            }
            catch (Exception ex)
            {
                return BuildResponse(message: ex.Message, success: false);
            }
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> Update([FromBody] HoraAgendamento updateDTO)
        {
            try
            {
                var hora = BuildResponse(await _service.Update(updateDTO));
                return hora;
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
                var hora = BuildResponse(await _service.Delete(id));
                return hora;
            }
            catch (Exception ex)
            {
                return BuildResponse(message: ex.Message, success: false);
            }
        }
    }
}

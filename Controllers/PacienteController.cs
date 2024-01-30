using API.Model.Data;
using API.Source.Base.Contracts.Service;
using API.Source.Base.Middleware;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : BaseController
    {
        #region Constructor
        private readonly IPacienteService _service;
        public PacienteController(IPacienteService service)
        {
            _service = service;
        }
        #endregion

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Paciente createDTO)
        {
            try
            {
                var paciente = BuildResponse(await _service.Create(createDTO));
                return paciente;
            }
            catch (Exception ex)
            {
                return BuildResponse(message: ex.Message, success: false);
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var paciente = BuildResponse(await _service.Get(id));
                return paciente;
            }
            catch (Exception ex)
            {
                return BuildResponse(message: ex.Message, success: false);
            }
        }

        [HttpGet("list")]
        public async Task<ActionResult> List()
        {
            try
            {
                var paciente = BuildResponse(await _service.List());
                return paciente;
            }
            catch (Exception ex)
            {
                return BuildResponse(message: ex.Message, success: false);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Paciente updateDTO)
        {
            try
            {
                var paciente = BuildResponse(await _service.Update(updateDTO));
                return paciente;
            }
            catch (Exception ex)
            {
                return BuildResponse(message: ex.Message, success: false);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var paciente = BuildResponse(await _service.Delete(id));
                return paciente;
            }
            catch (Exception ex)
            {
                return BuildResponse(message: ex.Message, success: false);
            }
        }
    }
}

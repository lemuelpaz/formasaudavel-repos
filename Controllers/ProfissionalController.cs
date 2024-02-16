using API.Model.Data;
using API.Source.Base.Contracts.Service;
using API.Source.Base.Middleware;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfissionalController : BaseController
    {
        #region Constructor
        private readonly IMedicoService _service;
        public ProfissionalController(IMedicoService service)
        {
            _service = service;
        }
        #endregion

        [HttpPost]
        //[Authorize]
        public async Task<ActionResult> Create([FromBody] Profissional createDTO)
        {
            try
            {
                var medico = BuildResponse(await _service.Create(createDTO));
                return medico;
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
                var medico = BuildResponse(await _service.Get(id));
                return medico;
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
                var medicos = BuildResponse(await _service.List());
                return medicos;
            }
            catch (Exception ex)
            {
                return BuildResponse(message: ex.Message, success: false);
            }
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> Update([FromBody] Profissional updateDTO)
        {
            try
            {
                var medico = BuildResponse(await _service.Update(updateDTO));
                return medico;
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
                var medico = BuildResponse(await _service.Delete(id));
                return medico;
            }
            catch (Exception ex)
            {
                return BuildResponse(message: ex.Message, success: false);
            }
        }
    }
}

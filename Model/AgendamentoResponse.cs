using API.Model.Data;

namespace API.Model
{
    public class AgendamentoResponse : Agendamento
    {
        public string? PacienteNome { get; set; }
        public string? ProfissionalNome { get; set; }
    }
}

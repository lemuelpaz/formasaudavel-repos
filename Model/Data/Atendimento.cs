using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace API.Model.Data
{
    public class Atendimento
    {
        [Key]
        public int Id { get; set; }
        public StatusAtendimento StatusAtendimento { get; set; }
        public DateTime DataAgendada { get; set; }
        public string? Observacao { get; set; }
        public int MedicoId { get; set; }
        public int PacienteId { get; set; }
        public int AgendamentoId { get; set; }


        //Relations
        [JsonIgnore, XmlIgnore]
        public Medico? Medico { get; set; }
        [JsonIgnore, XmlIgnore]
        public Paciente? Paciente { get; set; }
        [JsonIgnore, XmlIgnore]
        public Agendamento? Agendamento { get; set; }
    }

    public enum StatusAtendimento
    {
        AguardandoAtendimento = 0,
        EmAtendimento = 1,
        Atendido = 2,
        Concluido = 3,
    }
}

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace API.Model.Data
{
    public class Medico
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int Idade { get; set; }
        public CargoType? CargoAtribuido { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public string? Cpf { get; set; }
        public bool Status { get; set; } = true;
        public string? Image { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        //Pacientes
        [XmlIgnore, JsonIgnore]
        public List<Paciente>? Paciente { get; set; }

        [XmlIgnore, JsonIgnore]
        public List<Agendamento>? Agendamento { get; set; }

        [XmlIgnore, JsonIgnore]
        public List<Atendimento>? Atendimento { get; set; }

        [XmlIgnore, JsonIgnore]
        public IEnumerable<HoraAgendamento>? HoraAgendamento { get; set; }
    }
}

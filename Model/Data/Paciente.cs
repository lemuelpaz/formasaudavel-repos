using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace API.Model.Data
{
    public class Paciente
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public int? Idade { get; set; }
        public string? Cpf { get; set; }

        [XmlIgnore, JsonIgnore]
        public List<Agendamento>? Agendamento { get; set; }

        [XmlIgnore, JsonIgnore]
        public List<Atendimento>? Atendimento { get; set; }

    }

}

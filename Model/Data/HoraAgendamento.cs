using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using System.Text.Json.Serialization;

namespace API.Model.Data
{
    public class HoraAgendamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? ProfissionalId { get; set; }
        public bool? Ativo { get; set; } = true;
        [Required]
        public DateTime? DataAgendamento { get; set; }

        public TimeSpan Hora { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;


        [XmlIgnore, JsonIgnore]
        public Profissional? Profissional { get; set; }
    }
}

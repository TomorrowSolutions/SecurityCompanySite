using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace KursovoiRSOD.Models
{
    public class Position
    {
        public int Id { get; set; }
        [Display(Name = "Название")]
        [Required(ErrorMessage = "Введите название")]
        public string Name { get; set; }
        [Display(Name = "Оклад")]
        [Required(ErrorMessage = "Введите оклад")]
        public double Salary { get; set; }
    }
}

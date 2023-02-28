using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace KursovoiRSOD.Models
{
    public class Service
    {
        public int Id { get; set; }
        [Display(Name = "Название")]
        [StringLength(100, MinimumLength = 1)]
        [Required(ErrorMessage = "Введите название")]
        public string Name { get; set; }
        [Display(Name = "Стоимость")]
        [Required(ErrorMessage = "Введите стоимость")]
        public double price { get; set; }
        [Display(Name = "Время выполнения(дни)")]
        [Required(ErrorMessage = "Введите время выполнения в днях")]
        public int PeriodOfExecution { get; set; }

    }
}

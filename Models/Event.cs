using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace KursovoiRSOD.Models
{
    public class Event
    {
        public int Id { get; set; }
        [Display(Name = "Объект")]
        [Required(ErrorMessage = "Укажите объект")]
        public int GuardedObjectId { get; set; }
        [Display(Name = "Объект")]
        public GuardedObject? GuardedObject { get; set; }
        [Display(Name = "Название")]
        [Required(ErrorMessage = "Введите название события")]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }
        [Display(Name = "Дата события")]
        [Required(ErrorMessage = "Укажите дату события")]
        public DateTime DateOfEvent { get; set; }
    }
}

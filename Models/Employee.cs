using KursovoiRSOD.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace test.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Display(Name = "Фамилия")]
        [StringLength(100, MinimumLength = 1)]
        public string? Surname { get; set; }
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Введите имя")]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }
        [Display(Name = "Отчество")]
        [StringLength(100, MinimumLength = 1)]
        public string? Patronymic { get; set; }
        [Display(Name = "Образование")]
        [Required(ErrorMessage = "Укажите тип образования")]
        public string Education { get; set; }
        [Display(Name = "Должность")]
        [Required(ErrorMessage = "Укажите должность")]
        public int PositionId { get; set; }
        [Display(Name = "Должность")]
        public Position? Position { get; set; }
        [Display(Name = "Дата начала работы")]
        [Required(ErrorMessage = "Укажите дату начала работы")]
        public DateTime DateOfStart { get; set; }
        [Display(Name = "Логин")]
        [Required(ErrorMessage = "Введите логин")]
        public string Login { get; set; }
        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }
    }
}

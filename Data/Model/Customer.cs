using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Пронстранство от имена на базата данни
/// </summary>
namespace Data.Model
{
    /// <summary>
    /// Публичен клас на базата данни за клиенти
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Публично поле, отразяващо идентификацинния номер на клиента
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Публично поле, отразяващо името на клиента
        /// </summary>
        [DisplayName("Име")]
        [Required(ErrorMessage = "Име е задължително поле!")]
        public string? FirstName { get; set; }

        /// <summary>
        /// Публично поле, отразяващо фамилията на клиента
        /// </summary>
        [DisplayName("Фамилия")]
        [Required(ErrorMessage = "Фамилия е задължително поле!")]
        public string? LastName { get; set; }

        /// <summary>
        /// Публично поле, отразяващо имейл адреса на клиента
        /// </summary>
        [DisplayName("Имейл адрес")]
        [Required(ErrorMessage = "Имейл адрес е задължително поле!")]
        [EmailAddress(ErrorMessage = "Невалиден имейл адрес!")]
        public string? Email { get; set; }

        /// <summary>
        /// Публично поле, отразяващо телефоння номер на клиента
        /// </summary>
        [DisplayName("Телефонен номер")]
        [Required(ErrorMessage = "Телефонен номер е задължително поле!")]
        [Phone(ErrorMessage = "Невалиден телефонен номер!")]
        public string? Phone { get; set; }

        /// <summary>
        /// Публично поле, отразяващо коя кола е наета от клиента
        /// </summary>
        [DisplayName("Регистрационен номер на колата")]
        [Required(ErrorMessage = "Регистрационен номер е задължително поле!")]
        public int Car { get; set; }

        /// <summary>
        /// Публично поле, отразяващо датата и часът на наемане на колата
        /// </summary>
        [DisplayName("Дата и час на наемане")]
        [Required(ErrorMessage = "Дата и час на наемане е задължително поле!")]
        public DateTime From { get; set; }

        /// <summary>
        /// Публично поле, отразяващо крайния час, до който колата може да се ползва
        /// </summary>
        [DisplayName("Дата и час на предаване")]
        [Required(ErrorMessage = "Дата и час на предаване е задължително поле!")]
        public DateTime To { get; set; }


    }
}

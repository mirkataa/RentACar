using System;
using System.Collections.Generic;
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
        public string? FirstName { get; set; }
        /// <summary>
        /// Публично поле, отразяващо фамилията на клиента
        /// </summary>
        public string? LastName { get; set; }
        /// <summary>
        /// Публично поле, отразяващо имейл адреса на клиента
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Публично поле, отразяващо телефоння номер на клиента
        /// </summary>
        public int Phone { get; set; }
        /// <summary>
        /// Публично поле, отразяващо коя кола е наета от клиента
        /// </summary>
        public int Car { get; set; }
        /// <summary>
        /// Публично поле, отразяващо началния час, в който колата е наета
        /// </summary>
        public DateTime From { get; set; }
        /// <summary>
        /// Публично поле, отразяващо крайния час, до който колата може да се ползва
        /// </summary>
        public DateTime To { get; set; }


    }
}

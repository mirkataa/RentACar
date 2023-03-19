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
        /// Идентификационен номер на клиента
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Име на клиента
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия на клиента
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Имейл адрес на клиента
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Телефонен номер на клиента
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Наета кола от клиента
        /// </summary>
        public int Car { get; set; }
        /// <summary>
        /// Начален час, в който колата е наета
        /// </summary>
        public DateTime From { get; set; }
        /// <summary>
        /// Краен час, до който колата може да се ползва
        /// </summary>
        public DateTime To { get; set; }


    }
}

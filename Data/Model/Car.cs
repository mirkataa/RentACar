using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
/// <summary>
/// Пронстранство от имена на базата данни
/// </summary>
namespace Data.Model
{
    /// <summary>
    /// Публичен клас на базата данни за коли
    /// </summary>
    public class Car
    {
        /// <summary>
        /// Публично поле, отразяващо идентификационния номер на колата
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Публично поле, отразяващо марката на колата
        /// </summary>
        [DisplayName("Марка")]
        [Required(ErrorMessage = "Марка е задължително поле!")]
        public string Brand { get; set; }

        /// <summary>
        /// Публично поле, отразяващо регистрационния номер на колата
        /// </summary>
        [DisplayName("Регистрационен номер")]
        [Required(ErrorMessage = "Регистрационен номер е задължително поле!")]
        public string RgNum { get; set; }

        /// <summary>
        /// публично поле, отразяващо броя изминати километри от колата
        /// </summary>
        [DisplayName("Изминати километри")]
        [Required(ErrorMessage = "Изминати километри е задължително поле!")]
        [Range(0, int.MaxValue, ErrorMessage = "Въведете коректни данни!")]
        public int Km { get; set; }

        /// <summary>
        /// Pублично поле, отразяващо дали колата е наета
        /// </summary>
        [DisplayName("Наета")]
        public bool IsRented { get; set; }

        /// <summary>
        /// Преправяме метода да сравнява стойностите на пропъртитата на два обекта Car вместо техните референции
        /// </summary>
        /// <returns>Ако всички пропъртита имат еднакви стойности, връща true, в противен случай връща false.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Car other = (Car)obj;
            return Id == other.Id
                && Brand == other.Brand
                && RgNum == other.RgNum
                && Km == other.Km
                && IsRented == other.IsRented;
        }
    }
}

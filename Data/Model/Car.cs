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
        public int Km { get; set; }

        /// <summary>
        /// Pублично поле, отразяващо дали колата е наета
        /// </summary>
        [DisplayName("Наета")]
        public bool IsRented { get; set; }

    }
}

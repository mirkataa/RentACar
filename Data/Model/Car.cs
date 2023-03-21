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

        public string Brand { get; set; }
        /// <summary>
        /// Публично поле, отразяващо регистрационния номер на колата
        /// </summary>
        public string RgNum { get; set; }
        /// <summary>
        /// публично поле, отразяващо броя изминати километри от колата
        /// </summary>
        public int Km { get; set; }

        public bool IsRented { get; set; }

    }
}

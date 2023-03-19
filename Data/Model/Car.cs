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
        /// Идентификационен номер на кола
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Регистрационен номер на кола
        /// </summary>
        public string RgNum { get; set; }
        /// <summary>
        /// Изминати километри от колата
        /// </summary>
        public int Km { get; set; }
        
    }
}

using System.ComponentModel.DataAnnotations;
using YandexGo.Domain.Commons;
using YandexGo.Domain.Enums;

namespace YandexGo.Domain.Entities.Cars
{
    public class Car : Auditable
    {
        [MaxLength(8)]
        public string Number { get; set; }
        public string Model { get; set; }
        public CarType CarType { get; set; }
    }
}

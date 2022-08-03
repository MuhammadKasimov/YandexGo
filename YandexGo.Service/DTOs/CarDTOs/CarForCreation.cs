using YandexGo.Domain.Enums;

namespace YandexGo.Service.DTOs.CarDTOs
{
    public class CarForCreation
    {
        public string Number { get; set; }
        public string Model { get; set; }
        public CarType CarType { get; set; }
    }

}
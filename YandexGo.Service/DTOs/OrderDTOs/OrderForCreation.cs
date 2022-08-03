using YandexGo.Domain.Enums;

namespace YandexGo.Service.DTOs.OrderDTOs
{
    public class OrderForCreation
    {
        public int UserId { get; set; }
        public int EmployeeId { get; set; }
        public int CarId { get; set; }
        public decimal Price { get; set; }
        public PaymentType PaymentType { get; set; }

    }
}


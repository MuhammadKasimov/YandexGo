using YandexGo.Domain.Commons;
using YandexGo.Domain.Entities.Users;
using YandexGo.Domain.Enums;

namespace YandexGo.Domain.Entities.Orders
{
    public class Order : Auditable
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int EmployeeId { get; set; }
        public decimal Price { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}
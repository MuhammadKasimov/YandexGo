using System.ComponentModel.DataAnnotations;
using YandexGo.Domain.Commons;
using YandexGo.Domain.Entities.Cars;
using YandexGo.Domain.Entities.Ratings;
using YandexGo.Domain.Enums;

namespace YandexGo.Domain.Entities.Users
{
    public class User : Auditable
    {
        [MaxLength(64)]
        public string FirstName { get; set; }
        [MaxLength(64)]
        public string LastName { get; set; }
        [MaxLength(64)]
        public string Username { get; set; }
        public string Login { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [MaxLength(64)]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [MaxLength(30)]
        public string PhoneNumber { get; set; }

        [MaxLength(64)]
        public string Address { get; set; }

        public long? RatingId { get; set; }
        public Rating Rating { get; set; }
        public UserMode UserMode { get; set; }
        public long? CarId { get; set; }
        public Car Car { get; set; }
    }
}

using YandexGo.Domain.Commons;

namespace YandexGo.Domain.Entities.Ratings
{
    public class Rating : Auditable
    {
        public int Score { get; set; }
        public string Comment { get; set; }
    }
}

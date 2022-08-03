using System.Threading.Tasks;
using YandexGo.Service.Interfaces;
using YandexGo.Service.Services;

namespace YandexGo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IUserService userService = new UserService();
            //await userService.CreateAsync(new UserForCreation()
            //{
            //    FirstName = "John",
            //    LastName = "Doe",
            //    Username = "jdoe",
            //    Address = "ksmksmsmsc",
            //    Email = "kscscmsakcmskm@gmail.com",
            //    Login = "ksckdckdcdkc",
            //    Password = "ldskmskmcks19129103@#@@#@",
            //    PhoneNumber = "+998900965664",
            //    UserMode = UserMode.Admin,

            //});
            //await userService.UpdateAsync(5, new UserForCreation()
            //{
            //    FirstName = "John",
            //    LastName = "Doe",
            //    Username = "jsdmkmsk",
            //    Address = "14/62/21",
            //    Email = "kscscmsmsmkkm@gmail.com",
            //    Login = "ksckdckdccmknn",
            //    Password = "ldskms19129103@#@@#@",
            //    PhoneNumber = "+998900965664",
            //    UserMode = UserMode.Admin,
            //});

            //await userService.DeleteAsync(u => u.Id == 5);

            System.Console.WriteLine((await userService.GetAsync(u => u.Id == 8)).Login);
        }
    }
}

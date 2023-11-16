using DateAccess.Models;
using Microsoft.AspNetCore.Identity;

namespace Garaje
{
    public static class Seeder
    {
        public enum Roles
        { User, 
          Admin
        }

        //IServiceProvider клас, який дозволяє доступатися з підключеного Identity доступитися до рядків ролів менеджера
        public static async Task SeedRoles(IServiceProvider app)
        {
            //отримуємо сервіс Identity з додатку
            //IdentityRole має усі властивості ролі (адмін, юзер)
            var roleManeger = app.GetRequiredService<RoleManager<IdentityRole>>();

            //дістаємо імена з Enum
            foreach(var role in Enum.GetNames(typeof(Roles)))
            {
                //перевіряємо, чи є такі ролі у таблиці. Якщо не існує, то створюємо
                if (!await roleManeger.RoleExistsAsync(role))
                {
                    await roleManeger.CreateAsync(new IdentityRole(role));
                }
            }
        }

        public static async Task SeedAdmin(IServiceProvider app)
        {
            var userManager = app.GetRequiredService<UserManager<AppUser>>();
            const string USERNAME = "admin@admin.com";           
            const string PASSWORD = "Admin_1";
            var existingUser = userManager.FindByEmailAsync(USERNAME).Result;

            if (existingUser == null)
            {
                var Appuser = new AppUser
                {
                    UserName = USERNAME,
                    Email = USERNAME,
                    EmailConfirmed = true
                };

                //створюємо адміна та додаємо до нього пароль
                var result = userManager.CreateAsync(Appuser, PASSWORD).Result;

                if (result.Succeeded)
                {
                    //метод який додає у табличку роль користувача
                    userManager.AddToRoleAsync(Appuser, "Admin").Wait();
                }
            }
        }
    }
}

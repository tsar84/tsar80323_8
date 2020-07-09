using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using tsar80323.DAL.Data;
using tsar80323.DAL.Entities;

namespace tsar80323.Services
{
    public class DbInitializer
    {


        public static async Task Seed(ApplicationDbContext context,
    UserManager<ApplicationUser> userManager,
    RoleManager<IdentityRole> roleManager)
        {
            // создать БД, если она еще не создана
            context.Database.EnsureCreated();
           


            if (!context.DishGroups.Any())
            {
                context.DishGroups.AddRange(
               new List<DishGroup>
                {
new DishGroup {GroupName="Стартеры"},
new DishGroup {GroupName="Салаты"},
new DishGroup {GroupName="Супы"},
new DishGroup {GroupName="Основные блюда"},
new DishGroup {GroupName="Напитки"},
new DishGroup {GroupName="Десерты"}
                });
                await context.SaveChangesAsync();
            }
            // проверка наличия объектов
            if (!context.Dishes.Any())
            {
                context.Dishes.AddRange(
                new List<Dish>
                {
//new Dish {DishName="Суп-харчо",Description="Очень острый, невкусный",Calories =200, DishGroupId=3 },


new Dish {DishName="Суп-харчо",Description="Очень острый, невкусный",Calories =200, DishGroupId=3, Image="s1200harcho.jpg" },

new Dish {DishName="Борщ",Description="Много сала, без сметаны",Calories =330, DishGroupId=3, Image="s1200borsh.jpg" },
new Dish {DishName="Котлета пожарская",Description="Хлеб - 80%, Морковь - 20%",Calories =635, DishGroupId=4, Image="s1200kotl.jpg" },
new Dish {DishName="Макароны по-флотски",Description="С охотничьей колбаской",Calories =524, DishGroupId=4, Image="s1200makar.jpg"  },
new Dish {DishName="Компот",Description="Быстро растворимый, 2 литра",Calories =180, DishGroupId=5, Image="s1200kompt.jpg" }
                });
                await context.SaveChangesAsync();
                }



            }








    }
}

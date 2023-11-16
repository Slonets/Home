using DateAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateAccess.Data
{
    public static class SeedData
    {
        public static void SeedCar(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    Id= 1,
                    ModelCar= "BMW i4 M50",
                    ColorCar="Black",
                    Price= 2902760,
                    Discription= "Розгінна динаміка (0-100 км / год), сек.\t3,9\nМаксимальна швидкість, км / год\t225\nПотужність двигуна, к.с.\t544",
                    ImagePath = @"BMW_i4_M50.jpg",
                    CategoryId =1,
                    Quantity = 7

                },

                 new Car
                 {
                     Id = 2,
                     ModelCar = "BMW i4 M50",
                     ColorCar = "Blue",
                     Price = 2942351,
                     Discription = "Розгінна динаміка (0-100 км / год), сек.\t3,9\nМаксимальна швидкість, км / год\t225\nПотужність двигуна, к.с.\t544",
                     ImagePath = @"bmw-i4-m50-blue.jpg",
                     CategoryId = 1,
                     Quantity = 7
                 },

                 new Car
                 {
                        Id = 3,
                        ModelCar = "BMW i4 M50",
                        ColorCar = "Grey",
                        Price = 2964435,
                        Discription = "Розгінна динаміка (0-100 км / год), сек.\t3,9\nМаксимальна швидкість, км / год\t225\nПотужність двигуна, к.с.\t544",
                        ImagePath = @"bmw-i4-m50-grey.jpg",
                        CategoryId = 1,
                        Quantity = 13
                 },

                  new Car
                  {
                      Id = 4,
                      ModelCar = "BMW iX3 M Sport",
                      ColorCar = "Black",
                      Price = 2504303,
                      Discription= "Розгінна динаміка (0-100 км / год), сек.\t6,8\nМаксимальна швидкість, км / год\t180\nПотужність двигуна, к.с.\t210 (286)",
                      ImagePath = @"bmw-ix3-m-sport-black.jpg",
                      CategoryId = 1,
                      Quantity = 32
                  },

                new Car
                {
                    Id= 5,
                    ModelCar= "Toyota Highlander Hybrid",
                    ColorCar="Red",
                    Price = 888282,
                    Discription= "Highlander отримав гібридну силову установку четвертого покоління, яка дозволяє вам насолоджуватися усіма перевагами великого кросовера без шкоди для його потужності та екологічності. Завдяки 2,5-літровому гібридному двигуну Hybrid Dynamic Force потужністю 248 к. с. Highlander пропонує провідний у своєму класі баланс потужності та ефективності.",
                    ImagePath = @"gold-car.png",
                    CategoryId = 2,
                    Quantity = 100
                },
                new Car
                {
                    Id= 6,
                    ModelCar = "Yaris Cross",
                    ColorCar = "Gold",
                    Price = 1058322,
                    Discription = "Завдяки переконливому кліренсу та високій посадці за кермом компактний Yaris Cross надає упевненості при русі містом. Насолоджуйтеся подорожжю із сучасними функціями комфорту та містким салоном, що відповідає повсякденним потребам.",
                    ImagePath = @"gold-car.png",
                    CategoryId = 2,
                    Quantity = 12
                },

                new Car
                {
                    Id= 7,
                    ModelCar = "Corola",
                    ColorCar = "Grey",
                    Price = 757620,
                    Discription = "У 2006 році назві Corolla виповнилося 40 років, протягом яких змінилося десять поколінь цих доступних і надійних автомобілів, а загальний обсяг випуску перевалив за 32 мільйонів. І ця рекордна цифра продажів, занесена до Книги рекордів Гіннесса, збільшується щорічно.",
                    ImagePath = @"white-car.png",
                    CategoryId = 2,
                    Quantity = 4
                },

                new Car
                {
                    Id= 8,
                    ModelCar= "C4 & Ë-C4",
                    ColorCar="Red",
                    Price = 1018300,
                    Discription= "Нові Citroën C4 та ë-C4 з високим дорожнім просвітом, великими колесами та зручними розмірами виглядають готовими до будь-яких випробувань. Вони не тільки місткі, але й аеродинамічні.",
                    ImagePath = @"Qwiqlu-car.jpg",
                    CategoryId = 3,
                    Quantity = 2
                },

                new Car
                {
                    Id = 9,
                    ModelCar = "CITROEN C5 AIRCROSS",
                    ColorCar = "Grey",
                    Price = 1018300,
                    Discription = "Новий плагін-гібрид Citroën C5 Aircross, що підходить для будь-яких щоденних поїздок, пропонує плавний і динамічний рух із потужністю 180 к.с. із двигуном внутрішнього згоряння й електродвигуном на 81,2 кВт (110 к.с.) із загальною потужністю 225 к.с. й обертальним моментом 360 Н-м.",
                    ImagePath = @"Citroen-C5-Aircross.jpg",
                    CategoryId = 3,
                    Quantity = 0
                },

                new Car
                {
                    Id = 10,
                    ModelCar = "DUSTER",
                    ColorCar = "Orange",
                    Price = 1018300,
                    Discription = "Надійний та перевірений часом і досвідом повний привод залишається головною перевагою оновленого Renault Duster. Завдяки зручним режимам роботи 2WD, AUTO або 4WD LOCK кожен водій може приборкати бездоріжжя. Повноприводний новий Renault Duster 4x4 можна купити як з бензиновим атмосферним, так і з дизельним турбо двигуном.",
                    ImagePath = @"Orange.jpg",
                    CategoryId = 4,
                    Quantity = 1
                },

                 new Car
                 {
                     Id = 11,
                     ModelCar = "RENAULT EXPRESS",
                     ColorCar = "Blue",
                     Price = 1100300,
                     Discription = "Новий Renault EXPRESS поєднав у собі фірмові характеристики Renault, які підкреслять ваш смак та педантичність вибору. Ви пишатиметесь своїм Express: виразна передня частина із широким капотом, хромована радіаторна решітка, фірмові денні світлодіодні ліхтарі тощо. Саме цей достойний силует без зайвих деталей надійно супроводжуватиме вас у щоденних справах!",
                     ImagePath = @"Blue-Silver.jpg",
                     CategoryId = 4,
                     Quantity = 3
                 },

                 new Car
                 {
                     Id = 12,
                     ModelCar = "PEUGEOT 408",
                     ColorCar = "Blue",
                     Price = 1000000,
                     Discription = "Вражаюча форма нового PEUGEOT 408 характеризується динамічною натхненною позицією фастбеку. Сучасна елегантність фастбеку виділяє його на дорозі. Завдяки підвищеному дорожньому просвіту, але водночас помірній висоті, його спортивний дизайн і плавні лінії підкреслюють його аеродинамічні властивості. ",
                     ImagePath = @"CarCar.jpg",
                     CategoryId = 5,
                     Quantity = 5
                 },

                  new Car
                  {
                      Id = 13,
                      ModelCar = "PEUGEOT 3008 ",
                      ColorCar = "White",
                      Price = 970000,
                      Discription = "Вражаюча форма нового PEUGEOT 408 характеризується динамічною натхненною позицією фастбеку. Сучасна елегантність фастбеку виділяє його на дорозі. Завдяки підвищеному дорожньому просвіту, але водночас помірній висоті, його спортивний дизайн і плавні лінії підкреслюють його аеродинамічні властивості. Відкрийте для себе технологічний кросовер PEUGEOT 3008 з його інноваційним та натхненним дизайном, який підносить вишуканість на ще вищий рівень, більш елегантний та футуристичний. Його виразні лінії кузова поєднують силу, динаміку та плавність. Для підвищення рівня Вашого комфорту та безпеки було впроваджено низку новаторських технологій та розроблено: сучасний, вдосконалений та просторий салон PEUGEOT 3008 з концепцією організації простору водія PEUGEOT i-Cockpit.",
                      ImagePath = @"Run.jpg",
                      CategoryId = 5,
                      Quantity = 2
                  },

                     new Car
                     {
                         Id = 14,
                         ModelCar = "PEUGEOT 2008",
                         ColorCar = "White",
                         Price = 1370000,
                         Discription = "Відкрийте для себе PEUGEOT 2008 або електрокросовер PEUGEOT 2008: компактний, потужний, динамічний та економічний кросовер.\r\nНасолоджуйтесь динамікою під час руху за рахунок сучаних технологій, які забезпечують тишу та комфорт в салоні автомобіля.",
                         ImagePath = "OrangeCar.jpg",
                         CategoryId = 5,
                         Quantity = 3
                     }
              );
        }

        public static void SeedCategory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new List<Category>()
            {
                new Category(){ Id=1, Name="BMW"},
                new Category(){ Id=2, Name="Toyota"},
                new Category(){ Id=3, Name="Citroen"},
                new Category(){ Id=4, Name="Renault"},
                new Category(){ Id=5, Name="Peugeot"}
            }
              );
        }

        public static void SeedStorage(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Storage>().HasData(
                new List<Storage>()
            {
                new Storage(){ Id=1, CarId=1},
                new Storage(){ Id=2, CarId=2},
                new Storage(){ Id=3, CarId=3},
                new Storage(){ Id=4, CarId=4},
                new Storage(){ Id=5, CarId=5},
                new Storage(){ Id=6, CarId=6},
                new Storage(){ Id=7, CarId=7},
                new Storage(){ Id=8, CarId=8},
                new Storage(){ Id=9, CarId=9},
                new Storage(){ Id=10, CarId=10},
                new Storage(){ Id=11, CarId=11},
                new Storage(){ Id=12, CarId=12},
                new Storage(){ Id=13, CarId=13},
                new Storage(){ Id=14, CarId=14}                
            }
              );
        }
    }
}


using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kurs.DataLayer.Entities;

namespace Kurs.DataLayer.EFContext
{
    class CoursesInitializer : CreateDatabaseIfNotExists<CoursesContext>
    {
        protected override void Seed(CoursesContext context)
        {
            context.Racks.AddRange(new Rack[] {
                new Rack { RackNumber=1, RackCategory ="Плодоовощные", Capacity = 500,
                            Products =new List<Product>{
                                new Product { Name = "Картофель",
                                    Quantity = 200, Category = "овощи",
                                    DateOfArrival =new DateTime (2020, 08, 01)},
                                new Product { Name = "Морковь",
                                    Quantity = 100, Category = "овощи",
                                    DateOfArrival =new DateTime (2020, 08, 01)},
                                new Product { Name = "Лук репчатый",
                                    Quantity = 100, Category = "овощи",
                                    DateOfArrival =new DateTime (2020, 08, 01)},
                                new Product { Name = "Свекла",
                                    Quantity = 100, Category = "овощи",
                                    DateOfArrival =new DateTime (2020, 08, 01)},                             
                            }
                },
                new Rack { RackNumber=2, RackCategory = "Плодоовощные", Capacity = 1000,                    
                            Products =new List<Product>{
                                new Product { Name = "Яблоки",
                                    Quantity = 150, Category = "плоды",
                                    DateOfArrival =new DateTime (2020, 08, 05)},
                                new Product { Name = "Груши",
                                    Quantity = 150, Category = "плоды",
                                    DateOfArrival =new DateTime (2020, 08, 12)},
                                new Product { Name = "Персики",
                                    Quantity = 200, Category = "плоды",
                                    DateOfArrival =new DateTime (2020, 08, 01)},
                                new Product { Name = "Апельсины",
                                    Quantity = 150, Category = "плоды",
                                    DateOfArrival =new DateTime (2020, 06, 20)},
                                new Product { Name = "Киви",
                                    Quantity = 200, Category = "плоды",
                                    DateOfArrival =new DateTime (2020, 07, 21)},
                                new Product { Name = "Бананы",
                                    Quantity = 150, Category = "плоды",
                                    DateOfArrival =new DateTime (2020, 07, 11)},
                            }
                },
                new Rack { RackNumber=3, RackCategory ="Бакалейные", Capacity = 500,
                            Products =new List<Product>{
                                new Product { Name = "Вермишель",
                                    Quantity = 150, Category = "макаронные изделия",
                                    DateOfArrival =new DateTime (2020, 05, 09)},
                                new Product { Name = "Лапша",
                                    Quantity = 100, Category = "макаронные изделия",
                                    DateOfArrival =new DateTime (2020, 07, 21)},
                                new Product { Name = "Спагетти",
                                    Quantity = 150, Category = "макаронные изделия",
                                    DateOfArrival =new DateTime (2020, 08, 15)},
                                new Product { Name = "Рожки",
                                    Quantity = 100, Category = "макаронные изделия",
                                    DateOfArrival =new DateTime (2020, 06, 01)},
                            }
                },
                new Rack { RackNumber=4, RackCategory ="Бакалейные", Capacity = 1500,
                            Products =new List<Product>{
                                new Product { Name = "Рыбные консервы",
                                    Quantity = 500, Category = "консервы",
                                    DateOfArrival =new DateTime (2020, 08, 01)},
                                new Product { Name = "Овощные консервы",
                                    Quantity = 500, Category = "консервы",
                                    DateOfArrival =new DateTime (2020, 03, 11)},
                                new Product { Name = "Мясные консервы",
                                    Quantity = 500, Category = "консервы",
                                    DateOfArrival =new DateTime (2020, 02, 22)},                              
                            }
                },
                new Rack { RackNumber=5, RackCategory = "Бакалейные", Capacity = 2000,
                            Products =new List<Product>{
                                new Product { Name = "Рис",
                                    Quantity = 300, Category = "крупы",
                                    DateOfArrival =new DateTime (2020, 08, 05)},
                                new Product { Name = "Гречка",
                                    Quantity = 500, Category = "крупы",
                                    DateOfArrival =new DateTime (2020, 08, 12)},
                                new Product { Name = "Пшено",
                                    Quantity = 200, Category = "крупы",
                                    DateOfArrival =new DateTime (2020, 08, 01)},
                                new Product { Name = "Перловая",
                                    Quantity = 150, Category = "крупы",
                                    DateOfArrival =new DateTime (2020, 06, 20)},
                                new Product { Name = "Горох",
                                    Quantity = 200, Category = "бобовые",
                                    DateOfArrival =new DateTime (2020, 07, 21)},
                                new Product { Name = "Чечевица",
                                    Quantity = 100, Category = "бобовые",
                                    DateOfArrival =new DateTime (2020, 07, 11)},
                                new Product { Name = "Манная",
                                    Quantity = 200, Category = "крупы",
                                    DateOfArrival =new DateTime (2020, 07, 21)},
                                new Product { Name = "Фасоль",
                                    Quantity = 100, Category = "бобовые",
                                    DateOfArrival =new DateTime (2020, 07, 11)},
                            }
                }
            });
            context.SaveChanges();
        }
    }
}

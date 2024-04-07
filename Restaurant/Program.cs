namespace Restaurant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dishes = new List<Dish>
            {
                new Dish("Котлеты", 49.99, new List<string> { "Говяжий фарш", "Лук" }, DishType.MainCourse),
                new Dish("Рыба", 199.99, new List<string> { "Лосось", "Специи" }, DishType.MainCourse),
                new Dish("Запеченный картофель", 49.99, new List<string> { "Картофель", "Масло" }, DishType.Garnish),
                new Dish("Борщ", 149.99, new List<string> { "Картофель", "Свёкла", "Мясо" }, DishType.Soup),
                new Dish("Пицца Маргарита", 599.99, new List<string> { "Тесто", "Сыр", "Томаты" }, DishType.MainCourse),
                new Dish("Пицца 4 сыра", 799.99, new List<string> { "Тесто", "Соус", "Пармезан", "Моцарелла", "Горгонзолла", "Эмменталь" }, DishType.MainCourse),
            };

            foreach (var dish in dishes)
                Console.WriteLine(dish);
            Console.WriteLine();

            //просто как возможность
            //var sortedByType = dishes.OrderBy(t => t.Type).ToList(); //сортировка по типу блюда
            //var sortedByPrice = dishes.OrderBy(p => p.Price).ToList(); //сортировка по цене
            //var sortedByTypeAndName = dishes.OrderBy(t => t.Type).ThenBy(d => d.Name).ToList(); //сортировка по алфавиту внутри каждого типа


            var d = new List<Dish>();
            var mm = new MenuMaster(dishes, 1);
            foreach (var item in mm.DishesSpecifiedPage(1))
            {
                Console.WriteLine(item);
            }


            Console.ReadKey();
        }
    }
}

using NUnit.Framework;
using Restaurant;

namespace MenuMaster.Tests
{

    [TestFixture]
    public class MenuMasterTest
    {

        private static List<Dish> dishes = new List<Dish>
        {
            new Dish("Котлеты", 49.99, new List<string> { "Говяжий фарш", "Лук" }, DishType.MainCourse),
            new Dish("Рыба", 199.99, new List<string> { "Лосось", "Специи" }, DishType.MainCourse),
            new Dish("Запеченный картофель", 49.99, new List<string> { "Картофель", "Масло" }, DishType.Garnish),
            new Dish("Борщ", 149.99, new List<string> { "Картофель", "Свёкла", "Мясо" }, DishType.Soup),
            new Dish("Пицца Маргарита", 599.99, new List<string> { "Тесто", "Сыр", "Томаты" }, DishType.MainCourse),
            new Dish("Пицца 4 сыра", 799.99, new List<string> { "Тесто", "Соус", "Пармезан", "Моцарелла", "Горгонзолла", "Эмменталь" }, DishType.MainCourse),
        };


        [Test]
        public void AllMenuTest()
        {
            var menuMaster = new Restaurant.MenuMaster(dishes, 1);

            Assert.That(dishes, Is.EqualTo(menuMaster.AllMenu));
        }

        [Test]
        public void AllMenuTestThrowsException1()
        {
            Assert.Throws<ArgumentNullException>(() => new Restaurant.MenuMaster(null, 1));
            //Assert.Throws<ArgumentNullException>(() => menuMaster.AllMenu = null);
        }

        [Test]
        public void AllMenuTestThrowsException2()
        {
            var emptyList = new List<Dish>();
            Assert.Throws<ArgumentException>(() => new Restaurant.MenuMaster(emptyList, 1));
        }


        [Test]
        public void DishesPerPageTest()
        {
            var menuMaster = new Restaurant.MenuMaster(dishes, 2);

            Assert.That(2, Is.EqualTo(menuMaster.DishesPerPage));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void DishesPerPageTestThrowsException(int invalidNumber)
        {
            Assert.Throws<ArgumentException>(() => new Restaurant.MenuMaster(dishes, invalidNumber));
        }


        [Test]
        public void NumberOfDishesTest()
        {
            var menuMaster = new Restaurant.MenuMaster(dishes, 1);

            //Assert.AreEqual(menuMaster.NumberOfDishes, 6);
            Assert.That(6, Is.EqualTo(menuMaster.NumberOfDishes));
        }


        [TestCase(1, 6)]
        [TestCase(2, 3)]
        [TestCase(3, 2)]
        [TestCase(6, 1)]
        [TestCase(10, 1)]
        public void NumberOfPagesTest(int onOnePage, int excRes)
        {
            var menuMaster = new Restaurant.MenuMaster(dishes, onOnePage);

            Assert.That(excRes, Is.EqualTo(menuMaster.NumberOfPages));
        }


        [TestCase(1, true)]
        [TestCase(6, true)]
        [TestCase(4, false)]
        public void LastPageIsFullTest(int onOnePage, bool excRes)
        {
            var menuMaster = new Restaurant.MenuMaster(dishes, onOnePage);

            Assert.That(excRes, Is.EqualTo(menuMaster.LastPageIsFull));
        }

        [TestCase(1, 1, 1)]
        [TestCase(1, 4, 4)]
        [TestCase(2, 4, 2)]
        public void NumberOfDishesSpecifiedPageTest(int page, int onOnePage, int excRes)
        {
            var menuMaster = new Restaurant.MenuMaster(dishes, onOnePage);
            var num = menuMaster.NumberOfDishesSpecifiedPage(page);

            Assert.That(excRes, Is.EqualTo(num));
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(7)]
        public void NumberOfDishesSpecifiedPageTestThrowsException(int invalidPageNumber)
        {
            var menuMaster = new Restaurant.MenuMaster(dishes, 1);

            var ex = Assert.Throws<ArgumentException>(() => menuMaster.NumberOfDishesSpecifiedPage(invalidPageNumber));
            Assert.That(ex.Message, Is.EqualTo("Page number outside menu range."));
        }


        [TestCase(1, 1)]
        [TestCase(1, 6)]
        [TestCase(1, 10)]
        [TestCase(2, 2)]
        [TestCase(2, 4)]
        public void DishesSpecifiedPageTest(int pageNumber, int onOnePage)
        {
            var menuMaster = new Restaurant.MenuMaster(dishes, onOnePage);
            var result = menuMaster.DishesSpecifiedPage(pageNumber);

            var start = (pageNumber - 1) * onOnePage;
            for (int i = 0; i < result.Count; i++)
            {
                Assert.That(result[i], Is.EqualTo(dishes[start + i]));
            }
        }

        [TestCase(-1)]
        [TestCase(-0)]
        [TestCase(790)]
        public void DishesSpecifiedPageTestThrowsException(int invalidPageNumber)
        {
            var menuMaster = new Restaurant.MenuMaster(dishes, 2);

            var ex = Assert.Throws<ArgumentException>(() => menuMaster.DishesSpecifiedPage(invalidPageNumber));
            Assert.That(ex.Message, Is.EqualTo("Page number outside menu range."));
        }


        [TestCase(7)]
        [TestCase(1)]
        [TestCase(4)]
        public void FirstDishesOfAllPagesTest(int onOnePage)
        {
            var menuMaster = new Restaurant.MenuMaster(dishes, onOnePage);

            var result = menuMaster.FirstDishesOfAllPages();

            for (int i = 0; i < result.Count; i++)
            {
                Assert.That(result[i], Is.EqualTo(dishes[i * onOnePage]));
            }
        }
    }
}

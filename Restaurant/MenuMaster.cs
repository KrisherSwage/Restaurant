using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class MenuMaster : IMenuMaster
    {
        private List<Dish> allMenu;
        public List<Dish> AllMenu
        {
            get { return allMenu; }
            set
            {
                if (value == null) { throw new ArgumentNullException("Uninitialized list of dishes."); }
                if (value.Count < 1) { throw new ArgumentException("List of dishes is empty."); }
                allMenu = value;
            }
        }

        private int dishesPerPage;
        public int DishesPerPage
        {
            get { return dishesPerPage; }
            set
            {
                if (value >= 1) { dishesPerPage = value; }
                else { throw new ArgumentException("The number of page elements is less than one."); }
            }
        }

        public int NumberOfDishes
        {
            get { return AllMenu.Count; }
        }

        public int NumberOfPages
        {
            get
            {
                int res = NumberOfDishes / DishesPerPage;
                if (LastPageIsFull) { return res; }
                else { return res + 1; }
            }
        }

        public bool LastPageIsFull //полностью ли заполнена последняя страница
        {
            get
            {
                if (NumberOfDishes % DishesPerPage == 0) { return true; }
                else { return false; }
            }
        }

        /// <summary>
        /// Создание меню-мастера.
        /// </summary>
        /// <param name="allMenu">Список блюд.</param>
        /// <param name="dishesPerPage">Количество блюд на одной странице.</param>
        public MenuMaster(List<Dish> allMenu, int dishesPerPage)
        {
            AllMenu = allMenu;
            DishesPerPage = dishesPerPage;
        }

        public int NumberOfDishesSpecifiedPage(int pageNumber)
        {
            if (pageNumber < 1 || pageNumber > NumberOfPages)
                throw new ArgumentException("Page number outside menu range.");

            if (pageNumber == NumberOfPages && !LastPageIsFull)
            {
                return NumberOfDishes % DishesPerPage; // если брать с последней не заполненной
            }
            else { return DishesPerPage; }
        }

        public List<Dish> DishesSpecifiedPage(int pageNumber)
        {
            if (pageNumber < 1 || pageNumber > NumberOfPages)
                throw new ArgumentException("Page number outside menu range.");

            var start = (pageNumber - 1) * DishesPerPage;
            var count = DishesPerPage;

            if (start + count > NumberOfDishes)
            {
                count = NumberOfDishes - start; // корректировка количества элементов, чтобы оно не выходило за пределы списка
            }

            return AllMenu.GetRange(start, count);
        }

        public List<Dish> FirstDishesOfAllPages()
        {
            return AllMenu.Where((x, i) => i % DishesPerPage == 0).ToList();
        }


    }
}

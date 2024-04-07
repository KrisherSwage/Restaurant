using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    internal interface IMenuMaster
    {
        /// <summary>
        /// Коллекция блюд (всё меню).
        /// </summary>
        public List<Dish> AllMenu { get; set; }

        /// <summary>
        /// Количество элементов на одной странице.
        /// </summary>
        public int DishesPerPage { get; set; }


        /// <summary>
        /// Общее количество блюд.
        /// </summary>
        public int NumberOfDishes { get; }

        /// <summary>
        /// Количество страниц.
        /// </summary>
        public int NumberOfPages { get; }

        /// <summary>
        /// Количество блюд на указанной странице.
        /// </summary>
        /// <param name="pageNumber">Номер страницы.</param>
        /// <returns></returns>
        public int NumberOfDishesSpecifiedPage(int pageNumber);

        /// <summary>
        /// Блюда указанной страницы.
        /// </summary>
        /// <param name="pageNumber">Номер страницы.</param>
        /// <returns></returns>
        public List<Dish> DishesSpecifiedPage(int pageNumber);

        /// <summary>
        /// Список первых блюд каждой страницы.
        /// </summary>
        /// <returns></returns>
        public List<Dish> FirstDishesOfAllPages();
    }
}

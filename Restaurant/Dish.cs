using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Dish
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value == null) { throw new ArgumentNullException("Uninitialized name."); }
                if (value.Length < 1) { throw new ArgumentException("Name in empty."); }
                name = value;
            }
        }

        private double price;
        public double Price
        {
            get { return Math.Round(price, 2); }
            set
            {
                if (value >= 0) { price = value; }
                else { throw new ArgumentException("Price less than zero."); }
            }
        }

        private List<string> ingredients;
        public List<string> Ingredients
        {
            get { return ingredients; }
            set
            {
                if (value == null) { throw new ArgumentNullException("Uninitialized list of ingredients."); }
                if (value.Count < 1) { throw new ArgumentException("List of ingredients is empty."); }
                ingredients = value;
            }
        }

        public DishType Type { get; set; }

        public Dish(string name, double price, List<string> ingredients, DishType type)
        {
            Name = name;
            Price = price;
            Ingredients = ingredients;
            Type = type;
        }


        public override string ToString()
        {
            return $"Name: {Name}, Price = {Price}, Type: {Type}\nIngredients: {string.Join(", ", Ingredients)}";
        }
    }
}

using System.Collections.Generic;

namespace Foodies.Models
{
    public class Shoppinglist
    {
        public int ShoppinglistId { get; set; }
        public string Name { get; set; }
        public ICollection<ShoppinglistIngredient> ShoppinglistIngredients { get; set; }
        public ICollection<UserShoppinglist> UserShoppinglists { get; set; }
    }
}

namespace Foodies.Models
{
    public class UserShoppinglist
    {
        public int UserShoppinglistId { get; set; }
        public int UserId { get; set; }
        public int ShoppinglistId { get; set; }

        public EndUser EndUser { get; set; }
        public Shoppinglist Shoppinglist { get; set; }

    }
}

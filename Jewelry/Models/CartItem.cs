using System.ComponentModel.DataAnnotations;

namespace Jewelry.Models
{
    public class CartItem
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Total
        {
            get { return Quantity * Price; }
        }
        public string Image { get; set; }
        public CartItem()
        {
        }
        public CartItem(ItemDetails itemDetails)
        {
            ProductId = itemDetails.ItemMstID;
            ProductName = itemDetails.prodName;
            Price = itemDetails.MRP;
            Quantity = 1;
            Image = itemDetails.imgUrl;
        }

        public CartItem(ItemDetails itemDetails, int qty) : this(itemDetails)
        {
        }
    }
}

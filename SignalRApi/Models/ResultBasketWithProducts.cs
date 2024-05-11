using SignalR.EntityLayer.Entities;

namespace SignalRApi.Models
{
    public class ResultBasketWithProducts
    {
        public int BasketID { get; set; }

        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public int Count { get; set; }

        public decimal TotalPrice { get; set; }
        public int ProductID { get; set; }
        public int MenuTableID { get; set; }

    }
}

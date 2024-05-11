namespace SignalRWebUI.Dtos.BasketDto
{
    public class CreateBasketDto
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public int Count { get; set; }

        public decimal TotalPrice { get; set; }

        public int ProductID { get; set; }

        public int MenuTableID { get; set; }
    }
}

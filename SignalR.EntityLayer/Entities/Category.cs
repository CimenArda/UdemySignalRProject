namespace SignalR.EntityLayer.Entities
{
    public class Category
    {
        public int ID { get; set; }

        public string? Name { get; set; }

        public bool Status { get; set; }


        public List<Product> Products { get; set; }    




    }
}

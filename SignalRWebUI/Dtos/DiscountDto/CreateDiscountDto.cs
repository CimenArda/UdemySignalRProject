namespace SignalRWebUI.Dtos.DiscountDto
{
	public class CreateDiscountDto
	{


		public string Title { get; set; }

		public string ImageUrl { get; set; }

		public string Description { get; set; }

		public int Amount { get; set; }
        public bool Status { get; set; }

    }
}

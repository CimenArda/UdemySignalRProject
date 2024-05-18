namespace SignalRWebUI.Dtos.ContactDto
{
	public class CreateContactDto
	{

		public string Location { get; set; }

		public string PhoneNumber { get; set; }
		public string Mail { get; set; }
  

        public string FooterDesctiption { get; set; }


        public string FooterTitle { get; set; }
        public string OpenDays { get; set; }


        public string OpenDaysDescription { get; set; }
        public string OpenDaysHour { get; set; }
    }
}

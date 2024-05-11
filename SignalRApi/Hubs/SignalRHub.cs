using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
	public class SignalRHub :Hub
	{
		private readonly ICategoryService _categoryService;
		private readonly IProductService _productService;
		private readonly IOrderService _orderService;
		private readonly IMoneyCaseService _moneyCaseService;
		private readonly IMenuTableService _menuTableService;
		private readonly IBookingService _bookingService;
        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;
            _bookingService = bookingService;
        }

        public async Task GetBookingList()
        {
			var value20 = _bookingService.TGetListAll();

            await Clients.All.SendAsync("ReceiveGetBookingList", value20);

        }



        public async Task TotalOrderCount()
		{
			var value11 = _orderService.TotalOrderCount();

			await Clients.All.SendAsync("ReceiveTotalOrderCount", value11);

		}

		public async Task ActiveOrderCount()
		{
			var value12 = _orderService.ActiveOrderCount();

			await Clients.All.SendAsync("ReceiveActiveOrderCount", value12);

		}
		public async Task SendProgress()
		{
			var value18 = _moneyCaseService.TTotalMoneyCount();

			await Clients.All.SendAsync("ReceiveProgressTTotalMoneyCount", value18.ToString("0.00") + "TL");

		}


		public async Task LastOrderPrice()
		{
			var value13 = _orderService.LastOrderPrice();

			await Clients.All.SendAsync("ReceiveLastOrderPrice", value13.ToString("0.00") + "TL");

		}




		public async Task MoneyCaseCount()
		{
			var value14 = _moneyCaseService.TTotalMoneyCount();

			await Clients.All.SendAsync("ReceiveTTotalMoneyCount", value14.ToString("0.00") + "TL");

		}



		public async Task MenuTableCount()
		{
			var value15 = _menuTableService.TmenutableCount();

			await Clients.All.SendAsync("ReceiveMenuTableCount", value15);

		}

		public async Task SendProductCount()
		{
			var value2 = _productService.ProductCount();

			await Clients.All.SendAsync("ReceiveProductCount", value2);

		}
		public async Task SendProductCategoryHamburger()
		{
			var value5 = _productService.ProductCountByCategoryNameHamburger();

			await Clients.All.SendAsync("ReceiveProductCategoryNameHamburger", value5);

		}
		public async Task ProductPriceAverage()
		{
			var value7 = _productService.TProductPriceAvg();

			await Clients.All.SendAsync("ReceiveTProductPriceAvg", value7.ToString("0.00")+"TL");

		}

		public async Task ProductHamburgerPriceAvg()
		{
			var value10 = _productService.ProductPriceByHamburger();

			await Clients.All.SendAsync("ReceiveProductHamburgerPriceAvg", value10);

		}


		public async Task ProductbyMaxPrice()
		{
			var value8 = _productService.TProductNameByMaxPrice();

			await Clients.All.SendAsync("ReceiveTProductNameByMaxPrice", value8);

		}
		public async Task ProductbyMinPrice()
		{
			var value9 = _productService.TProductNameByMinPrice();

			await Clients.All.SendAsync("ReceiveTProductNameByMinPrice", value9);

		}

		public async Task SendProductCategoryDrink()
		{
			var value6 = _productService.ProductCountByCategoryNameDrink();

			await Clients.All.SendAsync("ReceiveProductCategoryNameDrink", value6);

		}

		public async Task ActiveCategoryCount()
		{
			var value3 = _categoryService.ActiveCategoryCount();

			await Clients.All.SendAsync("ReceiveActiveCategoryCount", value3);

		}
		public async Task PassiveCategoryCount()
		{
			var value4 = _categoryService.PassiveCategoryCount();

			await Clients.All.SendAsync("ReceivePassiveCategoryCount", value4);

		}

		public async Task SendCategoryCount()
		{
			var value = _categoryService.TCategoryCount();

			await Clients.All.SendAsync("ReceiveCategoryCount",value);
		
		}












	}
}

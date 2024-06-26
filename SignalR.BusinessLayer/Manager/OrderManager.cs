﻿using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Manager
{
	public class OrderManager :IOrderService
	{
		private readonly IOrderDal _orderDal;

		public OrderManager(IOrderDal orderDal)
		{
			_orderDal = orderDal;
		}

		public decimal TodayTotalPrice()
		{
			return _orderDal.TodayTotalPrice();
		}
		public int ActiveOrderCount()
		{
			return _orderDal.ActiveOrderCount();
		}

		public decimal LastOrderPrice()
		{
			return _orderDal.LastOrderPrice();
		}

		public void TAdd(Order entity)
		{
			_orderDal.Add(entity);
		}

		public void TDelete(Order entity)
		{
			_orderDal.Delete(entity);
		}

		public Order TGetById(int id)
		{
		  return _orderDal.GetById(id);
		}

		public List<Order> TGetListAll()
		{
			return _orderDal.GetListAll();
		}

		

		public int TotalOrderCount()
		{
			return _orderDal.TotalOrderCount();
		}

		public void TUpdate(Order entity)
		{
			_orderDal.Update(entity);
		}
	}
}

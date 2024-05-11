﻿using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
	public class EfMoneyCaseDal : GenericRepository<MoneyCase>, IMoneyCaseDal
	{
		public EfMoneyCaseDal(SignalRContext signalRContext) : base(signalRContext)
		{
		}

		public decimal TotalMoneyCount()
		{
			using var context = new SignalRContext();

			return context.moneyCases.Select(x => x.TotalAmount).FirstOrDefault();
		}
	}
}

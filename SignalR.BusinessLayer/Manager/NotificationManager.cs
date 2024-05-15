using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Manager
{
	public class NotificationManager :INotificationService
	{
		INotificationDal _notificationDal;

		public NotificationManager(INotificationDal notificationDal)
		{
			_notificationDal = notificationDal;
		}

		public void NotificationStatusChangeToTFalse(int id)
		{
			_notificationDal.NotificationStatusChangeToTFalse(id);
		}

		public void NotificationStatusChangeToTrue(int id)
		{
			_notificationDal.NotificationStatusChangeToTrue(id);
		}

		public void TAdd(Notification entity)
		{
			_notificationDal.Add(entity);
		}

		public void TDelete(Notification entity)
		{
			_notificationDal .Delete(entity);
		}

		public List<Notification> TGetAllNotificationsByFalse()
		{
			return _notificationDal.GetAllNotificationsByFalse();
		}

		public Notification TGetById(int id)
		{
			return _notificationDal.GetById(id);
		}

		public List<Notification> TGetListAll()
		{
			return _notificationDal.GetListAll();
		}

		public int TNotificationCountByStatusFalse()
		{
		return		_notificationDal.NotificationCountByStatusFalse();
		}

		public void TUpdate(Notification entity)
		{
			_notificationDal.Update(entity);
		}
	}
}

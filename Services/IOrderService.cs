using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fungoodMVC.Models;

namespace fungoodMVC.Services
{
	public interface IOrderService
	{
		/*提供點餐、查看餐點、結帳*/
		void SendOrder(List<FoodItem> order, int tableNumber);
		List<FoodItem> CheckOrder(int tableNumber);

		int Pay(int tableNumber);
	}
}
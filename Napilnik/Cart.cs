using System;
using System.Collections.Generic;
using System.Linq;

public class Cart
{
	private Dictionary<string, GoodOrder> _orders;
	private readonly Shop _shop;

	public Cart(Shop shop)
	{
		_shop = shop ?? throw new NullReferenceException(nameof(shop));
		_orders = new Dictionary<string, GoodOrder>();
	}

	public void Add(Good good, int count)
	{
		if (_shop.Contain(good, count))
		{
			_shop.GetGood(good, count);
			if (_orders.ContainsKey(good.Id))
			{
				_orders[good.Id].count += count;
			}

			_orders[good.Id] = new GoodOrder(good, count);
		}
		else
		{
			Console.WriteLine("Not enough goods");
		}
	}

	public UserOrder Order()
	{
		return new UserOrder(_orders.Values.ToList());
	}
}
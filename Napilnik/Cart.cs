using System;
using System.Collections.Generic;
using System.Linq;

public class Cart
{
	private Dictionary<Good, GoodOrder> _orders;
	private readonly Shop _shop;

	public Cart(Shop shop)
	{
		_shop = shop ?? throw new NullReferenceException(nameof(shop));
		_orders = new Dictionary<Good, GoodOrder>();
	}

	public void Add(Good good, int count)
	{
		if (_shop.Contains(good, count))
		{
			_shop.ReserveGood(good, count);
			if (_orders.ContainsKey(good))
			{
				_orders[good].Count += count;
			}

			_orders[good] = new GoodOrder(good, count);
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
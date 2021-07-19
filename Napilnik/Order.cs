using System.Collections.Generic;

public class UserOrder
{
	public string Paylink => "Random Paylink";
	public IReadOnlyList<GoodOrder> Orders => _orders;
	private List<GoodOrder> _orders;

	public UserOrder(List<GoodOrder> orders)
	{
		_orders = orders;
	}
}

public class GoodOrder
{
	public Good good;
	public int count;

	public GoodOrder(Good good, int count)
	{
		this.good = good;
		this.count = count;
	}
}
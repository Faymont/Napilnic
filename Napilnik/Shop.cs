using System;

public class Shop
{
	private readonly Warehouse _warehouse;

	public Shop(Warehouse warehouse)
	{
		_warehouse = warehouse ?? throw new NullReferenceException(nameof(warehouse));
	}

	public Cart Cart()
	{
		return new Cart(this);
	}

	public bool Contain(Good good, int count)
	{
		return _warehouse.Contain(good, count);
	}

	public void GetGood(Good good, int count)
	{
		_warehouse.GetGood(good, count);
	}
}
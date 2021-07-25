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

	public bool Contains(Good good, int count)
	{
		return _warehouse.Contain(good, count);
	}

	public void ReserveGood(Good good, int count)
	{
		_warehouse.ReserveGood(good, count);
	}
}
using System;
using System.Collections.Generic;

public class Warehouse
{
	private Dictionary<string, int> _goods;
	public IReadOnlyDictionary<string, int> Goods => _goods;

	public Warehouse()
	{
		_goods = new Dictionary<string, int>();
	}

	public void Deliver(Good good, int count)
	{
		ValidateArguments(good, count);

		var id = good.Id;
		if (_goods.ContainsKey(id))
		{
			_goods[id] += count;
		}

		_goods[id] = count;
	}

	public void GetGood(Good good, int count)
	{
		ValidateArguments(good, count);

		var id = good.Id;
		if (count > _goods[id])
			throw new ArgumentException(nameof(count));

		_goods[good.Id] -= count;
	}

	public bool Contain(Good good, int count)
	{
		ValidateArguments(good, count);
		if (_goods.TryGetValue(good.Id, out var goodCount))
		{
			return count <= goodCount;
		}

		return false;
	}


	private void ValidateArguments(Good good, int count)
	{
		if (good == null)
			throw new NullReferenceException(nameof(good));

		if (count <= 0)
			throw new ArgumentException(nameof(count));
	}
}
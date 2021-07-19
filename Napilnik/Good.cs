using System;

public class Good
{
	public readonly string Id;

	public Good(string id)
	{
		if (string.IsNullOrWhiteSpace(id))
			throw new ArgumentException(nameof(id));

		Id = id;
	}
}
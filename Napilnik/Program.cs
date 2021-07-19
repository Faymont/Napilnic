using System;

public class Program
{
	private static void Main()
	{
		Good iPhone12 = new Good("IPhone 12");
		Good iPhone11 = new Good("IPhone 11");

		Warehouse warehouse = new Warehouse();

		Shop shop = new Shop(warehouse);

		warehouse.Deliver(iPhone12, 10);
		warehouse.Deliver(iPhone11, 1);

		//Вывод всех товаров на складе с их остатком

		Cart cart = shop.Cart();
		cart.Add(iPhone12, 4);
		cart.Add(iPhone11, 3); //при такой ситуации возникает ошибка так, как нет нужного количества товара на складе

		//Вывод всех товаров в корзине

		Console.WriteLine(cart.Order().Paylink);
		Console.ReadKey();
	}
}
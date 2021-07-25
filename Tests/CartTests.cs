using System;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
	public class CartTests
	{
		[Test]
		public void WhenCreate_AndShopIsNull_ThenRaiseNullReferenceException()
		{
			// Arrange.

			// Act.
			Action act = () => new Cart(null);

			// Assert.
			act.Should().Throw<NullReferenceException>();
		}


		[Test]
		public void WhenCheckOrder_AndGoodsAdded_ThenGoodsShouldExistInOrder()
		{
			// Arrange.
			Good good = new Good("test");
			Warehouse warehouse = new Warehouse();
			warehouse.Deliver(good, 5);
			Shop shop = new Shop(warehouse);

			Cart cart = new Cart(shop);

			// Act.
			cart.Add(good, 1);
			var order = cart.Order();

			// Assert.
			order.Orders.Count.Should().Be(1);
		}

		[Test]
		public void WhenCheckOrder_AndGoodsDoesntExist_ThenGoodsShouldNotExistInOrder()
		{
			// Arrange.
			Good good = new Good("test");
			Good good2 = new Good("test2");
			Warehouse warehouse = new Warehouse();
			warehouse.Deliver(good, 5);
			Shop shop = new Shop(warehouse);

			Cart cart = new Cart(shop);

			// Act.
			cart.Add(good2, 1);
			var order = cart.Order();

			// Assert.
			order.Orders.Count.Should().Be(0);
		}
	}
}
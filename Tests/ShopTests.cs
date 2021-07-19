using System;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
	public class ShopTests
	{
		[Test]
		public void WhenCreate_AndWareHouseIsNull_ThenShouldNullReferenceException()
		{
			// Arrange.

			// Act.
			Action act = () => new Shop(null);

			// Assert.
			act.Should().Throw<NullReferenceException>();
		}

		
		
		[Test]
		public void WhenCheckContain_AndGoodsExist_ThenShouldBeTrue()
		{
			// Arrange.
			Good good = new Good("test");
			Warehouse warehouse = new Warehouse();
			warehouse.Deliver(good, 5);
			Shop shop = new Shop(warehouse);

			// Act.
			var isContain = shop.Contain(good, 1);

			// Assert.
			isContain.Should().Be(true);
		}

		[Test]
		public void WhenCheckContains_AndAllGoodsGetted_ThenShouldBeFalse()
		{
			// Arrange.
			Good good = new Good("test");
			Warehouse warehouse = new Warehouse();
			warehouse.Deliver(good, 5);
			Shop shop = new Shop(warehouse);

			// Act.
			shop.GetGood(good, 5);
			var isContain = shop.Contain(good, 1);

			// Assert.
			isContain.Should().Be(false);
		}

		[Test]
		public void WhenGetCart_AndCartExist_ThenShouldBeTrue()
		{
			// Arrange.
			Good good = new Good("test");
			Warehouse warehouse = new Warehouse();
			warehouse.Deliver(good, 5);
			Shop shop = new Shop(warehouse);

			// Act.
			var cart = shop.Cart();

			// Assert.
			cart.Should().NotBeNull();
		}

	}
}
using System;
using FluentAssertions;
using NUnit.Framework;
using System.Reflection;

namespace Tests
{
	public class WarehouseTests
	{
		[Test]
		[TestCase("Contain")]
		[TestCase("GetGood")]
		[TestCase("Deliver")]
		public void WhenTestMethodsWhichAcceptGoodsAndCount_AndGoodIsNull_ThenRaiseNullReferenceException(string methodName)
		{
			// Arrange.
			Warehouse warehouse = new Warehouse();
			Good good = null;
			var method = warehouse.GetType().GetMethod(methodName);

			// Act.
			Action act = () => method.Invoke(warehouse, new object[] {good, 1});

			// Assert.
			act.Should().Throw<TargetInvocationException>().WithInnerException<NullReferenceException>();
		}

		[Test]
		[TestCase("Contain")]
		[TestCase("GetGood")]
		[TestCase("Deliver")]
		public void WhenTestMethodsWhichAcceptGoodsAndCount_AndGoodCountsZeroOrNegative_ThenRaiseArgumentException(string methodName)
		{
			// Arrange.
			Warehouse warehouse = new Warehouse();
			Good good = new Good("test");
			var method = warehouse.GetType().GetMethod(methodName);

			// Act.
			Action act = () => method.Invoke(warehouse, new object[] {good, -1});


			// Assert.
			act.Should().Throw<TargetInvocationException>().WithInnerException<ArgumentException>();
		}

		[Test]
		public void WhenCheckContain_AndGoodsExist_ThenShouldBeTrue()
		{
			// Arrange.
			Warehouse warehouse = new Warehouse();
			Good good = new Good("test");

			// Act.
			warehouse.Deliver(good, 10);
			var contain = warehouse.Contain(good, 10);

			// Assert.
			contain.Should().Be(true);
		}

		[Test]
		public void WhenCheckContain_AndGoodsCountDoesNotExist_ThenShouldBeFalse()
		{
			// Arrange.
			Warehouse warehouse = new Warehouse();
			Good good = new Good("test");

			// Act.
			warehouse.Deliver(good, 10);
			var contain = warehouse.Contain(good, 100);

			// Assert.
			contain.Should().Be(false);
		}

		[Test]
		public void WhenDeliver_AndGoodsExist_ThenShouldBeTrue()
		{
			// Arrange.
			Warehouse warehouse = new Warehouse();
			Good good = new Good("test");

			// Act.
			warehouse.Deliver(good, 10);

			// Assert.
			warehouse.Goods.ContainsKey(good.Id).Should().Be(true);
		}

		[Test]
		public void WhenGetGood6Goods_And10GoodsExits_ThenShouldBe4()
		{
			// Arrange.
			Warehouse warehouse = new Warehouse();
			Good good = new Good("test");
			warehouse.Deliver(good, 10);

			// Act.
			warehouse.ReserveGood(good, 4);

			// Assert.
			warehouse.Goods[good.Id].Should().Be(6);
		}

		[Test]
		public void WhenDeliver_AndDeliverMoreGoodsThanExist_ThenRaiseArgumentException()
		{
			// Arrange.
			Warehouse warehouse = new Warehouse();
			Good good = new Good("test");
			warehouse.Deliver(good, 10);

			// Act.
			Action act = () => warehouse.ReserveGood(good, 15);

			// Assert.
			act.Should().Throw<ArgumentException>();
		}
	}
}
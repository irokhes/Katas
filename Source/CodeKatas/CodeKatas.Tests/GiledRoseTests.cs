using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace CodeKatas.Tests
{
    [TestFixture]
    public class GiledRoseTests
    {
        [Test]
        public void When_UpdateItem_SellIn_and_quality_decrease()
        {
            //Arrange
            var _items = new List<GildedRose.Item>
            {
                
                new GildedRose.Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new GildedRose.Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };
            var gildedRose = new GildedRose(_items);
            
            //Act
            gildedRose.UpdateQuality();

            //Assert
            Assert.AreEqual(_items.First().SellIn,4);
            Assert.AreEqual(_items.First().Quality,6);
            Assert.AreEqual(_items.Last().SellIn,2);
            Assert.AreEqual(_items.Last().Quality,5);

        }

        [Test]
        public void When_sell_by_date_passed_quality_decrease_twice_as_fast()
        {
            //Arrange
            var _items = new List<GildedRose.Item>
            {
                
                new GildedRose.Item {Name = "Elixir of the Mongoose", SellIn = 0, Quality = 8},
                new GildedRose.Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };
            var gildedRose = new GildedRose(_items);

            //Act
            gildedRose.UpdateQuality();

            //Assert
            Assert.AreEqual(6,_items.First().Quality);
        }

        [Test]
        public void When_quality_is_zero_is_not_decrease()
        {
            //Arrange
            var _items = new List<GildedRose.Item>
            {
                
                new GildedRose.Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 0},
                
            };
            var gildedRose = new GildedRose(_items);

            //Act
            gildedRose.UpdateQuality();

            //Assert
            Assert.AreEqual(0,_items.First().Quality);
        }
    }
}

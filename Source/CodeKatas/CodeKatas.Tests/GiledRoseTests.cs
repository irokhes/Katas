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

        [Test]
        public void When_special_product_increase_quality()
        {
            //Arrange
            var _items = new List<GildedRose.Item>
            {
                
                new GildedRose.Item {Name = "Aged Brie", SellIn = 5, Quality = 20},
                
            };
            var gildedRose = new GildedRose(_items);

            //Act
            gildedRose.UpdateQuality();


            //Assert
            Assert.AreEqual(21,_items.First().Quality);
        }

        [Test]
        public void When_quality_never_exceed_fifty()
        {
            //Arrange
            var _items = new List<GildedRose.Item>
            {
                
                new GildedRose.Item {Name = "Aged Brie", SellIn = 5, Quality = 50},
                
            };
            var gildedRose = new GildedRose(_items);

            //Act
            gildedRose.UpdateQuality();


            //Assert
            Assert.AreEqual(50, _items.First().Quality);
        }

        [Test]
        public void When_sulfuras_never_has_to_be_sold_or_decrease_quality()
        {
            //Arrange
            var _items = new List<GildedRose.Item>
            {
                
                new GildedRose.Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 40},
                
            };
            var gildedRose = new GildedRose(_items);

            //Act
            gildedRose.UpdateQuality();


            //Assert
            Assert.AreEqual(40, _items.First().Quality);
            Assert.AreEqual(5, _items.First().SellIn);
        }

        [Test]
        public void When_updating_quality_back_stage_tickets_and_SellIn_greater_than_10()
        {
            //Arrange
            var _items = new List<GildedRose.Item>
            {
                
                new GildedRose.Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 12, Quality = 40},
                
            };
            var gildedRose = new GildedRose(_items);

            //Act
            gildedRose.UpdateQuality();


            //Assert
            Assert.AreEqual(41, _items.First().Quality);
            
        }

        [Test]
        public void When_updating_quality_back_stage_tickets_and_SellIn_between_10_and_5()
        {
            //Arrange
            var _items = new List<GildedRose.Item>
            {
                
                new GildedRose.Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 8, Quality = 40},
                
            };
            var gildedRose = new GildedRose(_items);

            //Act
            gildedRose.UpdateQuality();


            //Assert
            Assert.AreEqual(42, _items.First().Quality);

        }

        [Test]
        public void When_updating_quality_back_stage_tickets_and_SellIn_less_than_5()
        {
            //Arrange
            var _items = new List<GildedRose.Item>
            {
                
                new GildedRose.Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 3, Quality = 40},
                
            };
            var gildedRose = new GildedRose(_items);

            //Act
            gildedRose.UpdateQuality();


            //Assert
            Assert.AreEqual(43, _items.First().Quality);

        }

        [Test]
        public void When_updating_quality_back_stage_tickets_and_SellIn_passed()
        {
            //Arrange
            var _items = new List<GildedRose.Item>
            {
                
                new GildedRose.Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 40},
                
            };
            var gildedRose = new GildedRose(_items);

            //Act
            gildedRose.UpdateQuality();


            //Assert
            Assert.AreEqual(0, _items.First().Quality);

        }

        
    }
}

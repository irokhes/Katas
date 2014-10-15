using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

namespace CodeKatas.GiledRoseKata
{
    public class GildedRose
    {
        private IList<Item> _items;

        private StrategryFactory strategryFactory;


        public GildedRose(IList<Item> items = null)
        {
            _items = items ?? new List<Item>
            {
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 },
                new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
            };

            strategryFactory = new StrategryFactory();

        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                var strategy = strategryFactory.GetQualityStrategy(item);
                strategy.UpdateQuality();
            }
        }
        //public void UpdateQuality()
        //{
        //    for (var i = 0; i < _items.Count; i++)
        //    {
        //        if (_items[i].Name == "Conjured")
        //        {
        //            _items[i].Quality -= 2;
        //            return;
        //        }
        //        if (_items[i].Name != "Aged Brie" && _items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
        //        {
        //            if (_items[i].Quality > 0)
        //            {
        //                if (_items[i].Name != "Sulfuras, Hand of Ragnaros")
        //                {
        //                    _items[i].Quality = _items[i].Quality - 1;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            if (_items[i].Quality < 50)
        //            {
        //                _items[i].Quality = _items[i].Quality + 1;

        //                if (_items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
        //                {
        //                    if (_items[i].SellIn < 11)
        //                    {
        //                        if (_items[i].Quality < 50)
        //                        {
        //                            _items[i].Quality = _items[i].Quality + 1;
        //                        }
        //                    }

        //                    if (_items[i].SellIn < 6)
        //                    {
        //                        if (_items[i].Quality < 50)
        //                        {
        //                            _items[i].Quality = _items[i].Quality + 1;
        //                        }
        //                    }
        //                }
        //            }
        //        }

        //        if (_items[i].Name != "Sulfuras, Hand of Ragnaros")
        //        {
        //            _items[i].SellIn = _items[i].SellIn - 1;
        //        }

        //        if (_items[i].SellIn < 0)
        //        {
        //            if (_items[i].Name != "Aged Brie")
        //            {
        //                if (_items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
        //                {
        //                    if (_items[i].Quality > 0)
        //                    {
        //                        if (_items[i].Name != "Sulfuras, Hand of Ragnaros")
        //                        {
        //                            _items[i].Quality = _items[i].Quality - 1;
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    _items[i].Quality = _items[i].Quality - _items[i].Quality;
        //                }
        //            }
        //            else
        //            {
        //                if (_items[i].Quality < 50)
        //                {
        //                    _items[i].Quality = _items[i].Quality + 1;
        //                }
        //            }
        //        }
        //    }
        //}

        public class Item
        {
            public string Name { get; set; }

            public int SellIn { get; set; }

            public int Quality { get; set; }
        }
    }

    public class StrategryFactory
    {
        public IQualityStrategy GetQualityStrategy(GildedRose.Item item)
        {
            if (item.Name == "Conjured")
                return new DecreaseTwiceQualityStrategy(item);

            if (item.Name.Contains("Backstage passes"))
                return new BackstageQualityStrategy(item);

            if (item.Name.Contains("Sulfuras"))
                return new NotDecreaseQualityStrategy(item);

            if (item.Name.Contains("Aged Brie"))
                return new IncreaseQualityStrategy(item);

            return new StandardQualityStrategy(item);


        }
    }

    public interface IQualityStrategy
    {
        GildedRose.Item _item { get; set; }
        void UpdateQuality();
    }

    public class StandardQualityStrategy : IQualityStrategy
    {
        public StandardQualityStrategy(GildedRose.Item item)
        {
            _item = item;
        }
        public void UpdateQuality()
        {
            if (_item.SellIn <= 0)
            {
                _item.Quality = _item.Quality - 2 >= 0 ? _item.Quality - 2 : 0;

            }
            else
            {
                if(_item.Quality > 0)_item.Quality--;
            }

            _item.SellIn--;

        }


        public GildedRose.Item _item { get; set; }


    }

    public class IncreaseQualityStrategy : IQualityStrategy
    {
        public GildedRose.Item _item { get; set; }

        public IncreaseQualityStrategy(GildedRose.Item item)
        {
            _item = item;
        }

        public void UpdateQuality()
        {
            if (_item.Quality < 50) _item.Quality++;
            _item.SellIn--;
        }
    }

    public class NotDecreaseQualityStrategy : IQualityStrategy
    {
        public NotDecreaseQualityStrategy(GildedRose.Item item)
        {
            _item = item;
        }
        public void UpdateQuality()
        {
            return;
        }

        public GildedRose.Item _item { get; set; }

    }

    public class BackstageQualityStrategy : IQualityStrategy
    {
        public BackstageQualityStrategy(GildedRose.Item item)
        {
            _item = item;
        }
        public void UpdateQuality()
        {
            if (_item.SellIn <= 0)
                _item.Quality = 0;
            else if (_item.SellIn <= 5)
                _item.Quality = _item.Quality + 3 <= 50 ? _item.Quality + 3 : 50;
            else if (_item.SellIn <= 10)
                _item.Quality = _item.Quality + 2 <= 50 ? _item.Quality + 2 : 50;
            else
                if (_item.Quality < 50) _item.Quality++;

            _item.SellIn--;
        }

        public GildedRose.Item _item { get; set; }

    }

    public class DecreaseTwiceQualityStrategy : IQualityStrategy
    {
        public DecreaseTwiceQualityStrategy(GildedRose.Item item)
        {
            _item = item;
        }

        public void UpdateQuality()
        {
            _item.Quality = _item.Quality - 2 >= 0 ? _item.Quality - 2 : 0;
            _item.SellIn--;
        }

        public GildedRose.Item _item { get; set; }

    }
}

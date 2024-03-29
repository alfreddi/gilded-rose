﻿using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

       
            public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {

                    if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (Items[i].Quality > 0)
                        {
                            Items[i].Quality--;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50 && Items[i].Name != "Conjured Mana Cake")
                        {
                            Items[i].Quality++;

                            if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                            {
                                if (Items[i].SellIn <= 10)
                                {
                                    if (Items[i].Quality < 50)
                                    {
                                        Items[i].Quality = Items[i].Quality + 1;
                                    }
                                }

                                if (Items[i].SellIn <= 5)
                                {
                                    if (Items[i].Quality < 50)
                                    {
                                        Items[i].Quality = Items[i].Quality + 1;
                                    }
                                }
                            }
                        }
                    }

                    Items[i].SellIn--;

                    if (Items[i].SellIn < 0)
                    {
                        if (Items[i].Name != "Aged Brie")
                        {
                            if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                            {
                                if (Items[i].Quality > 0)
                                {
                                    Items[i].Quality--;
                                }
                            }
                            else if (Items[i].Name == "Conjured Mana Cake")
                            {
                                Items[i].Quality -= 2;
                            }
                            else
                            {
                                Items[i].Quality = 0;
                            }
                        }
                        else
                        {
                            if (Items[i].Quality < 50)
                            {
                                Items[i].Quality++;
                            }
                        }
                    }
                }
            }
        }
    }
}

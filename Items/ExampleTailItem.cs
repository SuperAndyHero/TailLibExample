using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using TailLib;
using TailLibExample.Tails;

namespace TailLibExample.Items
{
    public class ExampleTailItem : TailItem
    {
        public ExampleTailItem() : base(typeof(ExampleTail)) { }//also try LeopardTail and BannerTail

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Example Tail");
            Tooltip.SetDefault("This can be equiped on your player");
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = 1000;
            Item.accessory = true;
            Item.rare = ItemRarityID.Green;
        }

        //use this instead of UpdateEquip()
        //public override bool SafeUpdateEquip(Player player)
        //{
        //    return true;//return false to disable the tail
        //}

        //you can also do  player.GetModPlayer<TailPlayer>().CurrentTailType = typeof(ExampleTail);  to set the tail yourself, it accepts a Type
    }
}
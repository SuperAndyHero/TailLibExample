using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using TailLib;
using Terraria;
using Terraria.ModLoader;

namespace TailLibExample.Tails
{
    public class BannerTail : Tailbase
    {
        //this tail was just made to text a banner, shows using tails for other things, and applying a custom gravity direction
        public override string Texture => "TailLibExample/Tails/Banner";
        public override Vector2 TexPosOffset => new Vector2(0, -2.25f);
        public override Vector2 TexSizeOffset => new Vector2(-6f, 1.25f);
        public override int VertexCount => 40;
        public override int VertexDistance => 4;
        public override int Width => 9;
        public override int PhysicsRepetitions => 10;
        public override float VertexDrag => 1.15f;

        public override Vector2 WorldOffset => new Vector2(0f, 0f);

        public override bool SpineEnabled => false;

        //public override Color GeometryColor(int index)
        //{
        //    return base.GeometryColor(index);
        //}

        public override Vector2 VertexGravityForce => Vector2.UnitX;
    }
}
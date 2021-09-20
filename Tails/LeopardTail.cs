using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using TailLib;
using Terraria;
using Terraria.ModLoader;
//using ChangedMod.Core;

namespace TailLibExample.Tails
{
    public class LeopardTail : Tailbase
    {
        //this tail is from a mod im working on, and is one of the first I made, this shows a finalized tail as you would see in a mod
        //this is from before the verletchain tool existed and thus the gravity values are done by hand (use the chain tool instead, by hand took an hour)
        //https://github.com/SuperAndyHero/VerletChainAlgo

        public override string Texture => "TailLibExample/Tails/Leopard";
        public override Vector2 TexPosOffset => new Vector2(0, -3f);
        public override Vector2 TexSizeOffset => new Vector2(8f, 2.5f);
        public override int VertexCount => 7;
        public override int VertexDistance => 5;
        public override int Width => 8;
        public override int PhysicsRepetitions => 5;
        public override float VertexDrag => 1.15f;

        public override Vector2 WorldOffset => new Vector2(4f, 9.5f);

        public override bool PreUpdate()
        {
            tailInstance.UpwardsTurn();
            tailInstance.TailWobble();
            return true;
        }


        /* original point list
        0,0
        1,0
        0.7,0.4
        0.3,0.6
        0.23,0.64
        0.47,0.46
        0.8,0.3
        */

        public override Vector2[] VertexGravityForces => new Vector2[] {
                new Vector2(0, 0),
                new Vector2(1f, 0.6f) * 12,
                new Vector2(0.4f, 0.4f) * 8,
                new Vector2(0.15f, -0.6f) * 6,
                new Vector2(0.1f, -0.54f) * 4,
                new Vector2(0.3f, -0.46f) * 2,
                new Vector2(0.5f, -0.1f) };

        public override Vector2[] SettledPoints => new Vector2[] {
                new Vector2(0, 0),
                new Vector2(5.417969f, -1.70459f),
                new Vector2(9.796875f, -5.126953f),
                new Vector2(12.78125f, -9.679199f),
                new Vector2(15.41406f, -14.2334f),
                new Vector2(19.05859f, -17.79736f),
                new Vector2(23.91016f, -19.00098f) };
    }
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft;
using System.Collections.Generic;
using TailLib;
using Terraria;
using Terraria.ModLoader;

namespace TailLibExample.Tails
{
    public class ExampleTail : Tailbase
    {
        //use a blank filled sprite (like Main.blackTileTexture) and you will be able to see the full size of the tail
        public override string Texture => "TailLibExample/Tails/ExampleTail";

        public override int VertexCount => 9;

        public override int Width => 9;//the horizontal width starting at the vertex chain

        public override int VertexDistance => 9;//base distance between each vertex
        public override int[] VertexDistances => new int[] { 11, 10, 10, 9, 9, 9, 9, 10, 9 };//for setting the distances between each vertex

        public override int PhysicsRepetitions => 5;//how many times the physics should be run, keep this between 3 and 10, more repetitions will make it snappier but will use more performace
        public override float VertexDrag => 1.03f;//how much drag the tail will experiance, minimum is 1.0f

        public override Vector2 TexPosOffset => new Vector2(0, 4f);//for offseting the texture on the tail (use this to align the sprite with the spine)
        public override Vector2 TexSizeOffset => new Vector2(8f, 8f);//for scaling the texture on the tail (use this to scale the sprite if its too small
        public override Vector2 WorldOffset => new Vector2(4f, 12.5f);//offset for where this is anchored to on the player


        public override bool PreUpdate()
        {
            //tailInstance.UpwardsTurn();//this gives the tail upwards momentum when turning, just for better visual effect
            tailInstance.TailWobble(7, 9, 0.05f, 0.2f, 0.1f, 0.12f);//wobbles the tail when idle or running

            //foreach (RopeSegment seg in tailInstance.tailBones.ropeSegments)//this bit of commented out code prints the relative points of each vertex in chat for use in the settled points array
            //{//the chain tool can produce these same values in a easier to copy format
            //    Main.NewText(tailInstance.tailBones.startPoint - seg.posNow);
            //}
            return true;
        }

        public override bool SpriteDirection() => //this helps you change when the texture will swap, try and swap it when the vertex farthest from the player crosses
            (tailInstance.tailBones.ropeSegments[0].posNow.X > tailInstance.tailBones.ropeSegments[VertexCount / 2].posNow.X);//thos copies the normal behaviour but with a different index


        public override Color GeometryColor(int index)//this lets you recolor the tail (and allows different colors per vertex, and smooth blending between them)
        {   //this can also be used to have animated colors
            float amount = (1f / (VertexCount - 1)) * (float)index; 
            return new Color(1 - amount, 1f, 1 - amount);
        }

        //these two are suggested to be calculated externally, see this for a tool I made to do it: https://github.com/SuperAndyHero/VerletChainAlgo
        public override Vector2[] VertexGravityForces => new Vector2[] {
                new Vector2(0, 0),

                new Vector2(2.521378f, -0.23860645f),

                new Vector2(1.8771666f, 0.6946875f),

                new Vector2(1.7592676f, 1.254774f),

                new Vector2(1.8787113f, 0.69561416f),

                new Vector2(2.0807614f, -3.7615845f),

                new Vector2(-1.9505557f, -1.9595878f),

                new Vector2(-3.3457003f, 0.5178663f),

                new Vector2(0.7665831f, 1.8476393f) 
        };
        public override Vector2[] SettledPoints => new Vector2[] {
                new Vector2(0, 0),
                new Vector2(11.195404f, -2.0455322f),
                new Vector2(20.988342f, -4.9955597f),
                new Vector2(27.090912f, -13.100754f),
                new Vector2(25.021973f, -21.996017f),
                new Vector2(18.5672f, -28.344666f),
                new Vector2(9.580963f, -27.468414f),
                new Vector2(3.147461f, -21.169205f),
                new Vector2(6.095154f, -11.61351f)
        };


        //these two are both useful for debugging and other visual effects
        public override bool SpineEnabled => false;//this draws a line between the verticies, this may be desired for the tail, and is useful for texting
        //public override void DrawSprites(SpriteBatch spriteBatch)//this method lets you draw sprites on the tail, this code here draws squares on each vertex
        //{//this could be adapted to only draw a sprite at the end
        //    Texture2D tex = Main.blackTileTexture;
        //    foreach (RopeSegment seg in tailInstance.tailBones.ropeSegments)
        //        spriteBatch.Draw(tex, seg.ScreenPos, null, Color.LightGreen, 0, tex.Size() / 2, 0.15f, SpriteEffects.None, 0);
        //}

        //public override bool GeometryEnabled => true;//should the sprite geometry be drawn, disable if your tail only uses DrawSprites() and/or SpineEnabled

        //A hook for very advanced visuals, this lets you draw your own custom geometry
        //public override void PreDrawGeometry(BasicEffect effect, EffectPass pass, GraphicsDevice graphicsDevice)
        //{
        //    base.PreDrawGeometry(effect, pass, graphicsDevice);
        //}
    }
}
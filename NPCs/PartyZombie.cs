using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TailLib;

namespace TailLibExample.NPCs
{
    public class PartyZombie : TailNpc//this is the example mod zombie but with a tail, you dont have to extend from tailnpc if you set it yourself (see below)
    {
        public PartyZombie() : base(typeof(Tails.LeopardTail)) { }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Test Zombie");
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Zombie];
        }

        public override void SetDefaults()
        {
            NPC.width = 18;
            NPC.height = 40;
            NPC.damage = 14;
            NPC.defense = 6;
            NPC.lifeMax = 200;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath2;
            NPC.value = 60f;
            NPC.knockBackResist = 0.5f;
            NPC.aiStyle = 3;
            AIType = NPCID.Zombie;
            AnimationType = NPCID.Zombie;
            Banner = Item.NPCtoBanner(NPCID.Zombie);
            BannerItem = Item.BannerToItem(Banner);
        }

        //to set a tail yourself do  npc.SetTail(typeof(LeopardTail));

        //public override bool SafeAI()//use this instead of AI()
        //{
        //    return true;//return true to disable the tail (npc.TailActive(SafeAI()) also works as a way to disable/enable a npc's tail, just make sure its set first)
        //}
    }
}

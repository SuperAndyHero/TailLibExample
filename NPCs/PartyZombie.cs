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
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie];
        }

        public override void SetDefaults()
        {
            npc.width = 18;
            npc.height = 40;
            npc.damage = 14;
            npc.defense = 6;
            npc.lifeMax = 200;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.value = 60f;
            npc.knockBackResist = 0.5f;
            npc.aiStyle = 3;
            aiType = NPCID.Zombie;
            animationType = NPCID.Zombie;
            banner = Item.NPCtoBanner(NPCID.Zombie);
            bannerItem = Item.BannerToItem(banner);
        }

        //to set a tail yourself do  npc.SetTail(typeof(LeopardTail));

        //public override bool SafeAI()//use this instead of AI()
        //{
        //    return true;//return true to disable the tail (npc.TailActive(SafeAI()) also works as a way to disable/enable a npc's tail, just make sure its set first)
        //}
    }
}

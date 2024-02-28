using TheGrotto.Core.Overrides;

namespace TheGrotto.Content.NPCs.VanillaOverrides {
    public class Bats : VanillaNPCOverride {

        public bool Alerted;

        public bool IsSleeping(NPC npc) => npc.ai[0] == 1 && !Alerted;

        public override object NPCTypes => new int[] {
            NPCID.CaveBat,
            NPCID.IceBat,
            //Mod.Find<ModNPC>("DuskBat").Type
        };

        public override void SetStaticDefaults() {
            Main.npcFrameCount[NPCID.IceBat] = 6;
            //Main.npcFrameCount[NPCID.CaveBat] = 4;
        }

        public override void FindFrame(NPC npc, int frameHeight) {
            
        }
    }
}

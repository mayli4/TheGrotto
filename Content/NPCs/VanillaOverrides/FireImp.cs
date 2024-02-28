using TheGrotto.Core.Overrides;

namespace TheGrotto.Content.NPCs.VanillaOverrides {
    //fuck this fucking thing oh my god
    public class FireImp : VanillaNPCOverride {
        public override object NPCTypes => NPCID.FireImp;

        //public override bool CanHitPlayer(NPC npc, Player target, ref int cooldownSlot) => false;

        public override void SetStaticDefaults() {
            
        }

        public override void SetDefaults(NPC entity) {
            
        }

        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
            => spawnRate = 0;
    }
}

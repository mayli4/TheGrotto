namespace TheGrotto.Content.NPCs {
    public class WormNPC : NPCOverride {
        public override object NPCTypes => NPCID.Worm;

        public override void SetDefaults(NPC entity) {
            
        }

        public override void SetStaticDefaults() {

        }

        public override void AI(NPC npc) {
            npc.dontTakeDamage = true;
            npc.townNPC = true;
        }
    }
}

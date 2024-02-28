using Terraria.GameContent.Bestiary;

namespace TheGrotto.Content.NPCs.Hostile.Nighttime {
    public class DuskBat : ModNPC {
        public override string Texture => AssetDirectory.HostileNPCs + "Nighttime/DuskBat";

        public override void SetStaticDefaults() {
            Main.npcFrameCount[NPC.type] = 5;
        }

        public override void SetDefaults() {
            NPC.life = 30;
            NPC.width = 44;
            NPC.height = 36;
            NPC.spriteDirection = NPC.direction;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,
                new FlavorTextBestiaryInfoElement("placeholder")
            });
        }

        public override void FindFrame(int frameHeight) {
            
        }

    }
}

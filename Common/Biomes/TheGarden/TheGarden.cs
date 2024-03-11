namespace TheGrotto.Common.Biomes.TheGarden {
    [LegacyName("TheGrotto")]
    public class TheGarden : ModBiome {
        public static bool onScreen;

        public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;
        public override ModUndergroundBackgroundStyle UndergroundBackgroundStyle => ModContent.Find<ModUndergroundBackgroundStyle>("TheGrotto/GardenUndergroundStyle");

        public override bool IsBiomeActive(Player player) {
            Rectangle biomeBox = GrottoWorld.gardenBiomeBounds;
            onScreen = GrottoWorld.gardenBiomeBounds.Intersects(new Rectangle((int)Main.screenPosition.X / 16, (int)Main.screenPosition.Y / 16, Main.screenWidth / 16, Main.screenHeight / 16));
            return biomeBox.Contains((player.Center / 16).ToPoint());
        }

        public override void OnEnter(Player player) {
            Main.NewText("In Garden");
            base.OnEnter(player);
        }

        public override void OnLeave(Player player) {
            Main.NewText("No longer in garden");
            base.OnLeave(player);
        }

    }
}

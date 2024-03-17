namespace TheGrotto.Content {
    public class DebugItem : ModItem {

        public override string Texture => "Terraria/Images/Item_10";

        public override void SetDefaults() {
            Item.damage = 10;
            Item.DamageType = DamageClass.Melee;
            Item.useTime = 18;

            Item.useAnimation = 18;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            var center = new Vector2(GrottoWorld.gardenBiomeBounds.Center.X, GrottoWorld.gardenBiomeBounds.Center.Y);
            Dust.NewDustPerfect(center, DustID.BlueFairy);

            WorldGen.PlaceTile((int)center.X, (int)center.Y, TileID.Dirt);

            base.UpdateAccessory(player, hideVisual);
        }

        public override bool? UseItem(Player player) {

            TheGardenWorldGen.GardenGenerationPass(default, default);

            return true;
        }

    }
}

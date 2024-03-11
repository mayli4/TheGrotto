using Terraria.Graphics.Light;

namespace TheGrotto.Common.Biomes.TheGarden {
    public class TheGardenSystem : GrottoSystem {

        public override void Load() {
            On_TrackGenerator.IsLocationInvalid += PreventRailsFromGenerating;
            On_TileLightScanner.GetTileLight += GardenLighting;
        }

        private void GardenLighting(On_TileLightScanner.orig_GetTileLight orig, TileLightScanner self, int x, int y, out Vector3 outputColor) {
            orig(self,x, y, out outputColor);

            
            if(GrottoWorld.gardenBiomeBounds.Contains(x, y)) {
                Tile tile = Main.tile[x, y];
                bool tileBlock = tile.HasTile && Main.tileBlockLight[tile.TileType] && !(tile.Slope != SlopeType.Solid || tile.IsHalfBlock);
                bool wallBlock = Main.wallLight[tile.WallType];
                bool lava = tile.LiquidType == LiquidID.Lava;
                bool lit = Main.tileLighted[tile.TileType];

                if(!tileBlock && wallBlock && !lava && !lit) {
                    outputColor += new Vector3(0.24f, 0.31f, 0.19f) * 1.25f;
                }

            }
        }

        private bool PreventRailsFromGenerating(On_TrackGenerator.orig_IsLocationInvalid orig, int x, int y) {
            if(IsValidForRails(x, y))
                return orig(x, y);
            return true;
        }




        public bool IsValidForRails(int i, int j) {
            var rect = GrottoWorld.gardenBiomeBounds;
            if(ContainsCoordinates(rect, i, j))
                return false;
            return true;
        }

        public bool ContainsCoordinates(Rectangle rect, int x, int y) {
            if(x >= rect.Left && x <= rect.Right && y >= rect.Top && y <= rect.Bottom)
                return true;
            return false;
        }
    }
}

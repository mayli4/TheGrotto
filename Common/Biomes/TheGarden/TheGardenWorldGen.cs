namespace TheGrotto.Common.Biomes.TheGarden {
    //should it be one big biome? or split into several smaller ones scattered throughout the world? idk ill decide later
    public class TheGardenWorldGen : GrottoSystem {

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight) {
            int index = tasks.FindIndex(genpass => genpass.Name.Equals("Micro Biomes"));
            if(index == -1) {
                return;
            }

            tasks.Insert(index + 1, new PassLegacy($"{nameof(TheGrotto)}::Garden", ClearTiles));
        }

        public static Rectangle bounds = new(Main.spawnTileX, 700, 128, 70);

        public static void ClearTiles(GenerationProgress progress, GameConfiguration configuration) {

            for(int i = bounds.X; i < bounds.X + bounds.Width; i++) {
                for(int j = bounds.Y; j < bounds.Y + bounds.Height; j++) {
                    WorldGen.KillTile(i, j);
                    WorldGen.KillWall(i, j);
                    WorldGen.EmptyLiquid(i, j);
                }
            }

            GrottoWorld.gardenBiomeBounds = bounds;

            var center = new Vector2(bounds.Center.X, bounds.Center.Y);

            WorldGen.PlaceTile((int)center.X, (int)center.Y, TileID.AmberGemspark);

        }
    }
}

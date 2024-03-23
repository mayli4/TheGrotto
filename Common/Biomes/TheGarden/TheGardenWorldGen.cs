namespace TheGrotto.Common.Biomes.TheGarden {
    //should it be one big biome? or split into several smaller ones scattered throughout the world? idk ill decide later
    //will continue work on this again once i have a more solid idea of what the biome should be
    public class TheGardenWorldGen : BaseSystem<TheGardenWorldGen> {

        public static Rectangle bounds = GrottoWorld.gardenBiomeBounds;

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight) {
            int index = tasks.FindIndex(genpass => genpass.Name.Equals("Terrain"));
            if(index == -1) {
                return;
            }

            tasks.Insert(index + 1, new PassLegacy("TheGrotto::Garden", GardenGenerationPass));

            //tasks.RemoveAll(x => x.Name != "TheGrotto::Garden");
        }

        public static void GardenGenerationPass(GenerationProgress progress, GameConfiguration configuration) {
            SpawnBiome(1);
        }

        public static void SpawnBiome(int biomeSize) {
            ClearTiles();
        }


        public static void ClearTiles() {
            for(int i = bounds.X; i < bounds.X + bounds.Width; i++) {
                for(int j = bounds.Y; j < bounds.Y + bounds.Height; j++) {
                    WorldGen.KillTile(i, j);
                    WorldGen.PlaceWall(i, j, WallID.Dirt);
                    WorldGen.EmptyLiquid(i, j);
                }
            }

            var center = new Vector2(bounds.Center.X, bounds.Center.Y);

            WorldGen.PlaceTile((int)center.X, (int)center.Y, TileID.AmberGemspark);

        }
    }
}

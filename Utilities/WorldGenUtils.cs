namespace TheGrotto.Utilities {
    public partial class Utils {

        public static readonly List<int> invalidTiles = new() {
            TileID.MinecartTrack,
            TileID.Hive,
            TileID.BlueDungeonBrick,
            TileID.PinkDungeonBrick,
            TileID.GreenDungeonBrick
        };

        public static bool IsRectangleSafe(Rectangle area, Func<Tile, Point16, bool> extraConstraints = null, bool extraConstraintsOnly = false) {
            for(int x = 0; x < area.Width; x++) {
                for(int y = 0; y < area.Height; y++) {
                    var pos = new Point16(area.X + x, area.Y + y);
                    Tile tile = Framing.GetTileSafely(pos);

                    if(extraConstraints != null && !extraConstraints(tile, pos))
                        return false;

                    if(!extraConstraintsOnly && !DefaultTileConstraints(tile, pos))
                        return false;
                }
            }
            return true;
        }
        private static bool DefaultTileConstraints(Tile tile, Point16 pos) {
            if(invalidTiles.Contains(tile.TileType))
                return false;

            if(TileEntity.ByPosition.ContainsKey(pos))
                return false;

            return true;
        }

    }
}

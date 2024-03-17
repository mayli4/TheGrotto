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

        public static void WavyArc(Point16 centerPoint, int radius, float freq, float amp, bool clearInside = true, float widthMult = 1, float increment = 2, float startRadian = 0, float endRadian = (float)Math.PI, byte waterLevel = 0, Action<int, int, float>? placement = null) {
            //if there is a passed in method to be run on each step
            bool onplace = placement != null;

            FastNoise fastnoise = new FastNoise(Main.rand.Next());//debug change rand later

            //step length
            float inc = (float)Math.Tau / (increment * radius * widthMult * (freq / 5f));

            for(float i = startRadian; i < endRadian; i += inc) {
                //distance from center
                Vector2 dist = new(radius * (1 + fastnoise.GetCubic(0, i * radius * freq) * amp), 0);
                //rotates distance to get position
                Vector2 pos = dist.RotatedBy(i, Vector2.Zero);

                //clearing inside
                if(clearInside) {
                    //raycasts from the middle
                    float clearLen = ((dist.X * widthMult));
                    for(float j = 0; j < clearLen; j += 0.75f) {
                        float multDist = j / clearLen;
                        int posX = (int)(centerPoint.X + ((pos.X * multDist) * widthMult));
                        int posY = (int)(centerPoint.Y + (pos.Y * multDist));
                        Main.tile[posX, posY].Get<TileWallWireStateData>().HasTile = false;
                        WorldGen.KillWall(posX, posY);
                        WorldGen.KillTile(posX,posY);
                        Main.tile[posX, posY].LiquidAmount = waterLevel;
                    }
                }
                if(onplace)
                    placement((int)(centerPoint.X + (pos.X * widthMult)), (int)(centerPoint.Y + pos.Y), i);
            }

        }
    }
}

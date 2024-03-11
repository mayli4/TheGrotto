namespace TheGrotto.Utilities {
    public partial class Utils {
        public static void DrawPixel(Vector2 pos, Color tint) => Main.spriteBatch.Draw(TextureAssets.MagicPixel.Value, pos, tint);
        public static void DrawLine(Vector2 p1, Vector2 p2, Color tint, float lineWidth = 1f) {

            float Dist = Vector2.Distance(p1, p2);
            for(float j = 0; j < 1; j += 1 / Dist) {
                Vector2 Lerped = p1 + j * (p2 - p1);
                DrawPixel(Lerped, tint);
            }


            Vector2 between = p2 - p1;
            float length = between.Length();
            float rotation = (float)Math.Atan2(between.Y, between.X);
            Main.spriteBatch.Draw(TextureAssets.MagicPixel.Value, p1, null, tint, rotation, new Vector2(0f, 0.5f), new Vector2(length, lineWidth), SpriteEffects.None, 0f);
        }

        public static void DrawLine(SpriteBatch sb, Vector2 p1, Vector2 p2, Color tint, float lineWidth = 1f) {
            Vector2 between = p2 - p1;
            float length = between.Length();
            float rotation = (float)Math.Atan2(between.Y, between.X);
            sb.Draw(TextureAssets.MagicPixel.Value, p1, null, tint, rotation, new Vector2(0f, 0.5f), new Vector2(length, lineWidth), SpriteEffects.None, 0f);
        }


        public static void DrawRectangle(Vector2 point, float sizeX, float sizeY, Color color) {
            DrawLine(new Vector2(point.X + sizeX, point.Y + sizeY), new Vector2(point.X, point.Y + sizeY), color);
            DrawLine(new Vector2(point.X + sizeX, point.Y + sizeY), new Vector2(point.X + sizeX, point.Y), color);
            DrawLine(point, new Vector2(point.X, point.Y + sizeY), color);
            DrawLine(point, new Vector2(point.X + sizeX, point.Y), color);
        }

        public static void DrawRectangle(Rectangle rectangle, Color color = default, float thickness = 1) {
            if(color == default) color = Color.White;

            Vector2 point = rectangle.Location.ToVector2();
            int sizeX = (int)rectangle.Size().X;
            int sizeY = (int)rectangle.Size().Y;
            DrawLine(new Vector2(point.X + sizeX, point.Y + sizeY), new Vector2(point.X, point.Y + sizeY), color, thickness);
            DrawLine(new Vector2(point.X + sizeX, point.Y + sizeY), new Vector2(point.X + sizeX, point.Y), color, thickness);
            DrawLine(point, new Vector2(point.X, point.Y + sizeY), color, thickness);
            DrawLine(point, new Vector2(point.X + sizeX, point.Y), color, thickness);
        }

    }
}

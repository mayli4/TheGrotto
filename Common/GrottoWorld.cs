namespace TheGrotto.Common {
    public class GrottoWorld : BaseSystem<GrottoWorld> {
        public static Rectangle gardenBiomeBounds = new(Main.spawnTileX, 700, 128, 70);
        public GrottoWorld() {

        }

        public override void Load() {
            base.Load();
        }

        public override void ClearWorld() {
            gardenBiomeBounds.X = 0;
            gardenBiomeBounds.Y = 0;

            base.ClearWorld();
        }

        #region saving and loading misc data

        public override void SaveWorldData(TagCompound tag) {
            tag["gardenBiomePos"] = gardenBiomeBounds.TopLeft();
            tag["gardenBiomeSize"] = gardenBiomeBounds.Size();

            base.SaveWorldData(tag);
        }

        public override void LoadWorldData(TagCompound tag) {
            gardenBiomeBounds.X = (int)tag.Get<Vector2>("gardenBiomePos").X;
            gardenBiomeBounds.Y = (int)tag.Get<Vector2>("gardenBiomePos").Y;
            gardenBiomeBounds.Width = (int)tag.Get<Vector2>("gardenBiomeSize").X;
            gardenBiomeBounds.Height = (int)tag.Get<Vector2>("gardenBiomeSize").Y;

            base.LoadWorldData(tag);
        }

        public override void NetSend(BinaryWriter writer) {
            WriteRect(writer, gardenBiomeBounds);
        }
        public override void NetReceive(BinaryReader reader) {
            gardenBiomeBounds = ReadRect(reader);
        }

        public void WriteRect(BinaryWriter writer, Rectangle rect) {
            writer.Write(rect.X); writer.Write(rect.Y);
            writer.Write(rect.Height); writer.Write(rect.Width);
        }
        public Rectangle ReadRect(BinaryReader reader) {
            return new Rectangle(reader.ReadInt32(), reader.ReadInt32(), 
                reader.ReadInt32(), reader.ReadInt32());
        }
        #endregion

    }
}

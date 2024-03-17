namespace TheGrotto.Common.Biomes.TheGarden {
    public class GardenUndergroundStyle : ModUndergroundBackgroundStyle {
        public override void FillTextureArray(int[] textureSlots) {
            textureSlots[0] = BackgroundTextureLoader.GetBackgroundSlot(Mod, "Assets/Images/Backgrounds/TheGardenUnderground0");
            textureSlots[1] = BackgroundTextureLoader.GetBackgroundSlot(Mod, "Assets/Images/Backgrounds/TheGardenUnderground1");
            textureSlots[2] = BackgroundTextureLoader.GetBackgroundSlot(Mod, "Assets/Images/Backgrounds/TheGardenUnderground2");
            textureSlots[3] = BackgroundTextureLoader.GetBackgroundSlot(Mod, "Assets/Images/Backgrounds/TheGardenUnderground3");
        }
    }
}

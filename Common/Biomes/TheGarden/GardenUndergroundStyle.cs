namespace TheGrotto.Common.Biomes.TheGarden {
    public class GardenUndergroundStyle : ModUndergroundBackgroundStyle {
        public override void FillTextureArray(int[] textureSlots) {
            textureSlots[0] = BackgroundTextureLoader.GetBackgroundSlot(Mod, "TheGrotto/Assets/Images/Backgrounds/TheGardenUndergdound0");
            textureSlots[1] = BackgroundTextureLoader.GetBackgroundSlot(Mod, "TheGrotto/Assets/Images/Backgrounds/TheGardenUndergdound1");
            textureSlots[2] = BackgroundTextureLoader.GetBackgroundSlot(Mod, "TheGrotto/Assets/Images/Backgrounds/TheGardenUndergdound2");
            textureSlots[3] = BackgroundTextureLoader.GetBackgroundSlot(Mod, "TheGrotto/Assets/Images/Backgrounds/TheGardenUndergdound3");
        }
    }
}

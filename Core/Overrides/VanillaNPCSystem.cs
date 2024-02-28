namespace TheGrotto.Core.Overrides {
    //credit to tomat for this system
    public class VanillaNPCSystem : ModSystem {
        public static readonly List<VanillaNPCOverride> npcsToOverride = new();

        public override void Load() {
            var types = typeof(TheGrotto).Assembly.GetTypes().Where(x => x.IsSubclassOf(typeof(VanillaNPCOverride)));
            foreach(var type in types) {
                if(Activator.CreateInstance(type) is VanillaNPCOverride item)
                    npcsToOverride.Add(item);
            }

            for(var i = 0; i < NPCLoader.NPCCount; i++) {
                if(ModContent.RequestIfExists<Texture2D>($"TheGrotto/Assets/NPCs/Vanilla/NPC_{i}", out var asset))
                    TextureAssets.Npc[i] = asset;
            }
        }

        public override void Unload() {
            for(var i = 0; i < NPCLoader.NPCCount; i++) {
                if(ModContent.HasAsset("TheGrotto/Assets/NPCs/Vanilla/NPC_" + i))
                    TextureAssets.Npc[i] = ModContent.Request<Texture2D>("Terraria/Images/NPC_" + i);
            }
        }
    }
}

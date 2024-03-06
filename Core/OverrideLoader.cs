namespace TheGrotto.Core {
    public class OverrideLoader : ILoadable {
        public static List<ItemOverride> itemsToOverride = new();
        public static List<NPCOverride> npcsToOverride = new();

        public void Load(Mod mod) {
            var types = typeof(TheGrotto).Assembly.GetTypes().Where(npc => npc.IsSubclassOf(typeof(NPCOverride)));
            foreach (var type in types) {
                if(Activator.CreateInstance(type) is NPCOverride npc)
                    npcsToOverride.Add(npc);
            }
        }

        public void Unload() {
            
        }
    }
}

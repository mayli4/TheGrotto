namespace TheGrotto.Core.Overrides {
    //credit to tomat for this system
    public class VanillaNPCSystem : ModSystem {
        public static List<VanillaNPCOverride> npcsToOverride = new();

        public override void Load() {
            IEnumerable<Type> types = typeof(TheGrotto).Assembly.GetTypes().Where(x => x.IsSubclassOf(typeof(VanillaNPCOverride)));
            foreach (Type type in types) { 
                if(Activator.CreateInstance(type) is VanillaNPCOverride npc) {
                    npcsToOverride.Add(npc);
                }
            }
        }

        public override void Unload() {
            npcsToOverride = null;
        }
    }
}

namespace TheGrotto.Common.Systems {
    public class VillageSystem : GrottoSystem {
        public static int GetVillagerTypeCount() => Enum.GetValues<VillagerType>().Length;
    }
}

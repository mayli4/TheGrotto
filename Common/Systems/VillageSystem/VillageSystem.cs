namespace TheGrotto.Common.Systems {
    public class VillageSystem : BaseSystem<VillageSystem> {
        public static int GetVillagerTypeCount() => Enum.GetValues<VillagerType>().Length;
    }
}

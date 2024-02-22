namespace TheGrotto.Common.Systems {

    //maybe replace this with something that just modifies vanilla items outright? instead of adding new ones and depricating the originals
    public class ItemDeprecationSystem : ModSystem {
        public static List<int> itemTypes = new();

        public override void PostSetupContent() {
            for(int i = 0; i < ItemLoader.ItemCount; i++) {
                var item = new Item();
                item.SetDefaults(i);

                bool isHammer = (item.hammer > 0 && item.pick == 0);
                bool itemsToRemove = isHammer;

                if(itemsToRemove) { 
                    itemTypes.Add(i);
                }
            }
        }

        public override void PostSetupRecipes() {
            for(int i = 0; i < itemTypes.Count; i++) {
                ItemID.Sets.Deprecated[itemTypes[i]] = true;
            }
        }
    }
}

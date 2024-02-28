namespace TheGrotto.Common.Systems {

    //maybe replace this with something that just modifies vanilla items outright instead of adding new ones and depricating the originals
    //remove recipes also
    public class ToolDeprecationSystem : ModSystem {
        public static List<int> itemTypes = new();

        public static List<int> specialItems = new() {
            ItemID.Pwnhammer
        };

        public override void PostSetupContent() {
            for(int i = 0; i < ItemLoader.ItemCount; i++) {
                var item = new Item();
                item.SetDefaults(i);

                bool isHammer = (item.hammer > 0 && item.pick == 0);
                bool itemsToRemove = isHammer;

                if(itemsToRemove && !specialItems.Contains(item.type)) { 
                    itemTypes.Add(i);
                }
            }
        }

        public override void PostSetupRecipes() {
            for(int i = 0; i < itemTypes.Count; i++) {
                ItemID.Sets.Deprecated[itemTypes[i]] = true;
            }
        }

        public override void PostAddRecipes() {
            for(int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];

                for(int k = 0; k < itemTypes.Count; k++)
                {
                    int bad = itemTypes[k];

                    if(recipe.TryGetIngredient(bad, out Item ingredient))
                    {
                        recipe.RemoveIngredient(bad);
                    }

                    if(recipe.HasResult(bad))
                    {
                        recipe.DisableRecipe();
                        break;
                    }
                }
            }
        }
    }
}

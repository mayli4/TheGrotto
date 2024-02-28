namespace TheGrotto.Common.Systems {
    public class ItemDeprecationSystem : ModSystem {

        public static List<int> itemsToDeprecate = new() {
            //hm ores
            ItemID.AdamantiteRepeater,
            ItemID.TitaniumRepeater,
            ItemID.OrichalcumRepeater,
            ItemID.PalladiumRepeater,

            //prehm ores
            ItemID.LeadBow,
            ItemID.SilverBroadsword,
        };

        public override void PostSetupContent() {
            for(int i = 0; i < ItemLoader.ItemCount; i++)
            {
                var item = new Item();
                item.SetDefaults(i);
            }
        }

        public override void PostSetupRecipes() {
            for(int i = 0; i < itemsToDeprecate.Count; i++) {
                ItemID.Sets.Deprecated[itemsToDeprecate[i]] = true;
            }
        }
    }

    public class DeprecatedItem : GlobalItem {
        public override bool InstancePerEntity => true;

        public override bool AppliesToEntity(Item entity, bool lateInstantiation) {
            if(ItemDeprecationSystem.itemsToDeprecate.Contains(entity.type))
                return true;

            return false;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
            TooltipLine line = new TooltipLine(Mod, "ToolHelp", $"{item.Name} should not be seen during normal gameplay!");
            line.OverrideColor = Color.PaleVioletRed;
            tooltips.Add(line);
        }
    }
}

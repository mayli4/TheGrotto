namespace TheGrotto.Common.Systems {
    public class Pick : GlobalItem {
        public override bool InstancePerEntity => true;
        public override bool AltFunctionUse(Item item, Player player) => true;

        public List<int> ExcludedItems = new() {
            ItemID.Pwnhammer
        };

        int hammerMod = 0 / 2;
        int storedPickPower = 0;

        public override bool AppliesToEntity(Item entity, bool lateInstantiation) {
            if(entity.pick > 0)
                return true;
            return false;
        }

        public override void SetDefaults(Item entity) {
            ItemID.Sets.ItemsThatAllowRepeatedRightClick[entity.type] = true;
            hammerMod = entity.pick;
            storedPickPower = entity.pick;
        }

        public override bool CanUseItem(Item item, Player player) {
            if(player.altFunctionUse == 2) {
                item.hammer = hammerMod;
                item.pick = 0;
            }
            else {
                item.hammer = 0;
                item.pick = storedPickPower;
            }
            return true;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
            TooltipLine hammerPower = new TooltipLine(Mod, "HammerPower", $"{hammerMod}% Hammer Power");
            TooltipLine line = new TooltipLine(Mod, "ToolHelp", "Has a dual use as a hammer! Right click to hammer tiles.");

            tooltips.Add(line);
            tooltips.Add(hammerPower);
        }
    }
}

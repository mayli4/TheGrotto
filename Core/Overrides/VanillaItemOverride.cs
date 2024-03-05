namespace TheGrotto.Core.Overrides {
    public abstract class VanillaItemOverride : GlobalItem {
        public abstract object ItemTypes { get; }
        public override bool InstancePerEntity => true;

        public override bool AppliesToEntity(Item entity, bool lateInstantiation) {
            return ItemTypes switch
            {
                Array => ((int[])ItemTypes).Contains(entity.type),
                int => (int)ItemTypes == entity.type,
                short => (short)ItemTypes == entity.type,
                _ => false,
            };
        }
    }
}

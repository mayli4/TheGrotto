namespace TheGrotto.Common.Systems {
    public abstract class VillagerNPC : GrottoNPC {

        public override LocalizedText DisplayName => base.DisplayName;

        public override string Texture => base.Texture;

        public virtual ReputationState Reputation { get; set; }
        public virtual VillagerType VillagerType { get; }

        public override void SetDefaults() {
            base.SetDefaults();
        }

        public sealed override void AutoStaticDefaults() {
            NPCID.Sets.ActsLikeTownNPC[Type] = true;
            NPCID.Sets.SpawnsWithCustomName[Type] = true;
            NPCID.Sets.NoTownNPCHappiness[Type] = true;
            NPCID.Sets.AllowDoorInteraction[Type] = true;

            base.AutoStaticDefaults();
        }

        public override ModNPC Clone(NPC newEntity) {
            VillagerNPC clone = (VillagerNPC)base.Clone(newEntity);
            return clone;
        }
    }
}

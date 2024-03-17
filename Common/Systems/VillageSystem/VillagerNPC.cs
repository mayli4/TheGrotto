using Hjson;

namespace TheGrotto.Common.Systems {
    public abstract class VillagerNPC : GrottoNPC {

        public override LocalizedText DisplayName => base.DisplayName;

        public override string Texture => base.Texture;

        public virtual ReputationState Reputation { get; set; }
        public virtual VillagerType VillagerType { get; }
        public static IReadOnlyDictionary<VillagerType, IReadOnlyList<string>> villagerNames;

        public override void SetDefaults() {
            base.SetDefaults();
        }

        public sealed override void AutoStaticDefaults() {
            NPCID.Sets.ActsLikeTownNPC[Type] = true;
            NPCID.Sets.SpawnsWithCustomName[Type] = true;
            NPCID.Sets.NoTownNPCHappiness[Type] = true;
            NPCID.Sets.AllowDoorInteraction[Type] = true;

            NPC.friendly = Reputation != ReputationState.Vilified;

            JsonValue nameData = Utilities.Utils.GetJSONFromFile("Assets/Data/VillagerNames.json");
            Dictionary<VillagerType, IReadOnlyList<string>> tempVillagerNames = new();
            for(VillagerType villagerType = 0; (int)villagerType < VillageSystem.GetVillagerTypeCount(); villagerType++) {
                tempVillagerNames[villagerType] = nameData[villagerType.ToString()].Qa().Select(value => value.Qs()).ToList();
            }
            villagerNames = tempVillagerNames;

            base.AutoStaticDefaults();
        }

        public override ModNPC Clone(NPC newEntity) {
            VillagerNPC clone = (VillagerNPC)base.Clone(newEntity);
            return clone;
        }

        public override List<string> SetNPCNameList() {
            villagerNames[VillagerType].ToList();
            return base.SetNPCNameList();
        }

        public override void SaveData(TagCompound tag) {
            tag["isHomeless"] = NPC.homeless;
            tag["DisplayName"] = NPC.GivenName;
            base.SaveData(tag);
        }
        public override void LoadData(TagCompound tag) {
            NPC.homeless = tag.GetBool("isHomeless");
            NPC.GivenName = tag.GetString("DisplayName");
            base.LoadData(tag);
        }
    }
}

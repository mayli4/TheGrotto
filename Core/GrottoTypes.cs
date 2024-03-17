namespace TheGrotto.Core {

    public abstract class GrottoNPC : ModNPC, IGrottoType<ModNPC> {
        public virtual bool autoLoadTexture { get; set; }

        public override string Texture {
            get {
                if(autoLoadTexture) {
                    var source = (GetType().Namespace ?? "TheGrotto").Split('.')[0];
                    return $"{source}/Assets/" + base.Texture[(source.Length + 1)..].Replace("Content/", string.Empty);
                }
                else return string.Empty;
            }
        }
    }

    public abstract class NPCOverride : GlobalNPC, IGrottoType<GlobalNPC> {
        public abstract object NPCTypes { get; }
        public override bool InstancePerEntity => true;
        public override bool AppliesToEntity(NPC entity, bool lateInstantiation) {
            return NPCTypes switch
            {
                Array => ((int[])NPCTypes).Contains(entity.type),
                int => (int)NPCTypes == entity.type,
                short => (short)NPCTypes == entity.type,
                _ => false,
            };
        }
    }
    public abstract class ItemOverride : GlobalItem, IGrottoType<GlobalItem> {
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

    public abstract class BaseSystem<T> : ModSystem, IGrottoType<ModSystem> where T : BaseSystem<T> {
        T Instance = ModContent.GetInstance<T>(); 
    }

}

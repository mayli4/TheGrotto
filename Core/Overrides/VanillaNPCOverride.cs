namespace TheGrotto.Core.Overrides {
    public abstract class VanillaNPCOverride : GlobalNPC {
        public override bool InstancePerEntity => true;
        public abstract object NPCTypes { get; }

        public override bool AppliesToEntity(NPC entity, bool lateInstantiation) {
            return NPCTypes switch {
                Array => ((int[])NPCTypes).Contains(entity.type),
                short => (short)NPCTypes == entity.type,
                int => (int)NPCTypes == entity.type,
                _ => false,
            };
        }

        public override void OnSpawn(NPC npc, IEntitySource source) {
            void spawnSwarm(Vector2 spawn, int size, float dist) {

                int maxSize = Main.masterMode ? 40 : Main.expertMode ? 25 : 15;
                maxSize += Main.rand.Next(2);

                for (int i = 0; i < size; i++) {
                    for (int j = 0; 0 < maxSize; j++) {
                        Vector2 spawnPosition = spawn * dist;
                        spawnPosition.Y = MathHelper.Clamp(spawnPosition.Y, spawn.Y - 16, spawn.Y + 16);

                        if (!WorldGen.SolidTile(Framing.GetTileSafely((spawn / 16).ToPoint()))) {
                            int id = NPC.NewNPC(new EntitySource_Parent(npc), (int)spawnPosition.X, (int)spawnPosition.Y, npc.type);
                        }
                    }
                }
            }

            foreach(VanillaNPCOverride type in VanillaNPCSystem.npcsToOverride) { 
                if(type is ISwarmNPC swarmer) {
                    if(((type.NPCTypes is Array && ((int[])type.NPCTypes).Contains(npc.type)) || (type.NPCTypes is int @int && @int == npc.type) || (type.NPCTypes is short @short && @short == npc.type)) && source is not EntitySource_Parent)
                        spawnSwarm(npc.Center, swarmer.swarmSize() - 1, 16 * 7);
                }
            }

        }
    }
}

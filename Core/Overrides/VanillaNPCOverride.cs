namespace TheGrotto.Core.Overrides {
    public abstract class VanillaNPCOverride : GlobalNPC {

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

        public override void OnSpawn(NPC npc, IEntitySource source) {
            void spawnAsPack(Vector2 origin, int size, float distance) {
                for(var i = 0; i < size; i++)
                {
                    for(var o = 0; o < 50; o++)
                    {
                        var spawnPos = origin + (Main.rand.NextVector2Unit() * Main.rand.NextFloat() * distance);
                        spawnPos.Y = MathHelper.Clamp(spawnPos.Y, origin.Y - 16, origin.Y + 16);

                        if(!WorldGen.SolidTile(Framing.GetTileSafely((spawnPos / 16).ToPoint())))
                        {
                            var id = NPC.NewNPC(new EntitySource_Parent(npc), (int)spawnPos.X, (int)spawnPos.Y, npc.type);

                            if(Main.netMode != NetmodeID.SinglePlayer)
                                NetMessage.SendData(MessageID.SyncNPC, number: id);
                            break;
                        }
                    }
                }
            }
            foreach(var type in VanillaOverrideSystem.npcsToOverride)
            {
                if(type is ISwarmNPC swarmer)
                    if(((type.NPCTypes is Array && ((int[])type.NPCTypes).Contains(npc.type)) || (type.NPCTypes is int @int && @int == npc.type) || (type.NPCTypes is short @short && @short == npc.type)) && source is not EntitySource_Parent)
                        spawnAsPack(npc.Center, swarmer.swarmSize() - 1, 16 * 7);
            }
        }
    }
}

namespace TheGrotto.Common.Systems {
    public abstract class Particle : ModTexturedType {
        protected override void Register() {
            ModTypeLookup<Particle>.Register(this);
            AssetDirectory.Textures.Particles.Add(this.ID, ModContent.Request<Texture2D>(Texture));
        }
        /// <summary>
        /// Numerical ID of this particle. Depends on load order.
        /// </summary>
        public int ID;
        public bool Active;
        public bool behindEntities;
        public Vector2 Position;
        public Vector2 Velocity;
        public float Rotation;
        public float Scale;
        public Color Color;

        public virtual void Draw(SpriteBatch spriteBatch) { }
        public virtual void Update() { }
        public virtual void OnSpawn() { }

        public static T SpawnParticle<T>(Action<T> action) {
            T newParticle = Activator.CreateInstance<T>();
            action(newParticle);
            return newParticle;
        }

    }
}

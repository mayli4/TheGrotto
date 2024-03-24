namespace TheGrotto.Common.Systems {
    public class ParticleSystem : BaseSystem<ParticleSystem> {

        public static List<Particle> particles = new();
        public static int particleIDs = 0;
        public static int NextID() => particleIDs++;

        public override void Load() {
            particles = new();

            On_Main.DrawDust += DrawParticles;
            On_Main.UpdateParticleSystems += UpdateParticles;
            base.Load();
        }

        public override void Unload() {
            particles.Clear();
            particles = null;
            base.Unload();
        }

        private void UpdateParticles(On_Main.orig_UpdateParticleSystems orig, Main self) {
            orig(self);
            for(int i = 0; i < particles.Count(); i++) {
                Particle particle = particles[i];

                if(particle != null) {
                    particle.Update();
                    particle.Position += particle.Velocity;
                }
            }
        }

        private void DrawParticles(On_Main.orig_DrawDust orig, Main self) {
            orig(self);

            Main.spriteBatch.Begin(SpriteSortMode.Texture, BlendState.NonPremultiplied, SamplerState.PointClamp, default, default, default, Main.GameViewMatrix.TransformationMatrix);
            for(int i = 0; i < particles.Count(); i++) {
                Particle particle = particles[i];

                Rectangle screenBounds = new((int)Main.screenPosition.X,(int)Main.screenPosition.Y, Main.screenWidth, Main.screenHeight);
                    if(screenBounds.Contains((int)particle.Position.X, (int)particle.Position.Y))
                        particle.Draw(Main.spriteBatch);
            }
            Main.spriteBatch.End();
        }
        public void AddParticle(Particle particle)
            => particles.Add(particle);
        public void ClearParticles()
            => particles.Clear();
    }
}

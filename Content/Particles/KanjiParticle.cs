namespace TheGrotto.Content.Particles {
    public class KanjiParticle : Particle {

        public override string Texture => "TheGrotto/Assets/Images/Kanji";

        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
        }

        public override void Update() {
            Rotation += 0.01f * MathF.Sin(Main.GlobalTimeWrappedHourly * Main.WindForVisuals);
            base.Update();
        }

        public override void Draw(SpriteBatch spriteBatch) {

            var texture = ModContent.Request<Texture2D>(Texture).Value;

            spriteBatch.Draw(texture, 
                Position - Main.screenPosition,
                null,
                Color.White,
                Rotation,
                new Vector2(texture.Width / 2, texture.Height / 2),
                Scale,
                SpriteEffects.None,
                1);
            base.Draw(spriteBatch);
        }
    }
}

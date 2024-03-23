using Terraria.Graphics.CameraModifiers;

namespace TheGrotto.Common.Systems.CameraSystem {
    public class ScreenshakeModifier : ICameraModifier {

        public float strength = 0;
        public float maxStrength;
        public float diminish;

        public string UniqueIdentity => "TheGrotto::Screenshake";
        public bool Finished => strength < 0.01f;

        public ScreenshakeModifier() { }
        public ScreenshakeModifier(float strength, float diminish) {
            this.strength = strength;
            this.diminish = diminish;
        }

        public void Update(ref CameraInfo cameraPosition) {
            cameraPosition.CameraPosition += Main.rand.NextVector2Unit() * strength;
            strength *= diminish;
        }
    }
}

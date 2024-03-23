using Terraria.Graphics.CameraModifiers;

namespace TheGrotto.Common.Systems.CameraSystem {
    public class ZoomModifier : ICameraModifier {
        public string UniqueIdentity => "TheGrotto::Zoom";

        public bool Finished => throw new NotImplementedException();

        public void Update(ref CameraInfo cameraPosition) {
            throw new NotImplementedException();
        }
    }
}

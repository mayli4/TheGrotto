using Terraria.Graphics.CameraModifiers;

namespace TheGrotto.Common.Systems.CameraSystem {
    public class MoveModifier : ICameraModifier {

        public Vector2 moveTarget = new(0, 0);

        public string UniqueIdentity => "TheGrotto::MoveCamera";
        public bool Finished => false;

        public void Update(ref CameraInfo cameraPosition) {

        }
    }
}

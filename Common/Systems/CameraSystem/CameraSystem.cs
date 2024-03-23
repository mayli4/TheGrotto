namespace TheGrotto.Common.Systems.CameraSystem {
    public class CameraSystem : BaseSystem<CameraSystem> {
        private static ScreenshakeModifier Screenshake = new();
        private static MoveModifier MoveCamera = new();

        public static void DoScreenshake(int strength) {
            Screenshake.strength = strength;
        }

        public override void ModifyScreenPosition() {
            if(MoveCamera.moveTarget != Vector2.Zero)
                Main.instance.CameraModifiers.Add(MoveCamera);            
            
            if(Screenshake.strength < 0)
                Main.instance.CameraModifiers.Add(Screenshake);

            base.ModifyScreenPosition();
        }
    }
}

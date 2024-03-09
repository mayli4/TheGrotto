namespace TheGrotto.Common.Bases {
    public abstract class HeldProjectile : ModProjectile {

        Player player => Main.player[Projectile.owner];
        public Vector2 holdoutOffset;
        public bool despawned;
        public bool changePlayerDirection = false;
        private int associatedItem = -1;

        public override bool PreAI() {
            player.heldProj = Projectile.whoAmI;

            if(changePlayerDirection) {
                int playerDirection = Math.Sign(Main.MouseWorld.X - player.Center.X);
                player.ChangeDir(playerDirection);
            }

            return true;
        }

        protected bool ShouldKill() {
            return player.noItems || player.CCed;
        }

        protected void SetPositionToPlayer() {
            Projectile.Center = player.RotatedRelativePoint(player.MountedCenter) + holdoutOffset;
        }

        public void SetAssociatedItem(int item) => associatedItem = item;

    }
}

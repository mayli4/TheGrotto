namespace TheGrotto.Common.Bases {
    public abstract class HeldProjectileItem<T> : ModItem where T : HeldProjectile {

        public T thisProjectile;

        public override void SetDefaults() {
            Item.channel = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
        }

        public static T SpawnHeldProjectile(Player player, int type, int itemType, int dmg, float kb, int owner) {
            Projectile proj 
                = Projectile.NewProjectileDirect(player.GetSource_FromThis(), 
                player.Center, Vector2.Zero, type, dmg, kb, owner);

            T heldProj = proj.ModProjectile as T;
            heldProj.SetAssociatedItem(itemType);

            return heldProj;
        }

        public override void HoldItem(Player player) {
            if(thisProjectile == null || thisProjectile.Projectile.active == false)
                thisProjectile = SpawnHeldProjectile(player, ModContent.ProjectileType<T>(), Type, 
                    Item.damage, Item.knockBack, player.whoAmI);
            base.HoldItem(player);
        }

    }
}

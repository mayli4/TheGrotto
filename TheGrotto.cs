namespace TheGrotto {
	/// <summary>
	/// note to self keep the amount of content this class directly manages to a minimum
	/// </summary>
	public class TheGrotto : Mod {
		public static string Localize() => Language.GetTextValue("");
        public static ParticleSystem particleSystem;
        public static ParticleSystem particleSystemUnderEntities;
        public override void Load() {
            particleSystem = new();
            base.Load();
        }

        public override void PostSetupContent() {            
            base.PostSetupContent();
        }

    }
}
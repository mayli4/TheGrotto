namespace TheGrotto {
    public static class AssetDirectory {
        
        public static class Paths {
            public static string Assets = "TheGrotto/Assets/";
            public static string NPCs = Assets + "NPCs/";
            public static string Villagers = Assets + "NPCs/Villagers/";
            public static string HostileNPCs = NPCs + "Hostile/";
        }

        public static class Textures {
            public static Dictionary<int, Asset<Texture2D>> Particles = new();
        }

    }
}

global using Terraria.ModLoader;
global using Terraria;
global using Terraria.GameContent;
global using Terraria.Localization;
global using Terraria.GameContent.UI;
global using Terraria.ID;
global using Terraria.DataStructures;
global using Terraria.ModLoader.IO;
global using Terraria.WorldBuilding;
global using Terraria.GameContent.Generation;
global using Terraria.IO;

global using Microsoft.Xna.Framework;
global using Microsoft.Xna.Framework.Graphics;

global using System.Linq;
global using System;
global using System.Collections.Generic;
global using System.Reflection;
global using System.IO;

global using TheGrotto.Core;
global using TheGrotto.Common.Biomes.TheGarden;
global using TheGrotto.Common;
global using TheGrotto.Common.Bases;


namespace TheGrotto {
	/// <summary>
	/// note to self keep the amount of content this class directly manages to a minimum
	/// </summary>
	public class TheGrotto : Mod {
		public static string Localize() => Language.GetTextValue("");

        public override void PostSetupContent() {            
            base.PostSetupContent();
        }

    }
}
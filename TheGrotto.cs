global using Terraria.ModLoader;
global using Terraria;
global using Terraria.GameContent;
global using Terraria.Localization;
global using Terraria.GameContent.UI;
global using Terraria.ID;
global using Terraria.DataStructures;

global using Microsoft.Xna.Framework;
global using Microsoft.Xna.Framework.Graphics;

global using System.Linq;
global using System;
global using System.Collections.Generic;
global using System.Reflection;

global using TheGrotto.Core;

namespace TheGrotto {
	/// <summary>
	/// note to self keep the amount of content this class directly manages to a minimum
	/// </summary>
	public class TheGrotto : Mod {
		public static string Localize() => Language.GetTextValue("");
	}
}
using System;
using System.Reflection;
using HarmonyLib;
using Verse;

namespace IClearlyHaveEnough
{
	// Token: 0x02000005 RID: 5
	[StaticConstructorOnStartup]
	internal static class IClearlyHaveEnoughInit
	{
		// Token: 0x0600000E RID: 14 RVA: 0x000021FE File Offset: 0x000003FE
		static IClearlyHaveEnoughInit()
		{
			new Harmony("com.chippedchap.iclearlyhaveenough").PatchAll(Assembly.GetExecutingAssembly());
		}
	}
}

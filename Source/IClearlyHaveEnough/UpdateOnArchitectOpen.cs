using System;
using HarmonyLib;
using RimWorld;
using Verse;

namespace IClearlyHaveEnough
{
	// Token: 0x02000006 RID: 6
	[HarmonyPatch(typeof(MainTabWindow_Architect))]
	[HarmonyPatch("PostOpen")]
	internal class UpdateOnArchitectOpen
	{
		// Token: 0x0600000F RID: 15 RVA: 0x00002214 File Offset: 0x00000414
		private static void Postfix()
		{
			Find.CurrentMap.GetComponent<AllResourcesCounter_MapComponent>().UpdateResourceCounts();
		}
	}
}

using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using HarmonyLib;
using RimWorld;
using Verse;

namespace IClearlyHaveEnough
{
	// Token: 0x02000003 RID: 3
	[HarmonyPatch(typeof(Designator_Build))]
	[HarmonyPatch("DrawPanelReadout")]
	internal class PatcherDrawPanelReadout
	{
		// Token: 0x06000008 RID: 8 RVA: 0x000021C8 File Offset: 0x000003C8
		private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
		{
			foreach (CodeInstruction codeInstruction in instructions)
			{
				if (!(codeInstruction.opcode == OpCodes.Ldfld) || codeInstruction.operand != typeof(Map).GetField("resourceCounter"))
				{
					if (codeInstruction.opcode == OpCodes.Callvirt && codeInstruction.operand == typeof(ResourceCounter).GetMethod("GetCount"))
					{
						yield return new CodeInstruction(OpCodes.Call, typeof(PatcherDrawPanelReadout).GetMethod("GetPresentOnMap"));
					}
					else
					{
						yield return codeInstruction;
					}
				}
			}
			IEnumerator<CodeInstruction> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000021D8 File Offset: 0x000003D8
		public static int GetPresentOnMap(Map map, ThingDef def)
		{
			return map.GetComponent<AllResourcesCounter_MapComponent>().GetCount(def);
		}
	}
}

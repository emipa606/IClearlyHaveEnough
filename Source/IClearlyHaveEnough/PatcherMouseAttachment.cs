﻿using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using HarmonyLib;
using RimWorld;
using Verse;

namespace IClearlyHaveEnough
{
	// Token: 0x02000004 RID: 4
	[HarmonyPatch(typeof(Designator_Build))]
	[HarmonyPatch("DrawMouseAttachments")]
	internal class PatcherMouseAttachment
	{
		// Token: 0x0600000B RID: 11 RVA: 0x000021EE File Offset: 0x000003EE
		private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
		{
			foreach (CodeInstruction codeInstruction in instructions)
			{
				if (!(codeInstruction.opcode == OpCodes.Ldfld) || codeInstruction.operand != typeof(Map).GetField("resourceCounter"))
				{
					if (codeInstruction.opcode == OpCodes.Callvirt && codeInstruction.operand == typeof(ResourceCounter).GetMethod("GetCount"))
					{
						yield return new CodeInstruction(OpCodes.Call, typeof(PatcherMouseAttachment).GetMethod("GetPresentOnMap"));
					}
					else if (codeInstruction.opcode == OpCodes.Ldstr && codeInstruction.operand.Equals("NotEnoughStoredLower"))
					{
						yield return new CodeInstruction(OpCodes.Ldstr, "NotEnoughPresentLower");
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

		// Token: 0x0600000C RID: 12 RVA: 0x000021D8 File Offset: 0x000003D8
		public static int GetPresentOnMap(Map map, ThingDef def)
		{
			return map.GetComponent<AllResourcesCounter_MapComponent>().GetCount(def);
		}
	}
}

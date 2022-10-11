using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using RimWorld;
using Verse;

namespace IClearlyHaveEnough;

[HarmonyPatch(typeof(Designator_Build))]
[HarmonyPatch("DrawPanelReadout")]
internal class PatcherDrawPanelReadout
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        foreach (var codeInstruction in instructions)
        {
            if (codeInstruction.opcode == OpCodes.Ldfld &&
                (FieldInfo)codeInstruction.operand == typeof(Map).GetField("resourceCounter"))
            {
                continue;
            }

            if (codeInstruction.opcode == OpCodes.Callvirt &&
                (MethodInfo)codeInstruction.operand == typeof(ResourceCounter).GetMethod("GetCount"))
            {
                yield return new CodeInstruction(OpCodes.Call,
                    typeof(PatcherDrawPanelReadout).GetMethod("GetPresentOnMap"));
            }
            else
            {
                yield return codeInstruction;
            }
        }
    }

    public static int GetPresentOnMap(Map map, ThingDef def)
    {
        return map.GetComponent<AllResourcesCounter_MapComponent>().GetCount(def);
    }
}
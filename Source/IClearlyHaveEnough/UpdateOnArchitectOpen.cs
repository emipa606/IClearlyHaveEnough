using HarmonyLib;
using RimWorld;
using Verse;

namespace IClearlyHaveEnough;

[HarmonyPatch(typeof(MainTabWindow), nameof(MainTabWindow.PostOpen))]
internal class UpdateOnArchitectOpen
{
    private static void Postfix(MainTabWindow __instance)
    {
        if (__instance is MainTabWindow_Architect)
        {
            Find.CurrentMap.GetComponent<AllResourcesCounter_MapComponent>().UpdateResourceCounts();
        }
    }
}
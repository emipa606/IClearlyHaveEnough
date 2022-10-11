using System.Reflection;
using HarmonyLib;
using Verse;

namespace IClearlyHaveEnough;

[StaticConstructorOnStartup]
internal static class IClearlyHaveEnoughInit
{
    static IClearlyHaveEnoughInit()
    {
        new Harmony("com.chippedchap.iclearlyhaveenough").PatchAll(Assembly.GetExecutingAssembly());
    }
}
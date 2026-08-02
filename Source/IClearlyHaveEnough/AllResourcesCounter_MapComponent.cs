using System;
using System.Collections.Generic;
using System.Linq;
using Verse;

namespace IClearlyHaveEnough;

internal class AllResourcesCounter_MapComponent(Map map) : MapComponent(map)
{
    private readonly Dictionary<ThingDef, int> resourceCounts = new();
    private List<string> ignoredDefs = [];

    private HashSet<ThingDef> resourceThingDefs = [];

    public override void MapComponentTick()
    {
        if (Find.TickManager.TicksGame % 204 == 0)
        {
            UpdateResourceCounts();
        }
    }

    public override void FinalizeInit()
    {
        refillDefs();
        UpdateResourceCounts();
    }

    public int GetCount(ThingDef def)
    {
        if (def == null)
        {
            return 0;
        }

        if (resourceCounts.TryGetValue(def, out var count))
        {
            return count;
        }

        if (def.resourceReadoutPriority == ResourceCountPriority.Uncounted || ignoredDefs.Contains(def.defName))
        {
            return 0;
        }

        if (Prefs.DevMode)
        {
            Log.Warning(
                $"AllResourcesCounter_MapComponent from mod IClearlyHaveEnough was requested for a count of a ThingDef that does not have a key: {def.defName}.");
        }

        ignoredDefs.Add(def.defName);

        return 0;
    }

    public void UpdateResourceCounts()
    {
        if (resourceThingDefs.Count == 0)
        {
            refillDefs();
        }

        resourceCounts.Clear();
        ignoredDefs = [];
        foreach (var thingDef in resourceThingDefs)
        {
            try
            {
                var list = map.listerThings.ThingsOfDef(thingDef);
                var num = 0;
                foreach (var thing in list)
                {
                    num += thing.stackCount;
                }

                resourceCounts.Add(thingDef, num);
            }
            catch (Exception exception)
            {
                if (Prefs.DevMode)
                {
                    Log.ErrorOnce(
                        $"UpdateResourceCounts from mod IClearlyHaveEnough was requested for a count of a ThingDef that it cannot find: {thingDef.defName}.\n{exception}",
                        thingDef.defName.GetHashCode());
                }
            }
        }
    }

    private void refillDefs()
    {
        resourceThingDefs.Clear();
        resourceThingDefs =
        [
            ..from def in DefDatabase<ThingDef>.AllDefs
            where def.CountAsResource
            select def
        ];
    }
}
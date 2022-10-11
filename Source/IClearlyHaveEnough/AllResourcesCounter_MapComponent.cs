using System;
using System.Collections.Generic;
using System.Linq;
using Verse;

namespace IClearlyHaveEnough;

internal class AllResourcesCounter_MapComponent : MapComponent
{
    private readonly Dictionary<ThingDef, int> resourceCounts = new Dictionary<ThingDef, int>();
    private List<string> ignoredDefs = new List<string>();

    private HashSet<ThingDef> resourceThingDefs = new HashSet<ThingDef>();

    public AllResourcesCounter_MapComponent(Map map) : base(map)
    {
    }

    public override void MapComponentTick()
    {
        if (Find.TickManager.TicksGame % 204 == 0)
        {
            UpdateResourceCounts();
        }
    }

    public override void FinalizeInit()
    {
        RefillDefs();
        UpdateResourceCounts();
    }

    public bool ShouldTrackThing(Thing thing)
    {
        return resourceThingDefs.Contains(thing.def);
    }

    public int GetCount(ThingDef def)
    {
        if (resourceCounts.ContainsKey(def))
        {
            return resourceCounts[def];
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
        resourceCounts.Clear();
        ignoredDefs = new List<string>();
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

    private void RefillDefs()
    {
        resourceThingDefs.Clear();
        resourceThingDefs = new HashSet<ThingDef>(from def in DefDatabase<ThingDef>.AllDefs
            where def.CountAsResource
            select def);
    }
}
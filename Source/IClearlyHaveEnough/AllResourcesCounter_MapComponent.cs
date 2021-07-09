using System;
using System.Collections.Generic;
using System.Linq;
using Verse;

namespace IClearlyHaveEnough
{
    // Token: 0x02000002 RID: 2
    internal class AllResourcesCounter_MapComponent : MapComponent
    {
        // Token: 0x04000001 RID: 1
        private readonly Dictionary<ThingDef, int> resourceCounts = new Dictionary<ThingDef, int>();
        private List<string> ignoredDefs = new List<string>();

        // Token: 0x04000002 RID: 2
        private HashSet<ThingDef> resourceThingDefs = new HashSet<ThingDef>();

        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
        public AllResourcesCounter_MapComponent(Map map) : base(map)
        {
        }

        // Token: 0x06000002 RID: 2 RVA: 0x0000206F File Offset: 0x0000026F
        public override void MapComponentTick()
        {
            if (Find.TickManager.TicksGame % 204 == 0)
            {
                UpdateResourceCounts();
            }
        }

        // Token: 0x06000003 RID: 3 RVA: 0x00002089 File Offset: 0x00000289
        public override void FinalizeInit()
        {
            RefillDefs();
            UpdateResourceCounts();
        }

        // Token: 0x06000004 RID: 4 RVA: 0x00002097 File Offset: 0x00000297
        public bool ShouldTrackThing(Thing thing)
        {
            return resourceThingDefs.Contains(thing.def);
        }

        // Token: 0x06000005 RID: 5 RVA: 0x000020AA File Offset: 0x000002AA
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

        // Token: 0x06000006 RID: 6 RVA: 0x000020DC File Offset: 0x000002DC
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

        // Token: 0x06000007 RID: 7 RVA: 0x0000217C File Offset: 0x0000037C
        private void RefillDefs()
        {
            resourceThingDefs.Clear();
            resourceThingDefs = new HashSet<ThingDef>(from def in DefDatabase<ThingDef>.AllDefs
                where def.CountAsResource
                select def);
        }
    }
}
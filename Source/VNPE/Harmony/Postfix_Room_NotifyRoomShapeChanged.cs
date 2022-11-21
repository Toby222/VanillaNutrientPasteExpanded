﻿using HarmonyLib;
using Verse;

namespace VNPE
{
    [HarmonyPatch(typeof(Room))]
    [HarmonyPatch("Notify_RoomShapeChanged", MethodType.Normal)]
    public static class Postfix_Room_NotifyRoomShapeChanged
    {
        public static void Postfix(Room __instance)
        {
            if (!__instance.Dereferenced)
            {
                var map = __instance.Map;

                var pasteTaps = map.listerThings.ThingsOfDef(VThingDefOf.VNPE_NutrientPasteTap);
                for (int i = 0; i < pasteTaps.Count; i++)
                    pasteTaps[i].Notify_ColorChanged();

                var pasteFeeders = map.listerThings.ThingsOfDef(VThingDefOf.VNPE_NutrientPasteFeeder);
                for (int i = 0; i < pasteFeeders.Count; i++)
                    pasteFeeders[i].Notify_ColorChanged();
            }
        }
    }
}
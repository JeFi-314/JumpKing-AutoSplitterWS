using System;
using System.Reflection;
using HarmonyLib;
using JK = JumpKing.MiscEntities.WorldItems.Inventory;
using JumpKing.MiscEntities.WorldItems;
using AutoSplitterWS.Communication;

namespace AutoSplitterWS.Patching;

internal class InventoryManager
{
    public InventoryManager(Harmony harmony) {
        Type type = typeof(JK.InventoryManager);
        Type[] signature = new Type[]{typeof(Items), typeof(int)};
        MethodInfo AddItems = AccessTools.Method(type, nameof(JK.InventoryManager.AddItems), signature);

        harmony.Patch(
            AddItems,
            prefix: new HarmonyMethod(AccessTools.Method(typeof(InventoryManager), nameof(preAddItems)))
        );
    }

    private static void preAddItems(Items p_item, int p_count) {
        if (p_count > 0) {
            CommunicationWrapper.SendAddItems((int) p_item, p_count);
        }
    }
}
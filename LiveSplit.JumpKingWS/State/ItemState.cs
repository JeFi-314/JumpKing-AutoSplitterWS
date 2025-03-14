using System;
using System.Collections.Generic;
using System.Linq;
using CommonCom;

namespace LiveSplit.JumpKingWS.State;
public static class ItemState
{
    private static List<int> itemsList;

    static ItemState() {
        int length = Enum.GetValues(typeof(Item)).Length;
        itemsList = [.. Enumerable.Repeat(0, length)];
    }

    public static void Reset()
    {
        for (int i=0; i<itemsList.Count; i++) {
            itemsList[i] = 0;
        }
    }

    public static void AddItems(Item item, int count) {
        if (count<=0){
            return;
        }
        itemsList[(int)item] += count;
    }
    public static bool HasItems(Item item, int count) {
        return itemsList[(int)item]>=count;
    }
}
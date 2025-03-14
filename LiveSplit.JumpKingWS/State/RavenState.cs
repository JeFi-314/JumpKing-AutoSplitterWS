using System.Collections.Generic;

namespace LiveSplit.JumpKingWS.State;
public static class RavenState
{
    private static Dictionary<string, HashSet<int>> ravenFleeDict;
    static RavenState() {
        ravenFleeDict = [];
    }

    public static void Reset()
    {
        ravenFleeDict.Clear();
    }

    public static void AddRavenFlee(string ravenName, int homeIndex) {
        if (!ravenFleeDict.ContainsKey(ravenName)) {
            ravenFleeDict.Add(ravenName, []);
        }

        ravenFleeDict[ravenName].Add(homeIndex);
    }
    public static bool HasRavenFlee(string ravenName, int homeIndex) {
        return ravenFleeDict.ContainsKey(ravenName) && ravenFleeDict[ravenName].Contains(homeIndex);
    }
}
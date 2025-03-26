using AutoSplitterWS.Communication;
using BehaviorTree;

namespace AutoSplitterWS.Node;

public class ConnectNode : IBTnode
{
    protected override BTresult MyRun(TickData p_data)
    {
        CommunicationWrapper.TryReconnect();
        return BTresult.Success;
    }
}
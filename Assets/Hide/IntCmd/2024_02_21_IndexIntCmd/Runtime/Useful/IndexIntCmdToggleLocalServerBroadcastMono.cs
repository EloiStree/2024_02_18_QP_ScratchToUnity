using UnityEngine;

public class IndexIntCmdToggleLocalServerBroadcastMono : MonoBehaviour
{
    public void BroadcastTargetAsServer()
    {
        IndexIntCmdToggleLocalServer.SetTargetAsServer();
    }
    public void BroadcastTargetAsLocal()
    {

        IndexIntCmdToggleLocalServer.SetTargetAsLocal();
    }
    public void BroadcastTargetAsBoth()
    {

        IndexIntCmdToggleLocalServer.SetTargetAsBoth();
    }
}

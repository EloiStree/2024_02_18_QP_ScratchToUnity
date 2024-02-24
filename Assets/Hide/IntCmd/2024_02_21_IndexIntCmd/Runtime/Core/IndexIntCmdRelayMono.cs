using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexIntCmdRelayMono : MonoBehaviour
{

    public IndexIntCmdStruct m_lastReceived;

    public IndexIntCmdUnityEvent.InterfaceGet m_onRelayed;


    [ContextMenu("Push Inspector value")]
    public void PushInInspectorValue() {
        PushIn(m_lastReceived);
    }

    public void PushIn(I_IndexIntCmdGet command) {

        m_lastReceived.Set(command);
        m_onRelayed.Invoke(command);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDD_PushRandomIndexIntCmdMono : MonoBehaviour
{

    public int[] m_indexToUse = new int[] { 65464, 65467 };
    public int[] m_commandToUse = new int[] { 
        1000000001,
        1100000001,
        1010000001,
        1001000001,
        1000100001,
        1000090001,
        1000020001,
        1000009001,
        1000002001,
        1000000901,
        1000000201,
        1000000091,
        1000000021,};

    public IndexIntCmdUnityEvent.InterfaceGet m_onRandomCommand;


    public IndexIntCmdStruct m_lastPushed;
    [ContextMenu("Push random command")]
    public void PushRandom() {
        m_lastPushed.Set(m_indexToUse[Random.Range(0, m_indexToUse.Length)], m_commandToUse[Random.Range(0, m_commandToUse.Length)]);
        m_onRandomCommand.Invoke(m_lastPushed);
    }

}

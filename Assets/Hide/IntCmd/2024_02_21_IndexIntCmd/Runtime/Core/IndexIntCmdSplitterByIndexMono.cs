using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IndexIntCmdSplitterByIndexMono : MonoBehaviour
{

    public IndexToInGameElementIntCmd[] m_indexIntCmdToInGameElements;

    [System.Serializable]
    public class IndexToInGameElementIntCmd {   
        public int m_index;
        public int m_command;
        public UnityEvent<int> m_onCommandReceived;
        public AbstractIntCmdHolderMono[] m_OnCommandReceivedListener;
        public  bool TryToPush(in int index, in  int command)
        {
            if (m_index == index) {
                if (m_command != command)
                {
                    m_command = command;
                    m_onCommandReceived.Invoke(m_command);
                    foreach (var item in m_OnCommandReceivedListener)
                    {
                        item.SetValue(command);
                    }
                }
                return true;
            }
            return false;
        }
    }
    public void PushIn(I_IndexIntCmdGet received) {

        PushIn(received.GetIndexInt(), received.GetCommandInt());
    }

    public void PushIn(int index, int command) {

        foreach (var item in m_indexIntCmdToInGameElements)
        {
            if (item.TryToPush(in index, in command )) {
                
            return;
            }
        }
    }

}

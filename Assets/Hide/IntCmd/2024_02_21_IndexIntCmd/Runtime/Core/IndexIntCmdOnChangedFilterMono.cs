using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexIntCmdOnChangedFilterMono : MonoBehaviour
{
    public Dictionary<int, int> m_onChangedDictionary = new Dictionary<int, int>();
    public IndexIntCmdUnityEvent.InterfaceGet m_onChanged;
    public void Push(I_IndexIntCmdGet command) {

        if (command == null)
            return;
        int c = command.GetCommandInt(), i = command.GetIndexInt();
        if (!m_onChangedDictionary.ContainsKey(i))
        {
            m_onChangedDictionary.Add(i, c);
            m_onChanged.Invoke(command);
        }
        else { 

            int previous = m_onChangedDictionary[i];
            m_onChangedDictionary[i] = c;
            if (previous != c) {

                m_onChanged.Invoke(command);
            }
        }
    }
    
}

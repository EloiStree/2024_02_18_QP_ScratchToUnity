using UnityEngine;

public class IndexIntCmdRelayIntOnlyMono : MonoBehaviour
{

    public bool m_onlyOnChanged=true;
    public int m_lastReceived;
    public Splitter m_splitter = Splitter.Command;
    public enum Splitter: byte { Index, Command};
    public IndexIntCmdUnityEvent.Int m_onRelayed;

    public void PushIn(I_IndexIntCmdGet command)
    {
        if (m_splitter == Splitter.Command)
            PushIn(command.GetCommandInt());
        else    PushIn(command.GetIndexInt());
    }
    public void PushIn(int command)
    {
        if (m_onlyOnChanged)
        {
            bool changed = command != m_lastReceived;
            if (changed) { 
                m_lastReceived = command;
                m_onRelayed.Invoke(m_lastReceived);
            }
        }
        else { 
            m_lastReceived = command;
            m_onRelayed.Invoke(command);
        }
    }
}


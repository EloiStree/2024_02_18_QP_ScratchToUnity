using UnityEngine;
using UnityEngine.Events;

public class IntCmdAbstractRelayMono : AbstractIntCmdHolderMono
{
    public AbstractIntCmdHolderMono m_toRelay;
    public UnityEvent<I_IntCmd> m_onRelayInterface;
    public UnityEvent<int> m_onRelayInt;
    public int m_lastRelayed;

    public override I_IntCmd GetChildrenIntCmd()
    {
        return m_toRelay;
    }

    [ContextMenu("Relay Integer")]
    public void RelayInteger() {

        m_lastRelayed = m_toRelay.GetValue();
        if (m_toRelay != null)
            m_onRelayInterface.Invoke(m_toRelay);
        if (m_toRelay != null)
            m_onRelayInt.Invoke(m_lastRelayed);
    }
}


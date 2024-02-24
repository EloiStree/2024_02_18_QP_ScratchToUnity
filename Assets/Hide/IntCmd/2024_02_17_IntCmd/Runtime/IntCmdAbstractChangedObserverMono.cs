public class IntCmdAbstractChangedObserverMono : IntCmdAbstractRelayMono
{
    int m_previousValue;
    int m_currentValue;
    public void Update()
    {
        m_currentValue = m_toRelay.GetValue();
        if (m_previousValue != m_currentValue) {
            m_previousValue = m_currentValue;
            if (m_toRelay != null)
                m_onRelayInterface.Invoke(m_toRelay);
            if (m_toRelay != null)
                m_onRelayInt.Invoke(m_currentValue);
        }

    }
}


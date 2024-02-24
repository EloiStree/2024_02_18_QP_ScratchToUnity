using UnityEngine;

[System.Serializable]
public class IntCmdRelayMono : MonoBehaviour
{
    public IntCmd m_lastValue= new IntCmd();
    public void PushIn(string text)
    {
        if (int.TryParse(text, out int value)) {
            m_lastValue.SetValue(value);

            m_onIntCmdEvent.Invoke(m_lastValue);        
        }
    }
    public void PushIn(int value)
    {
        m_lastValue.SetValue(value);
        m_onIntCmdEvent.Invoke(m_lastValue);
    }
    public void PushIn(IntCmd value)
    {
        m_lastValue.SetValue(value.GetValue());
        m_onIntCmdEvent.Invoke(value);
    }

    [ContextMenu("Repush Value In Inspector")]
    public void RepushValueInInspector() {
        m_onIntCmdEvent.Invoke(m_lastValue);
    }
    public IntCmdEvent m_onIntCmdEvent;

}



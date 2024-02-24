using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntCmdRelayOnChangedMono : MonoBehaviour
{
    public IntCmd m_previousValue= new IntCmd();
    public IntCmd m_currentValue = new IntCmd();
    public void PushIn(string text)
    {
        if (int.TryParse(text, out int value))
        {
            PushIn(value);
        
        }
    }
    public void PushIn(IntCmd value)
    {

        PushIn(value.GetValue());
    }

    public void PushIn(int value)
    {
        m_previousValue.SetValue(m_currentValue.GetValue());
        m_currentValue.SetValue(value);
        if(m_previousValue.GetValue() != m_currentValue.GetValue() )
            m_onIntCmdEvent.Invoke(m_currentValue);
    }
   
   
    public IntCmdEvent m_onIntCmdEvent;

}


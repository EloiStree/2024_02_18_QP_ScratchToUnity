using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitIntCmdToDroneCarValueMono : MonoBehaviour
{
    public IntCmdToDroneCarInput m_input;
    public IntCmdChangedObserver m_valueReceivedChangedObserver;
    public void Push(int value) {

        m_valueReceivedChangedObserver.SetValue(value, out bool changed);
        if(changed)
            IntCmdCarDroneUtility.Convert(value, out  m_input);
    
    }
}

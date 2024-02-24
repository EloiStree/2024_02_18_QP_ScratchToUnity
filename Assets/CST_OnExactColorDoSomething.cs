using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CST_OnExactColorDoSomething : MonoBehaviour
{

    public Color m_colorToLookFor;
    public UnityEvent m_onColorFound;

    public void PushColorIn(Color color) {

        if (m_colorToLookFor.r == color.r 
            && m_colorToLookFor.g == color.g
            && m_colorToLookFor.b == color.b)
            m_onColorFound.Invoke();
    }
}

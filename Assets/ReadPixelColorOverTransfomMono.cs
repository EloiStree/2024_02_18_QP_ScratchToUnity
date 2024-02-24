using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReadPixelColorOverTransfomMono : MonoBehaviour
{

    public Transform m_whereToCheck;
    public Color m_color;
    public UnityWindowPositionVector2 m_screenPosition;
    public UnityEvent<Color> m_onUpdateColorOverTransform;

    public void Update()
    {
        ReadPixelColorOverUnityScreenZoneMono utility = ReadPixelColorOverUnityScreenZoneMono.InstanceInTheScene;
        if (utility == null) { return; }

        utility.TryToEstimateTheColorAndPositionOfTarget(m_whereToCheck, out m_screenPosition, out m_color);
        m_onUpdateColorOverTransform.Invoke(m_color);
    }
    private void Reset()
    {
        m_whereToCheck = this.transform;
    }
}

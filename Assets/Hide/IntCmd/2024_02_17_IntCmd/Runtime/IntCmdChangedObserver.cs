using UnityEngine;

[System.Serializable]

public class IntCmdChangedObserver {
    [SerializeField] int m_previousIntValue;
    [SerializeField] int m_currentIntValue;

    public void SetValue(int value, out bool changed) {

        m_previousIntValue = m_currentIntValue;
        m_currentIntValue = value;
        changed = m_previousIntValue != m_currentIntValue;
    }
    
}


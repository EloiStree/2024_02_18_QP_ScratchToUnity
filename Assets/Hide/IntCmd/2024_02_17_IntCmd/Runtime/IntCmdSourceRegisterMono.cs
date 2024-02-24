using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class IntCmdSourceRegisterMono : MonoBehaviour
{

    public IntCmdChangedRegister m_register = new IntCmdChangedRegister();
    public UnityEvent<string, int> m_onUserValueChanged = new UnityEvent<string, int>();

    public void Push(string sourceId, int value) {
        m_register.Push(sourceId, value,out int previousValue);
        if (value != previousValue)
            m_onUserValueChanged.Invoke(sourceId, value);

    }
}

public class IntCmdChangedRegister {

    public Dictionary<string, IntCmdTimedWithSource> m_intCmdState = new Dictionary<string, IntCmdTimedWithSource>();
    public void Push(string sourceId, int value, out int previousValue)
    {
        if (!m_intCmdState.ContainsKey(sourceId)) {
            IntCmdSourceAsString refString = new IntCmdSourceAsString(sourceId);
            m_intCmdState.Add(sourceId, new IntCmdTimedWithSource() { m_source = refString, m_intCmdValue = new IntCmdTimedUTC() }) ;
        }
        previousValue = m_intCmdState[sourceId].GetValue();
        m_intCmdState[sourceId].Set(value);
    }
}


[System.Serializable]
public class IntCmdTimedWithSource {

    public IntCmdSourceAsString m_source;
    public IntCmdTimedUTC m_intCmdValue;

    internal int GetValue()
    {
        return m_intCmdValue.GetValue();
    }

    internal void Set(int value)
    {
        m_intCmdValue.SetValue(value);
    }
}


[System.Serializable]
public class IntCmdSourceAsString {
    public string m_stringId;

    public IntCmdSourceAsString()
    {
        m_stringId = "";
    }

    public IntCmdSourceAsString(string stringId)
    {
        m_stringId = stringId;
    }
}


[System.Serializable]
public class IntCmdTimedUTC
{
    public int m_intCmd;
    public long m_dateTimeUTC;

    public IntCmdTimedUTC()
    {
        SetValue(0);
    }
    public IntCmdTimedUTC(int intCmd)
    {
        SetValue(intCmd);
    }
    public IntCmdTimedUTC(int intCmd, long dateTimeUTC)
    {
        Set(intCmd, dateTimeUTC);
    }
    public IntCmdTimedUTC(int intCmd, DateTime dateTimeUTC)
    {
        Set(intCmd, dateTimeUTC);
    }

    public void SetValue(in int value)
    {
        m_intCmd = value;
        m_dateTimeUTC = DateTime.UtcNow.Ticks;
    }
    public void Set(in int value, DateTime time)
    {
        m_intCmd = value;
        m_dateTimeUTC = time.Ticks;
    }
    public void Set(in int value, long time)
    {
        m_intCmd = value;
        m_dateTimeUTC = time;
    }
    public void GetValue(out int value)
    {
        value = m_intCmd;
    }
    public int GetValue()
    {
        return  m_intCmd;
    }
    public long GetTime() { return m_dateTimeUTC; }
}
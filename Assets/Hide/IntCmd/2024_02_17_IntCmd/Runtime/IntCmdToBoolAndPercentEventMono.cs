using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IntCmdToBoolAndPercentEventMono : MonoBehaviour
{

    public int m_lastPushIntCmd;
    public List<DigitToPercent09> m_digitToPercent = new List<DigitToPercent09>();
    public List<DigitToPercent0129> m_digitToPercent0129 = new List<DigitToPercent0129>();
    public List<DigitToBooleanOverZero> m_digitToBooleanOverZero = new List<DigitToBooleanOverZero>();
    public List<DigitToBooleanEqualTo> m_digitToBooleanEquals = new List<DigitToBooleanEqualTo>();
    public List<DigitToBooleanBetween> m_digitToBooleanBetween = new List<DigitToBooleanBetween>();



    public void PushNew(I_IntCmd command) {
        if(command!=null)
            m_lastPushIntCmd = command.GetValue();
        foreach (var item in m_digitToPercent)
        {
            IntCmdDigitUtility.GetDigitOf(command, item.m_digit, out byte value);
            item.m_onPercentPushed.Invoke(value / 9f);
        }
        foreach (var item in m_digitToPercent0129)
        {
            IntCmdDigitUtility.GetDigitOf(command, item.m_digit, out byte value);
            if (value == 0) { 
                item.m_onPercentPushed.Invoke(0);
            }
            else if (value == 1) { 
                item.m_onPercentPushed.Invoke(1);
            }
            else { 
                //0 1    0123 4567
                //0 1    2345 6789
            item.m_onPercentPushed.Invoke( (value-2) / 8);
            }
        }
        foreach (var item in m_digitToBooleanOverZero)
        {
            IntCmdDigitUtility.GetDigitOf(command, item.m_digit, out byte value);
            item.m_onBooleanPushed.Invoke(value > 0);
        }
        foreach (var item in m_digitToBooleanEquals)
        {
            IntCmdDigitUtility.GetDigitOf(command, item.m_digit, out byte value);
            item.m_onBooleanPushed.Invoke(value == 0);
        }
        foreach (var item in m_digitToBooleanBetween)
        {
            IntCmdDigitUtility.GetDigitOf(command, item.m_digit, out byte value);
            if (item.m_inclusive)
                item.m_onBooleanPushed.Invoke(value >= item.m_valueMin && value <= item.m_valueMax);
            else item.m_onBooleanPushed.Invoke(value > item.m_valueMin && value < item.m_valueMax);
        }
    }



    [System.Serializable]
    public class FloatEvent
    {

        public float m_lastValue;
        public UnityEvent<float> m_onPushedPercent;

        public void Invoke(float value) { m_onPushedPercent.Invoke(value); }
    }
    [System.Serializable]
    public class BoolEvent
    {
        public bool m_lastValue;
        public UnityEvent<bool> m_onPushedBoolean;
        public void Invoke(bool value) { m_onPushedBoolean.Invoke(value); }

    }


    public class DigitSplitter {

        [Tooltip("Just reminder of what you created it for")]
        public string m_context;
        public IntCmdDigitEnum m_digit;
    }

    [System.Serializable]
    public class DigitToPercent09 : DigitSplitter
    {
        public FloatEvent m_onPercentPushed;

    }
    [System.Serializable]
    public class DigitToPercent0129 : DigitSplitter
    {
        public FloatEvent m_onPercentPushed;
    }

    [System.Serializable]
    public class DigitToBooleanOverZero : DigitSplitter
    {
        public BoolEvent m_onBooleanPushed;
    }
    [System.Serializable]
    public class DigitToBooleanEqualTo : DigitSplitter
    {
        public byte m_value=9;
        public BoolEvent m_onBooleanPushed;
    }
    [System.Serializable]
    public class DigitToBooleanBetween : DigitSplitter
    {
        public byte m_valueMin=1;
        public byte m_valueMax=9;
        public bool m_inclusive = true;
        public BoolEvent m_onBooleanPushed;
    }

}

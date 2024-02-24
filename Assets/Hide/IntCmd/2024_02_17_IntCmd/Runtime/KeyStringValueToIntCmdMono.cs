using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyStringValueToIntCmdMono : MonoBehaviour
{


    public UnityEvent<I_IntCmd> m_onChanged;
    public UnityEvent<int> m_onChangedAsInt;
    public IntCmd m_intCmd;
    public bool m_lockFirstDigit=true;
    public int m_firstDigit = 1;

    public List<KeyToPercent> m_keyToPercent = new List<KeyToPercent>();
    public List<KeyToPercentInRangeToByte> m_keyToPercentInRange = new List<KeyToPercentInRangeToByte>();
    public void PushIn(string key, bool boolValue) {
        PushIn(key, boolValue ? 1 : 0);
      
       
    }
    public int m_previousInt;
    public void PushIn(string key, float floatValue) {

        if (m_lockFirstDigit)
            IntCmdDigitUtility.SetDigitOf(m_intCmd, IntCmdDigitEnum.DigitLeftRight0_Danger, m_firstDigit);
       
        foreach (var item in m_keyToPercent)
        {
            if (item.IsEquals(key))
            {
                if (floatValue == 0)
                {
                    IntCmdDigitUtility.SetDigitOf(m_intCmd, item.m_digit, 0);
                }
                else {
                    if (item.m_percentType == PercentType.Percent11)
                    {
                        float v = (floatValue + 1f) / 2f;
                        if (item.m_inverse)
                            v = 1f - v;
                        v = Math.Clamp(v, 0f, 1f);

                        IntCmdDigitUtility.SetDigitOf(m_intCmd, item.m_digit, Mathf.RoundToInt(v * 7f) + 2);
                    }
                    else if (item.m_percentType == PercentType.Percent01)
                    {
                        float v = (floatValue);
                        if (item.m_inverse)
                            v = 1f - v;
                        v = Math.Clamp(v, 0f, 1f);

                        IntCmdDigitUtility.SetDigitOf(m_intCmd, item.m_digit, Mathf.RoundToInt(v * 9) );
                    }
                }
            }
        }
        foreach (var item in m_keyToPercentInRange)
        {
            if (item.IsEquals(key))
            {
                bool v =
                    item.m_inclusive?
                    (floatValue >= item.m_min && floatValue <= item.m_max)
                :(floatValue > item.m_min && floatValue < item.m_max);

                if (item.m_inverse)
                    v = !v;

                IntCmdDigitUtility.SetDigitOf(m_intCmd, item.m_digit, v ? item.m_true: item.m_false);
            }
        }

        int value = m_intCmd.GetValue();
        if (m_previousInt !=  value) {
            m_previousInt =  value;
            m_onChanged.Invoke(m_intCmd);
            m_onChangedAsInt.Invoke(value);
        }
    }


    [System.Serializable]
    public class StringKey
    {
        public string m_stringKey;
        public IntCmdDigitEnum m_digit;

        public bool IsEquals(string key)
        {
            return key.Trim().ToLower() == m_stringKey.Trim().ToLower();
        }
    }

    [System.Serializable]
    public class KeyToPercent : StringKey
    {
        public PercentType m_percentType;
        public bool m_inverse;

    }
    
 
    [System.Serializable]
    public class KeyToPercentInRangeToByte : StringKey
    {

        public PercentType m_percentType;
        public float m_min=0.2f;
        public float m_max=1.0f;
        public byte m_false=0;
        public byte m_true=1;
        public bool m_inverse;
        public bool m_inclusive = true;

    }

    public enum PercentType { Percent11, Percent01 }
}

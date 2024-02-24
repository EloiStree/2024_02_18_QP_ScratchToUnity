using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDD_IntCmdDigitsWrapperMono : MonoBehaviour
{

    public IntCmdDigitsWrapperMono m_toAffect;
    public IntCmdDigitEnum m_digitTarget;
    public byte m_currentDigit;
    public byte m_setDigitWith;


    public bool m_isPositive = true;
    [Range(0, 2)]
    public int m_digit0;
    [Range(0, 9)]
    public int m_digit1;
    [Range(0, 9)]
    public int m_digit2;
    [Range(0, 9)]
    public int m_digit3;
    [Range(0, 9)]
    public int m_digit4;
    [Range(0, 9)]
    public int m_digit5;
    [Range(0, 9)]
    public int m_digit6;
    [Range(0, 9)]
    public int m_digit7;
    [Range(0, 9)]
    public int m_digit8;
    [Range(0, 9)]
    public int m_digit9;

    [ContextMenu("Get Digit")]
    public void GetDigit()
    {
        m_toAffect.GetValue(m_digitTarget, out m_currentDigit);
    }
    [ContextMenu("Set Digit")]
    public void SetDigit()
    {

        m_toAffect.SetValue(m_digitTarget, m_setDigitWith);
    }
    public void Update()
    {
        Refresh();
    }
    private void OnValidate()
    {
        Refresh();

    }

    private void Refresh()
    {
        if (m_toAffect == null)
            return;

        if (m_isPositive)
            m_toAffect.SetPositive();
        else m_toAffect.SetNegative();

        m_toAffect.SetValue(IntCmdDigitEnum.DigitLeftRight0_Danger, m_digit0);
        m_toAffect.SetValue(IntCmdDigitEnum.DigitLeftRight1, m_digit1);
        m_toAffect.SetValue(IntCmdDigitEnum.DigitLeftRight2, m_digit2);
        m_toAffect.SetValue(IntCmdDigitEnum.DigitLeftRight3, m_digit3);
        m_toAffect.SetValue(IntCmdDigitEnum.DigitLeftRight4, m_digit4);
        m_toAffect.SetValue(IntCmdDigitEnum.DigitLeftRight5, m_digit5);
        m_toAffect.SetValue(IntCmdDigitEnum.DigitLeftRight6, m_digit6);
        m_toAffect.SetValue(IntCmdDigitEnum.DigitLeftRight7, m_digit7);
        m_toAffect.SetValue(IntCmdDigitEnum.DigitLeftRight8, m_digit8);
        m_toAffect.SetValue(IntCmdDigitEnum.DigitLeftRight9, m_digit9);
        m_toAffect.NotifyChanged();
    }
}

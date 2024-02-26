using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IntCmdDigitsWrapperMono : AbstractIntCmdHolderMono, I_IntCmdGetDigit, I_IntCmdSetDigit 
{
    public AbstractIntCmdHolderMono m_value;


    private void Reset()
    {
         List<MonoBehaviour> test= new List<MonoBehaviour>();
         GetComponents < MonoBehaviour>(test);
        if (test.Count == 0 || test.Count == 1) {
            CreateHolder();
            CreateRepresentation();
        }

    }

    [ContextMenu("Create holder")]
    public void CreateHolder()
    {
        m_value= this.gameObject.AddComponent<IntCmdMono>();
    }

    [ContextMenu("Create holder")]
    public void CreateRepresentation() {
        IntCmdMonoRepresentationMono script =  this.gameObject.AddComponent<IntCmdMonoRepresentationMono>();
        script.SetIntAbstractHolder(m_value);

            }

    public UnityEvent<int> m_onValueReceived;
    public override I_IntCmd GetChildrenIntCmd()
    {
        return m_value;
    }

    public void GetValue(IntCmdDigitEnum index, out byte digit)
    {
       IntCmdDigitUtility.GetDigitOf(m_value, index, out digit);
    }

    public byte GetValue(IntCmdDigitEnum index)
    {
        IntCmdDigitUtility.GetDigitOf(m_value, index, out byte digit);
        return digit;
    }

    public void SetValue(IntCmdDigitEnum value, byte newValue)
    {
        IntCmdDigitUtility.SetDigitOf(m_value, value, newValue);
        NotifyChanged();
    }
    public void SetValue(IntCmdDigitEnum value, int newValue)
    {
        IntCmdDigitUtility.SetDigitOf(m_value, value, newValue);
        NotifyChanged();
    }

    public void SetValueAsPercent(IntCmdDigitEnum value, float newValue)
    {
        IntCmdDigitUtility.SetDigitOf(m_value, value, (byte)Mathf.Round(newValue*9));
        NotifyChanged();
    }


    public void SetDigitLeftRight0(int value) => SetValue(IntCmdDigitEnum.DigitLeftRight0_Danger, value);
    public void SetDigitLeftRight1(int value) => SetValue(IntCmdDigitEnum.DigitLeftRight1, value);
    public void SetDigitLeftRight2(int value) => SetValue(IntCmdDigitEnum.DigitLeftRight2, value);
    public void SetDigitLeftRight3(int value) => SetValue(IntCmdDigitEnum.DigitLeftRight3, value);
    public void SetDigitLeftRight4(int value) => SetValue(IntCmdDigitEnum.DigitLeftRight4, value);
    public void SetDigitLeftRight5(int value) => SetValue(IntCmdDigitEnum.DigitLeftRight5, value);
    public void SetDigitLeftRight6(int value) => SetValue(IntCmdDigitEnum.DigitLeftRight6, value);
    public void SetDigitLeftRight7(int value) => SetValue(IntCmdDigitEnum.DigitLeftRight7, value);
    public void SetDigitLeftRight8(int value) => SetValue(IntCmdDigitEnum.DigitLeftRight8, value);
    public void SetDigitLeftRight9(int value) => SetValue(IntCmdDigitEnum.DigitLeftRight9, value);

    public void SetDigitRightLeft0(int value) => SetValue(IntCmdDigitEnum.DigitRightLeft0, value);
    public void SetDigitRightLeft1(int value) => SetValue(IntCmdDigitEnum.DigitRightLeft1, value);
    public void SetDigitRightLeft2(int value) => SetValue(IntCmdDigitEnum.DigitRightLeft2, value);
    public void SetDigitRightLeft3(int value) => SetValue(IntCmdDigitEnum.DigitRightLeft3, value);
    public void SetDigitRightLeft4(int value) => SetValue(IntCmdDigitEnum.DigitRightLeft4, value);
    public void SetDigitRightLeft5(int value) => SetValue(IntCmdDigitEnum.DigitRightLeft5, value);
    public void SetDigitRightLeft6(int value) => SetValue(IntCmdDigitEnum.DigitRightLeft6, value);
    public void SetDigitRightLeft7(int value) => SetValue(IntCmdDigitEnum.DigitRightLeft7, value);
    public void SetDigitRightLeft8(int value) => SetValue(IntCmdDigitEnum.DigitRightLeft8, value);
    public void SetDigitRightLeft9(int value) => SetValue(IntCmdDigitEnum.DigitRightLeft9_Danger, value);



    public void SetDigitLeftRight0AsPercent(float value) => SetValueAsPercent(IntCmdDigitEnum.DigitLeftRight0_Danger, value);
    public void SetDigitLeftRight1AsPercent(float value) => SetValueAsPercent(IntCmdDigitEnum.DigitLeftRight1, value);
    public void SetDigitLeftRight2AsPercent(float value) => SetValueAsPercent(IntCmdDigitEnum.DigitLeftRight2, value);
    public void SetDigitLeftRight3AsPercent(float value) => SetValueAsPercent(IntCmdDigitEnum.DigitLeftRight3, value);
    public void SetDigitLeftRight4AsPercent(float value) => SetValueAsPercent(IntCmdDigitEnum.DigitLeftRight4, value);
    public void SetDigitLeftRight5AsPercent(float value) => SetValueAsPercent(IntCmdDigitEnum.DigitLeftRight5, value);
    public void SetDigitLeftRight6AsPercent(float value) => SetValueAsPercent(IntCmdDigitEnum.DigitLeftRight6, value);
    public void SetDigitLeftRight7AsPercent(float value) => SetValueAsPercent(IntCmdDigitEnum.DigitLeftRight7, value);
    public void SetDigitLeftRight8AsPercent(float value) => SetValueAsPercent(IntCmdDigitEnum.DigitLeftRight8, value);
    public void SetDigitLeftRight9AsPercent(float value) => SetValueAsPercent(IntCmdDigitEnum.DigitLeftRight9, value);
    public void SetDigitRightLeft0AsPercent(float value) => SetValueAsPercent(IntCmdDigitEnum.DigitRightLeft0, value);
    public void SetDigitRightLeft1AsPercent(float value) => SetValueAsPercent(IntCmdDigitEnum.DigitRightLeft1, value);
    public void SetDigitRightLeft2AsPercent(float value) => SetValueAsPercent(IntCmdDigitEnum.DigitRightLeft2, value);
    public void SetDigitRightLeft3AsPercent(float value) => SetValueAsPercent(IntCmdDigitEnum.DigitRightLeft3, value);
    public void SetDigitRightLeft4AsPercent(float value) => SetValueAsPercent(IntCmdDigitEnum.DigitRightLeft4, value);
    public void SetDigitRightLeft5AsPercent(float value) => SetValueAsPercent(IntCmdDigitEnum.DigitRightLeft5, value);
    public void SetDigitRightLeft6AsPercent(float value) => SetValueAsPercent(IntCmdDigitEnum.DigitRightLeft6, value);
    public void SetDigitRightLeft7AsPercent(float value) => SetValueAsPercent(IntCmdDigitEnum.DigitRightLeft7, value);
    public void SetDigitRightLeft8AsPercent(float value) => SetValueAsPercent(IntCmdDigitEnum.DigitRightLeft8, value);
    public void SetDigitRightLeft9AsPercent(float value) => SetValueAsPercent(IntCmdDigitEnum.DigitRightLeft9_Danger, value);

    private void OnValidate()
    {
        
    }
    public void NotifyChanged() {
        m_onValueReceived.Invoke(m_value.GetValue());
    }
    private void Update()
    {
        CheckForChange();
    }

    private void CheckForChange()
    {
        if (m_value.GetValue() != m_previous)
        {
            m_previous = m_value.GetValue();
            m_onValueReceived.Invoke(m_value.GetValue());
        }
    }

    public UnityEvent m_onNotifyValueChanged;
    public override void NotifyChildrenValueChanged()
    {
        m_onNotifyValueChanged.Invoke();
    }

    private int m_previous;
}


public abstract class AbstractIntCmdHolderMono : MonoBehaviour, I_IntCmd
{
    public abstract void NotifyChildrenValueChanged();
    public abstract I_IntCmd GetChildrenIntCmd();
    public int GetValue()
    {
        return GetChildrenIntCmd().GetValue();
    }

    public void GetValue(out int value)
    {
       GetChildrenIntCmd().GetValue(out value);
    }

    public void SetNegative()
    {
         GetChildrenIntCmd().SetNegative();
        NotifyChildrenValueChanged();
    }

    public void SetPositive()
    {
         GetChildrenIntCmd().SetPositive();
        NotifyChildrenValueChanged();
    }

    public void SetValue(int value)
    {
        GetChildrenIntCmd().SetValue(value);
        NotifyChildrenValueChanged();
    }

    public void SetValue(I_IntCmdGet value)
    {
        GetChildrenIntCmd().SetValue(value);
        NotifyChildrenValueChanged();
    }
}
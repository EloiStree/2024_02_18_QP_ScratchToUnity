using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public  class IntCmdMono : AbstractIntCmdHolderMono
{
    public IntCmd m_intCmdValue;
   
    public override I_IntCmd GetChildrenIntCmd()
    {
        return m_intCmdValue;
    }

    public override void NotifyChildrenValueChanged()
    {}
}

public interface I_IntCmd: I_IntCmdGet, I_IntCmdSet
{ 

}
public interface I_IntCmdGet
{
    public int GetValue();
    public void GetValue(out int value);
}
public interface I_IntCmdSet
{

    public void SetValue(int value);
    public void SetValue(I_IntCmdGet value);
    public void SetPositive();
    public void SetNegative();
}

public enum IntCmdDigitEnum
{
    DigitLeftRight0_Danger,
    DigitLeftRight1,
    DigitLeftRight2,
    DigitLeftRight3,
    DigitLeftRight4,
    DigitLeftRight5,
    DigitLeftRight6,
    DigitLeftRight7,
    DigitLeftRight8,
    DigitLeftRight9,

    DigitRightLeft0,
    DigitRightLeft1,
    DigitRightLeft2,
    DigitRightLeft3,
    DigitRightLeft4,
    DigitRightLeft5,
    DigitRightLeft6,
    DigitRightLeft7,
    DigitRightLeft8,
    DigitRightLeft9_Danger
}

public interface I_IntCmdGetDigit
{
    public void GetValue(IntCmdDigitEnum index, out byte digit);
    public byte GetValue(IntCmdDigitEnum index);
}

public interface I_IntCmdSetDigit
{
    public void SetValue(IntCmdDigitEnum value, byte newValue);
}


public class IntCmdDigitUtility
{


    internal static bool IsBetweenIncluding(I_IntCmdGet target, IntCmdDigitEnum digitIndex, byte min, byte max)
    {

        GetDigitOf(target, digitIndex, out byte b);
        return Math.Abs(b) >= min && Math.Abs(b) <= max;
    }
    public static bool IsNotZero(I_IntCmdGet target, IntCmdDigitEnum digitIndex)
    {

        GetDigitOf(target, digitIndex, out byte b);
        return Math.Abs(b) != 0;
    }

    public static void GetAsPercent0To1(I_IntCmdGet target, IntCmdDigitEnum digitIndex, out float percent)
    {

        GetDigitOf(target, digitIndex, out byte b);

        percent = b / 9f;
    }
    public static void GetAsPercent1To1(I_IntCmdGet target, IntCmdDigitEnum digitIndex, out float percent)
    {


        GetDigitOf(target, digitIndex, out byte b);
        percent = ((b / 9f)-1f)*2f;
    }
    public static void GetAsPercent1To1In29Format(I_IntCmdGet target, IntCmdDigitEnum digitIndex, out float percent)
    {


        GetDigitOf(target, digitIndex, out byte b);
        if (b == 0)
            percent = 0;
        else if (b == 1)
            percent = 1;
        else percent = ((b - 2f / 7f) - 1f) * 2f;
    }
    public static void GetAsPercent1To1In19Format(I_IntCmdGet target, IntCmdDigitEnum digitIndex, out float percent)
    {

        GetDigitOf(target, digitIndex, out byte b);
        if (b == 0)
            percent = 0;
        else percent = ((b - 1f / 8f) - 1f) * 2f;
    }


    public static void  GetDigitOf(I_IntCmdGet target, IntCmdDigitEnum digitIndex, out byte result)
    {

        GetDigitOf(target, digitIndex, out int v);
        result = (byte)v;

    }
    public static void GetDigitOf(I_IntCmdGet target, IntCmdDigitEnum digitIndex, out int result)
    {

        int value = target.GetValue();
        int indexLeftRight = GetNumericalIndexRightLeft(digitIndex);
        result = GetDigitAtIndexLeftRight(value, 9- indexLeftRight);

    }

    public static void SetDigitOf(I_IntCmd target, IntCmdDigitEnum digitIndex, int newDigit) {
        target.SetValue(
            SetDigitWithMath(target.GetValue(), GetNumericalIndexRightLeft(digitIndex),newDigit ));
    }
    static int SetDigitWithMath(int number, int position, int newDigit)
    {
        // Ensure the position is within the valid range
        if (position < 0)
        {
            throw new ArgumentException("Position must be non-negative.");
        }

        // Handle the sign separately
        int sign = (number < 0) ? -1 : 1;

        // Make the number positive for the calculations
        number = Math.Abs(number);

        // Calculate the multiplier to isolate the digit at the specified position
        int multiplier = (int)Math.Pow(10, position);

        // Calculate the new value by zeroing out the digit at the specified position and adding the new digit
        int updatedNumber = (number / (multiplier * 10)) * (multiplier * 10) + newDigit * multiplier + (number % multiplier);

        // Apply the original sign
        updatedNumber *= sign;

        return updatedNumber;
    }


    static int GetDigitAtIndexLeftRight(int num, int indexleftToRight)
    {
        int numDigits = (int)Math.Floor(Math.Log10(num)) + 1;
        if (indexleftToRight < 0 || indexleftToRight >= numDigits)
        {
            return 0; 
        }
        int digit = (int)(num / Math.Pow(10, numDigits - indexleftToRight - 1)) % 10;
        return digit;
    }


    public static int GetNumericalIndexRightLeft(IntCmdDigitEnum digitIndex) {

        switch (digitIndex)
        {
            case IntCmdDigitEnum.DigitLeftRight0_Danger: return 9;
            case IntCmdDigitEnum.DigitLeftRight1: return 8;
            case IntCmdDigitEnum.DigitLeftRight2: return 7;
            case IntCmdDigitEnum.DigitLeftRight3: return 6;
            case IntCmdDigitEnum.DigitLeftRight4: return 5;
            case IntCmdDigitEnum.DigitLeftRight5: return 4;
            case IntCmdDigitEnum.DigitLeftRight6: return 3;
            case IntCmdDigitEnum.DigitLeftRight7: return 2;
            case IntCmdDigitEnum.DigitLeftRight8: return 1;
            case IntCmdDigitEnum.DigitLeftRight9: return 0;
            case IntCmdDigitEnum.DigitRightLeft0: return 0;
            case IntCmdDigitEnum.DigitRightLeft1: return 1;
            case IntCmdDigitEnum.DigitRightLeft2: return 2;
            case IntCmdDigitEnum.DigitRightLeft3: return 3;
            case IntCmdDigitEnum.DigitRightLeft4: return 4;
            case IntCmdDigitEnum.DigitRightLeft5: return 5;
            case IntCmdDigitEnum.DigitRightLeft6: return 6;
            case IntCmdDigitEnum.DigitRightLeft7: return 7;
            case IntCmdDigitEnum.DigitRightLeft8: return 8;
            case IntCmdDigitEnum.DigitRightLeft9_Danger: return 9;
            default: throw new Exception();
        }
    }

    public static IntCmdDigitEnum GetDigitLeftToRight(int i)
    {
        switch (i)
        {
            case 0: return IntCmdDigitEnum.DigitLeftRight0_Danger;
            case 1: return IntCmdDigitEnum.DigitLeftRight1;
            case 2: return IntCmdDigitEnum.DigitLeftRight2;
            case 3: return IntCmdDigitEnum.DigitLeftRight3;
            case 4: return IntCmdDigitEnum.DigitLeftRight4;
            case 5: return IntCmdDigitEnum.DigitLeftRight5;
            case 6: return IntCmdDigitEnum.DigitLeftRight6;
            case 7: return IntCmdDigitEnum.DigitLeftRight7;
            case 8: return IntCmdDigitEnum.DigitLeftRight8;
            case 9: return IntCmdDigitEnum.DigitLeftRight9;
            default:
                throw new Exception("Should not be over 9");
        }
    }
    public  static IntCmdDigitEnum GetDigitRightToLeft(int i)
    {
        switch (i)
        {
            case 0: return IntCmdDigitEnum.DigitRightLeft0;
            case 1: return IntCmdDigitEnum.DigitRightLeft1;
            case 2: return IntCmdDigitEnum.DigitRightLeft2;
            case 3: return IntCmdDigitEnum.DigitRightLeft3;
            case 4: return IntCmdDigitEnum.DigitRightLeft4;
            case 5: return IntCmdDigitEnum.DigitRightLeft5;
            case 6: return IntCmdDigitEnum.DigitRightLeft6;
            case 7: return IntCmdDigitEnum.DigitRightLeft7;
            case 8: return IntCmdDigitEnum.DigitRightLeft8;
            case 9: return IntCmdDigitEnum.DigitRightLeft9_Danger;
            default:
                throw new Exception("Should not be over 9");
        }
    }

}



[System.Serializable]
public class IntCmd : I_IntCmd
{
    [SerializeField] int m_intCmdValue;

    public IntCmd(int intCmdValue)
    {
        m_intCmdValue = intCmdValue;
    }
    public IntCmd()
    {
        m_intCmdValue = 0;
    }

    public int GetValue() { return m_intCmdValue; }
    public void GetValue(out int value) { value = m_intCmdValue; }

    public void SetValue(int value)
    {
        m_intCmdValue = value;
    }

    public void SetValue(I_IntCmdGet value)
    {
        if(value!=null)
        m_intCmdValue = value.GetValue();
    }

    public void SetPositive()
    {
        if (Math.Sign(m_intCmdValue) < 0)
            m_intCmdValue *= -1;
    }

    public void SetNegative()
    {
        if (Math.Sign(m_intCmdValue) > 0)
            m_intCmdValue *= -1;
    }
}

[System.Serializable]
public class IntCmdEvent : UnityEvent<IntCmd> { }

[System.Serializable]
public class IntCmdDigitsEvent : UnityEvent<IntCmdDigits> { }



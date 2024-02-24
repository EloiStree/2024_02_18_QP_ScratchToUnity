using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntCmdToDroneCarDefaultMono : MonoBehaviour
{

    public IntCmdToDroneCarDefault m_value;

    public void Set(IntCmd intValue)
    {

        m_value.Set(intValue.GetValue());
    }
    public void Set(int intValue)
    {

        m_value.Set(intValue);
    }
    //public void Refresh()
    //{ 

    //    if (m_source == null)
    //        return;
    //    m_value.m_commandTypeIsDrone = m_source.m_value.GetCommandDigitType() == 1;
    //    if (m_value.m_commandTypeIsDrone)
    //    {

    //    }
    //    else
    //    {
    //        m_value.m_requestAction = false;
    //        m_value.m_requestActionIsGeneric = false;
    //        m_value.m_commandTypeIsDrone = false;
    //        m_value.m_actionDigit = 0;
    //        m_value.m_percentCarLeftFront = 0;
    //        m_value.m_percentCarRightFront = 0;
    //        m_value.m_percentCarLeftBack = 0;
    //        m_value.m_percentCarRightBack = 0;
    //        m_value.m_percentDroneLeftFront = 0;
    //        m_value.m_percentDroneRightFront = 0;
    //        m_value.m_percentDroneLeftBack = 0;
    //        m_value.m_percentDroneRightBack = 0;

    //    }
    //}

}
[System.Serializable]
public class IntCmdToDroneCarDefault
{
    public IntCmd m_intValue= new IntCmd();
    public IntCmdDigits m_intValueAsDigit = new IntCmdDigits();
    public IntCmdAsChar m_intChar = new IntCmdAsChar();

    public IntCmdToBinaryBools m_intBinary = new IntCmdToBinaryBools();
    public IntCmdToDroneCarDigits m_carDroneDigits = new IntCmdToDroneCarDigits();
    public IntCmdToDroneCarInput m_carDroneInput = new IntCmdToDroneCarInput();

    public void Set(in int intCmd)
    {
        
        IntCmdUtility.Convert( intCmd, out m_intValue);
        IntCmdUtility.Convert( intCmd, out m_intValueAsDigit);
        IntCmdUtility.Convert( intCmd, out m_intChar);
        IntCmdUtility.Convert( intCmd, out m_intBinary);
        IntCmdCarDroneUtility.Convert(intCmd, out m_carDroneDigits);
        IntCmdCarDroneUtility.Convert(intCmd, out m_carDroneInput);
    }
 
}

[System.Serializable]
public class IntCmdToDroneCarInput
{
    public CommandType m_commandDigit;
    [Range(0, 1f)]
    public float m_percentCarLeftFront;
    [Range(0, 1f)]
    public float m_percentCarRightFront;
    [Range(0, 1f)]
    public float m_percentCarLeftBack;
    [Range(0, 1f)]
    public float m_percentCarRightBack;
    [Range(-1f, 1f)]
    public float m_percentDroneLeftFront;
    [Range(-1f, 1f)]
    public float m_percentDroneRightFront;
    [Range(-1f, 1f)]
    public float m_percentDroneLeftBack;
    [Range(-1f, 1f)]
    public float m_percentDroneRightBack;
    public DigitAction m_actionDigit;  
}

[System.Serializable]
public class IntCmdAsChar
{
    public char m_0_char = (char)0;
    public char m_1_char = (char)0;
    public char m_2_char = (char)0;
    public char m_3_char = (char)0;

    public IntCmdAsChar()
    {
        Set( 0);
    }
    public IntCmdAsChar(in int value)
    {
        Set(in value);
    }

    public void Set(in int value) {

        byte[] byteArray = BitConverter.GetBytes(value);

        if (byteArray.Length >= 1)
            m_0_char = (char)byteArray[0];
        else m_0_char = ' ';

        if (byteArray.Length >= 2)
            m_1_char = (char)byteArray[1];
        else m_1_char = ' ';

        if (byteArray.Length >= 3)
            m_2_char = (char)byteArray[2];
        else m_2_char = ' ';

        if (byteArray.Length >= 4)
            m_3_char = (char)byteArray[3];
        else m_3_char = ' ';
    }
}
[System.Serializable]
public class IntCmdToBinaryBools
{
    public byte [] m_intAsBytes;
    public bool[] m_intAsBools;

    public IntCmdToBinaryBools(in int value)
    {
        Set(in value);
    }
    public IntCmdToBinaryBools()
    {
        Set(0);
    }

    public void Set(in int value)
    {

        m_intAsBytes = BitConverter.GetBytes(value);
        m_intAsBools = BytesToBooleans(m_intAsBytes);

    }
    public static bool[] BytesToBooleans(byte[] bytes)
    {
        bool[] booleans = new bool[bytes.Length * 8];

        for (int i = 0; i < bytes.Length; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                int index = i * 8 + j;
                booleans[index] = (bytes[i] & (1 << (7 - j))) != 0;
            }
        }

        return booleans;
    }
}


public enum DigitAction : byte { None, GenericAction, CustomAction0, CustomAction1, CustomAction2, CustomAction3, CustomAction4, CustomAction5, CustomAction6, CustomAction7 }
public enum CommandType : short { Int2_CarDroneBinary=2, Int1_CarDroneInput = 1, NInt1_CharInput=-1, NInt2_CustomCommand=-2 }

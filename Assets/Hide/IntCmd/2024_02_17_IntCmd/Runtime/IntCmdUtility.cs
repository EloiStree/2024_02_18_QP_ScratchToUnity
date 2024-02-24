using System;

public static class IntCmdUtility
{
    public static void ConvertIntToDigits(
        int value,
        ref byte DLR0,
        ref byte DLR1,
        ref byte DLR2,
        ref byte DLR3,
        ref byte DLR4,
        ref byte DLR5,
        ref byte DLR6,
        ref byte DLR7,
        ref byte DLR8,
        ref byte DLR9)
    {
        value = Math.Abs(value);
        DLR9
            = (byte)(value % 10);
        DLR8
            = (byte)(((value / 10)) % 10);
        DLR7
            = (byte)(((value / 100)) % 10);
        DLR6
            = (byte)(((value / 1000)) % 10);
        DLR5
            = (byte)(((value / 10000)) % 10);
        DLR4
            = (byte)(((value / 100000)) % 10);
        DLR3
            = (byte)(((value / 1000000)) % 10);
        DLR2
            = (byte)(((value / 10000000)) % 10);
        DLR1
            = (byte)(((value / 100000000)) % 10);
        DLR0
            = (byte)(((value / 1000000000)) % 10);
    }

    public static void Convert(in int value, out IntCmdDigits target)
    {
            target = new IntCmdDigits();
        ConvertIntToDigits( value,
            ref target.m_DLR0,
            ref target.m_DLR1,
            ref target.m_DLR2,
            ref target.m_DLR3,
            ref target.m_DLR4,
            ref target.m_DLR5,
            ref target.m_DLR6,
            ref target.m_DLR7,
            ref target.m_DLR8,
            ref target.m_DLR9
            );
    }

    public static void Convert(int value, out  IntCmd target)
    {
         target = new IntCmd(value);
         target.SetValue(value);
    }

    internal static void Convert(int intCmd, out IntCmdAsChar m_intChar)
    {
            m_intChar = new IntCmdAsChar(intCmd);
         m_intChar.Set(intCmd);
    }

    internal static void Convert(int intCmd, out IntCmdToBinaryBools m_intBinary)
    {
            m_intBinary = new IntCmdToBinaryBools(intCmd);
         m_intBinary.Set(intCmd);
    }
}

using System;

public static class IntCmdCarDroneUtility
{

    public static void ConvertDigitsToDroneCarDigits(in IntCmdDigits value, ref IntCmdToDroneCarDigits carDroneDigits)
    {
        if (carDroneDigits == null)
            carDroneDigits = new IntCmdToDroneCarDigits();
        carDroneDigits.m_9_action = value.m_DLR9;
        carDroneDigits.m_8_droneRightBack = value.m_DLR8;
        carDroneDigits.m_7_droneLeftBack = value.m_DLR7;
        carDroneDigits.m_6_droneRightFront = value.m_DLR6;
        carDroneDigits.m_5_droneLeftFront = value.m_DLR5;
        carDroneDigits.m_4_carRightBack = value.m_DLR4;
        carDroneDigits.m_3_carLeftBack = value.m_DLR3;
        carDroneDigits.m_2_carRightFront = value.m_DLR2;
        carDroneDigits.m_1_carLeftFront = value.m_DLR1;
        carDroneDigits.m_0_commands = value.m_DLR0;
    }


    public static void ConvertDigitsToInput(in IntCmdToDroneCarDigits digits, ref IntCmdToDroneCarInput input)
    {
        input.m_actionDigit = GetActionDigitEnum(in digits);
        input.m_commandDigit = GetCommandDigitEnum(in digits);
        input.m_percentCarLeftFront = GetControlStateAsPercent0To100(ref digits.m_1_carLeftFront);
        input.m_percentCarRightFront = GetControlStateAsPercent0To100(ref digits.m_2_carRightFront);
        input.m_percentCarLeftBack = GetControlStateAsPercent0To100(ref digits.m_3_carLeftBack);
        input.m_percentCarRightBack = GetControlStateAsPercent0To100(ref digits.m_4_carRightBack);
        input.m_percentDroneLeftFront = GetControlStateAsPercentN100ToP100(ref digits.m_5_droneLeftFront);
        input.m_percentDroneRightFront = GetControlStateAsPercentN100ToP100(ref digits.m_6_droneRightFront);
        input.m_percentDroneLeftBack = GetControlStateAsPercentN100ToP100(ref digits.m_7_droneLeftBack);
        input.m_percentDroneRightBack = GetControlStateAsPercentN100ToP100(ref digits.m_8_droneRightBack);
    }

    public static void Convert(in int value, out  IntCmdToDroneCarInput input)
    {
            input = new IntCmdToDroneCarInput();
        Convert(in value, out IntCmdToDroneCarDigits localdigits);
        ConvertDigitsToInput(in localdigits, ref input);
    }
    
    public static void Convert(in int value, out IntCmdToDroneCarDigits droneDigits)
    {
            droneDigits = new IntCmdToDroneCarDigits();
        IntCmdUtility.Convert(in value, out IntCmdDigits intDigits);
        ConvertDigitsToDroneCarDigits(in intDigits, ref droneDigits);
    }



    public static bool IsRequestingGeneralAction(in IntCmdToDroneCarDigits intRef) { return intRef.m_9_action == 1; }
    public static bool IsCommandCarDroneType(in IntCmdToDroneCarDigits intRef) { return intRef.m_0_commands == 1; }
    public static byte GetActionDigitAs(in IntCmdToDroneCarDigits intRef) { return (byte)intRef.m_9_action; }
    public static byte GetCommandDigitType(in IntCmdToDroneCarDigits intRef) { return (byte)intRef.m_0_commands; }
    public static DigitAction GetActionDigitEnum(in IntCmdToDroneCarDigits intRef) { return (DigitAction)intRef.m_9_action; }
    public static CommandType GetCommandDigitEnum(in IntCmdToDroneCarDigits intRef) { return (CommandType)intRef.m_0_commands; }


    public static float GetControlStateAsPercent0To100(ref byte targetValue)
    {
        if (targetValue == 1) return 100f;
        if (targetValue == 0) return 0f;
        return (targetValue - 1) / 8f;
    }
    public static float GetControlStateAsPercentN100ToP100(ref byte targetValue)
    {
        if (targetValue == 0) return 0f;
        return (((targetValue - 1) / 8f) * 2f) - 1f;
    }

}

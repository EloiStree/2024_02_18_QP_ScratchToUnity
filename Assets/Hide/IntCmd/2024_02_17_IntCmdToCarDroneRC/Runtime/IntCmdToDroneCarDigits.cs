using System;

[System.Serializable]
public class IntCmdToDroneCarDigits 
{
    public byte m_0_commands;
    public byte m_1_carLeftFront;
    public byte m_2_carRightFront;
    public byte m_3_carLeftBack;
    public byte m_4_carRightBack;
    public byte m_5_droneLeftFront;
    public byte m_6_droneRightFront;
    public byte m_7_droneLeftBack;
    public byte m_8_droneRightBack;
    public byte m_9_action;

    internal void Setvalue(int intCmd)
    {
        throw new NotImplementedException();
    }

    internal void SetValue(IntCmdDigits m_intValueAsDigit)
    {
        throw new NotImplementedException();
    }
}

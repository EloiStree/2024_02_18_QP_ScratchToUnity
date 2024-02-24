[System.Serializable]
public class IntCmdDigits
{
    public byte m_DLR0;
    public byte m_DLR1;
    public byte m_DLR2;
    public byte m_DLR3;
    public byte m_DLR4;
    public byte m_DLR5;
    public byte m_DLR6;
    public byte m_DLR7;
    public byte m_DLR8;
    public byte m_DLR9;

    public IntCmdDigits(int intCmdValue)
    {

        SetValue(intCmdValue);
    }
    public IntCmdDigits()
    {
        SetValue(0);
    }


    public void SetValue(in int value)
    {
        IntCmdUtility.ConvertIntToDigits( value,
         ref m_DLR0,
         ref m_DLR1,
         ref m_DLR2,
         ref m_DLR3,
         ref m_DLR4,
         ref m_DLR5,
         ref m_DLR6,
         ref m_DLR7,
         ref m_DLR8,
         ref m_DLR9
            );
    }
}



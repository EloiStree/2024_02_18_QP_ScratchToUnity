using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class IntCmdMonoRepresentationMono : MonoBehaviour
{

    public AbstractIntCmdHolderMono m_intCmd;

    public bool m_refreshButton;
    public int m_int;
    public string m_decimal;
    public string m_binary;
    public string m_binarySplitByByte;
    public string m_structure;
    public byte[] littleEndianBytes;
    public string littleEndianBytesAsString;
    public byte[] bigEndianBytes;
    public string bigEndianBytesAsString;
    void OnValidate()
    {
        Refresh();
    }

    [ContextMenu("Zero ")]
    public void ResetToZero()
    {
        m_intCmd.SetValue(0);
    }
    [ContextMenu("Max ")]
    public void Max()
    {
        m_intCmd.SetValue(int.MaxValue);
    }
    [ContextMenu("Min ")]
    public void Min()
    {
        m_intCmd.SetValue(-int.MaxValue);
    }
    [ContextMenu("Switch Sign")]
    public void SwitchSign()
    {
        m_intCmd.SetValue(-m_intCmd.GetValue());
    }

    public void Refresh()
    {
        m_refreshButton = true;
        if (m_intCmd == null)
            return;
        m_int = m_intCmd.GetValue();
        m_decimal = m_int.ToString();
        m_binary = ConvertToBinary(m_int);

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < m_binary.Length; i++)
        {
            sb.Append(m_binary[i]);
            if (i % 8 == 0) sb.Append(" ");

        }
        m_binarySplitByByte = sb.ToString();
        m_structure = PrintBitStructure(m_int);

        littleEndianBytes = ConvertToLittleEndianBytes(m_int);
        littleEndianBytesAsString = BytesToString(littleEndianBytes);

        bigEndianBytes = ConvertToBigEndianBytes(m_int);
        bigEndianBytesAsString = BytesToString(bigEndianBytes);
    }

    public void Update()
    {

        Refresh();
    }

    string ConvertToBinary(int number)
    {
        return System.Convert.ToString(number, 2).PadLeft(32, '0');
    }

    
    string  PrintBitStructure(int number)
    {
        string s = "";
        string binary = ConvertToBinary(number);
        for (int i = 0; i < binary.Length; i++)
        {
            s+=(binary[i] + " ");
        }
        return s;
    }



    byte[] ConvertToLittleEndianBytes(int number)
    {
        byte[] bytes = System.BitConverter.GetBytes(number);
        if (System.BitConverter.IsLittleEndian)
            return bytes;
        else
        {
            // Reverse the bytes if not little-endian
            System.Array.Reverse(bytes);
            return bytes;
        }
    }

    byte[] ConvertToBigEndianBytes(int number)
    {
        byte[] bytes = System.BitConverter.GetBytes(number);
        if (!System.BitConverter.IsLittleEndian)
            return bytes;
        else
        {
            // Reverse the bytes if little-endian
            System.Array.Reverse(bytes);
            return bytes;
        }
    }

    string BytesToString(byte[] bytes)
    {
        string result = "";
        for (int i = 0; i < bytes.Length; i++)
        {
            result += bytes[i].ToString("X2"); // Convert byte to hexadecimal string
            if (i < bytes.Length - 1)
                result += " ";
        }
        return result;
    }
}
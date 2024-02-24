using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System;
using UnityEngine.Events;
using System.Collections.Generic;




public interface I_IndexIntCmdGet
{
    public int GetIndexInt();
    public int GetCommandInt();
    public void GetIndexInt(out int value);
    public void GetCommandInt(out int value);
}
public interface I_IndexIntCmdSet
{
    public void SetIndexInt( int value);
    public void SetCommandInt( int value);
    public void Set(I_IndexIntCmdGet reference);
}
public interface I_IndexIntCmdSetGet : I_IndexIntCmdSet, I_IndexIntCmdGet
{
}



[System.Serializable]
public class IndexIntCmd: I_IndexIntCmdSetGet
{
    [SerializeField] int m_index;
    [SerializeField] int m_command;

    public IndexIntCmd(int index, int command)
    {
        m_index = index;
        m_command = command;
    }

    public int GetCommandInt(){return m_command;}
    public int GetIndexInt(){return m_index;}
    public void GetCommandInt(out int value) => value = m_command;
    public void GetIndexInt(out int value) => value = m_command;

    public void SetIndexInt(int value) => m_index = value;

    public void SetCommandInt(int value) => m_command = value;

    public void Set(I_IndexIntCmdGet reference)
    {
        SetIndexInt(reference.GetIndexInt());
        SetCommandInt(reference.GetCommandInt());
    }
}

[System.Serializable]
public struct IndexIntCmdStruct: I_IndexIntCmdSetGet
{
    [SerializeField] int m_index;
    [SerializeField] int m_command;

    public void Set(int index, int command)
    {
        m_index = index;
        m_command = command;
    }
    public void Set(I_IndexIntCmdGet reference)
    {
        SetIndexInt(reference.GetIndexInt());
        SetCommandInt(reference.GetCommandInt());
    }

    public int GetCommandInt() { return m_command; }
    public int GetIndexInt() { return m_index; }
    public void GetCommandInt(out int value) => value = m_command;
    public void GetIndexInt(out int value) => value = m_command;

    public void SetIndexInt(int value) => m_index = value;

    public void SetCommandInt(int value) => m_command = value;
}

[System.Serializable]
public class IndexIntCmdRef : I_IndexIntCmdSetGet
{
    public IndexIntCmdStruct m_value;
    public int GetCommandInt() { return m_value.GetCommandInt(); }
    public int GetIndexInt() { return m_value.GetIndexInt(); }
    public void GetCommandInt(out int value) => value = m_value.GetCommandInt();
    public void GetIndexInt(out int value) => value = m_value.GetIndexInt();

    public void SetIndexInt(int value) => m_value. SetIndexInt( value);

    public void SetCommandInt(int value) => m_value.SetCommandInt(  value);

    public void Set(I_IndexIntCmdGet reference)
    {
        SetIndexInt(reference.GetIndexInt());
        SetCommandInt(reference.GetCommandInt());
    }
}

public static class IndexIntCmdDelegate
{
    public delegate void InterfaceGet(I_IndexIntCmdGet intCommandInterface);
    public delegate void InterfaceGetSet(I_IndexIntCmdGet intCommandInterface);
    public delegate void Int(int intCommand);
}
public static class IndexIntCmdUnityEvent
{
    [System.Serializable]
    public class InterfaceGet : UnityEvent<I_IndexIntCmdGet> { }

    [System.Serializable]
    public class InterfaceGetSet : UnityEvent<I_IndexIntCmdSetGet> { }

    [System.Serializable]
    public class Int : UnityEvent<int> { }
}

public class UDPReceiverIndexIntCmdMono : MonoBehaviour
{
    private UdpClient m_udpClient;
    public int m_listenedPort = 123456;
    public IndexIntCmdStruct m_lastReceivedIndexIntCmd;
    public IndexIntCmdDelegate.InterfaceGet m_onSharpIndexInterfaceIntCmd;



    void Start()
    {
        // Create UDP client and start listening on the specified port
        m_udpClient = new UdpClient(m_listenedPort);
        m_udpClient.BeginReceive(new AsyncCallback(ReceiveCallback), null);

    }


    // Callback function to handle received data
    void ReceiveCallback(IAsyncResult ar)
    {
        IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, m_listenedPort);
        byte[] receivedBytes = m_udpClient.EndReceive(ar, ref remoteEP);
        int int1 = BitConverter.ToInt32(receivedBytes, 0);
        int int2 = BitConverter.ToInt32(receivedBytes, sizeof(int));
        m_lastReceivedIndexIntCmd.Set(int1, int2);
        if(m_onSharpIndexInterfaceIntCmd!=null)
            m_onSharpIndexInterfaceIntCmd.Invoke(m_lastReceivedIndexIntCmd);
        m_udpClient.BeginReceive(new AsyncCallback(ReceiveCallback), null);
    }
    public void LogReceivedIndexIntergerCommand(I_IndexIntCmdGet command)
    {

        Debug.Log("Received Index:" + command.GetIndexInt() + " Integers:" + command.GetCommandInt());
    }
    public void LogReceivedIndexIntergerCommand(int command)
    {

        Debug.Log("Received integers: " + command);
    }

    void OnDestroy()
    {
        if (m_udpClient != null)
            m_udpClient.Close();
    }
}

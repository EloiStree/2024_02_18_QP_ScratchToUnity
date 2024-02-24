using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IndexIntCmdToggleLocalServerMono : MonoBehaviour
{
    public UnityEvent<bool> m_onRequestForwardToServer;
    public UnityEvent<bool> m_onRequestForwardToLocal;



    public void SetTargetAsServer(bool tagetServer) {

        if (tagetServer)
            SetTargetAsServer();
        else SetTargetAsLocal();
    }

   
    [ContextMenu("Set Target As Server")]
    public  void SetTargetAsServer()
    {
        m_onRequestForwardToServer.Invoke(true) ;
        m_onRequestForwardToLocal.Invoke(false);
    }
    [ContextMenu("Set Target As Local")]
    public  void SetTargetAsLocal() {

        m_onRequestForwardToServer.Invoke(false);
        m_onRequestForwardToLocal.Invoke(true);
    }
    [ContextMenu("Set Target As Both")]
    public  void SetTargetAsBoth() {

        m_onRequestForwardToServer.Invoke(true);
        m_onRequestForwardToLocal.Invoke(true);
    }
}


public class IndexIntCmdToggleLocalServer
{

    public static void SetTargetAsServer() {

        foreach (var item in GameObject.FindObjectsOfType<IndexIntCmdToggleLocalServerMono>())
        {
            item.SetTargetAsServer();
        } 
    }
    public static void SetTargetAsLocal() {
        foreach (var item in GameObject.FindObjectsOfType<IndexIntCmdToggleLocalServerMono>())
        {
            item.SetTargetAsLocal();

        }

    }
    public static void SetTargetAsBoth() {
        foreach (var item in GameObject.FindObjectsOfType<IndexIntCmdToggleLocalServerMono>())
        {

            item.SetTargetAsBoth();
        }
    }
}
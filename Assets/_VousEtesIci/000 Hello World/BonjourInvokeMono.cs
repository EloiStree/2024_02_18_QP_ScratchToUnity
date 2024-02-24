using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonjourInvokeMono : MonoBehaviour
{
    public string m_phraseBonjour="Bonjour à vous";
    public string m_phraseCaVa="Ca va tout le monde ?";

    void Start()
    {
        Invoke("DireBonjour", 1);
        InvokeRepeating("CaVa", 3,2);
    }

    void DireBonjour()
    {
        Debug.Log(m_phraseBonjour);
    }
    void CaVa()
    {
        Debug.Log(m_phraseCaVa);
    }
}

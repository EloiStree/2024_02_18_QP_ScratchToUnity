using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonjourText : MonoBehaviour
{

    [TextArea(0,10)]
    public string m_queDire="Bojour à vous";
    public UnityEngine.UI.Text m_textElementAChanger;


    private void Update()
    {
        RafraichirLeText();
    }
    private void OnValidate()
    {
        RafraichirLeText();
    }
    private void RafraichirLeText()
    {
        if(m_textElementAChanger != null)
            m_textElementAChanger.text = m_queDire;
    }

  
}

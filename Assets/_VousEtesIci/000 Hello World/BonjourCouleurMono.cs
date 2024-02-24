using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BonjourCouleurMono : MonoBehaviour
{

    public Color m_couleurFond = Color.blue * 0.3f;
    public Color m_couleurDevant = Color.blue * 0.6f;
    public Color m_couleurText = Color.blue * 1f;

    public UnityEvent<Color> m_definirCouleurFond ;
    public UnityEvent<Color> m_definirCouleurDevant;
    public UnityEvent<Color> m_definirCouleurText;

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
        m_definirCouleurFond.Invoke(m_couleurFond);
        m_definirCouleurDevant.Invoke(m_couleurDevant);
        m_definirCouleurText.Invoke(m_couleurText);
    }

}

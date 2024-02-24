using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonjourUpdateMono : MonoBehaviour
{

    public long m_imageAffichee1;
    public long m_imageAffichee2;
    public long m_imageAffichee3;
 
    // Update is called once per frame
    void Update()
    {
        m_imageAffichee1 = m_imageAffichee1 + 1;
        m_imageAffichee2 += 1;
        m_imageAffichee3 ++;
    }

    public void DireBonjour() { 
    
    }
}

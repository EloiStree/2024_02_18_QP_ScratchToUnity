using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonjourOpenUrlMono : MonoBehaviour
{

    public string m_url= "https://www.remove.bg";
    public Texture2D m_avatarAvecFond;
    public Texture2D m_avatarSansFond;
    public void OuvrirUrl() {

        Application.OpenURL(m_url);

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonjourMono : MonoBehaviour
{

    /// <summary>
    /// Ce ci est une variable
    /// </summary>
    public string m_prenom="Eloi";

    void Awake()
    {
        Debug.Log("Avant toute chose");
    }


    void Start()
    {
        Debug.Log("Bonjour � vous");
    }


    public void OnEnable()
    {

        Debug.Log("Je suis visible");
    }
    public void OnDisable()
    {

        Debug.Log("Je suis cach�");
    }
    public void OnDestroy()
    {

        Debug.Log("Vous m'avez d�truit !!! ");
    }


    [ContextMenu("Je suis un context menu")]
    public void UtiliserUnContextMenu() {

        Debug.Log("Bien vous savez utiliser un context menu");
        Debug.Log("Tr�s utile pour tester rapidement un code");
    }
}

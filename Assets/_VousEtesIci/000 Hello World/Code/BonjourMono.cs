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
        Debug.Log("Bonjour à vous");
    }


    public void OnEnable()
    {

        Debug.Log("Je suis visible");
    }
    public void OnDisable()
    {

        Debug.Log("Je suis caché");
    }
    public void OnDestroy()
    {

        Debug.Log("Vous m'avez détruit !!! ");
    }


    [ContextMenu("Je suis un context menu")]
    public void UtiliserUnContextMenu() {

        Debug.Log("Bien vous savez utiliser un context menu");
        Debug.Log("Très utile pour tester rapidement un code");
    }
}

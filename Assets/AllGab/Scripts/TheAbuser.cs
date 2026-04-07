using UnityEngine;
using System.Collections.Generic;

public class TheAbuser : MonoBehaviour
{
    [Header("Liste Oggetti")]
    [Tooltip("Questi oggetti verranno DISATTIVATI al click")]
    public List<GameObject> oggettiDaDisattivare;

    [Tooltip("Questi oggetti verranno ATTIVATI al click")]
    public List<GameObject> oggettiDaAttivare;

    public void EseguiScambio()
    {
        // Ciclo per disattivare la prima lista
        foreach (GameObject obj in oggettiDaDisattivare)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }

        // Ciclo per attivare la seconda lista
        foreach (GameObject obj in oggettiDaAttivare)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
    }
}
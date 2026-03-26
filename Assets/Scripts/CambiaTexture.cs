using UnityEngine;

public class CambiaTexture : MonoBehaviour
{
    [Header("Riferimenti Oggetto 3D")]
    public Renderer targetRenderer; // L'oggetto che cambia aspetto

    [Header("Pannelli UI (opzionali)")]
    public GameObject pannelloPatologie;
    public GameObject pannelloUstioni;

    // QUESTA È LA FUNZIONE MAGICA
    public void ApplicaEffetto(Material nuovoMateriale)
    {
        if (targetRenderer != null && nuovoMateriale != null)
        {
            // Cambia il materiale all'istante
            targetRenderer.material = nuovoMateriale;
            Debug.Log("Materiale cambiato in: " + nuovoMateriale.name);
        }
    }

    // Se vuoi anche gestire l'apertura dei menu
    public void TogglePannello(GameObject pannello)
    {
        if (pannello != null)
        {
            bool statoAttuale = pannello.activeSelf;
            pannello.SetActive(!statoAttuale);
        }
    }
}

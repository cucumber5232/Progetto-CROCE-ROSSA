using UnityEngine;

public class TheManequinAbuser : MonoBehaviour
{
    [Header("Attiva/Disattiva oggetti per tag")]
    public bool Livido = false;
    public bool Marezzatura = false;
    public bool Abrasione = false;
    public bool Shock_Anafilattico = false;
    public bool Ustione_I_grado = false;
    public bool Ustione_II_grado = false;
    public bool Ustione_III_grado = false;
    public bool Defibrillazione = false;
    public bool Cintura = false;

    private bool _manichinoPresente = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Controlla se esiste almeno un oggetto con tag "Manichino"
        try
        {
            var manichini = GameObject.FindGameObjectsWithTag("Manichino");
            _manichinoPresente = manichini != null && manichini.Length > 0;
            if (!_manichinoPresente)
            {
                Debug.Log("[TheManequinAbuser] Nessun GameObject con tag 'Manichino' trovato in scena. Le modifiche non verranno applicate finché non esiste almeno un Manichino.");
            }
        }
        catch (UnityException ex)
        {
            _manichinoPresente = false;
            Debug.LogWarning($"[TheManequinAbuser] Tag 'Manichino' non definito: {ex.Message}. Operazione annullata.");
        }
    }

    // Metodo pubblico che esegue l'attivazione/disattivazione basata sui booleani.
    [ContextMenu("EseguiScambio")]
    public void EseguiScambio()
    {
        if (!_manichinoPresente)
        {
            Debug.Log("[TheManequinAbuser] EseguiScambio non eseguito: nessun 'Manichino' presente o tag non definito.");
            return;
        }

        ApplyTagState("Livido", Livido);
        ApplyTagState("Marezzatura", Marezzatura);
        ApplyTagState("Abrasione", Abrasione);
        ApplyTagState("Shock_Anafilattico", Shock_Anafilattico);
        ApplyTagState("Ustione_I_grado", Ustione_I_grado);
        ApplyTagState("Ustione_II_grado", Ustione_II_grado);
        ApplyTagState("Ustione_III_grado", Ustione_III_grado);
        ApplyTagState("Defibrillazione", Defibrillazione);
        ApplyTagState("Cintura", Cintura);

        Debug.Log("[TheManequinAbuser] EseguiScambio completato.");
    }

    // Helper che tenta di trovare oggetti per tag e li attiva/disattiva.
    private void ApplyTagState(string tag, bool state)
    {
        try
        {
            var objs = GameObject.FindGameObjectsWithTag(tag);
            if (objs == null || objs.Length == 0)
            {
                Debug.Log($"[TheManequinAbuser] Nessun oggetto con tag '{tag}' trovato.");
                return;
            }

            for (int i = 0; i < objs.Length; i++)
            {
                if (objs[i] != null)
                {
                    objs[i].SetActive(state);
                }
            }

            Debug.Log($"[TheManequinAbuser] Tag '{tag}': impostato su {(state ? "ATTIVO" : "DISATTIVO")} per {objs.Length} oggetti.");
        }
        catch (UnityException ex)
        {
            Debug.LogWarning($"[TheManequinAbuser] Tag '{tag}' non definito: {ex.Message}. Operazione ignorata per questo tag.");
        }
    }

    // Update lasciato vuoto ma presente per compatibilità con lo script originale
    void Update()
    {
    }
}

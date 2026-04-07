using UnityEngine;
public class Cavo : MonoBehaviour
{
    [Header("Configurazione Oggetti")]
    public Transform oggettoA;
    public Transform oggettoB;

    private LineRenderer line;

    void Start()
    {

        line = GetComponent<LineRenderer>();

        line.positionCount = 2;
        line.useWorldSpace = true;
    }

    void Update()
    {

        if (oggettoA != null && oggettoB != null && oggettoA.gameObject.activeInHierarchy && oggettoB.gameObject.activeInHierarchy)
        {
            // Se tutto è ok, assicurati che la linea sia visibile e aggiorna le posizioni
            line.enabled = true;
            line.SetPosition(0, oggettoA.position);
            line.SetPosition(1, oggettoB.position);
        }
        else
        {
            // Se uno dei due manca o è disattivato, nascondi la linea
            line.enabled = false;
        }
    }
}

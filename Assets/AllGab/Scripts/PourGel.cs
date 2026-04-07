using UnityEngine;

public class PourGel : MonoBehaviour
{
    [Header("Bottle Points")]
    public Transform centerPoint;
    public Transform originPoint;

    [Header("Pouring")]
    public ParticleSystem pourParticlePrefab;
    public Material lineMaterial;
    public float rayDistance = 5f;

    [Header("Pour Spawn")]
    public GameObject pourSpawnPrefab;
    private float pourSpawnInterval = 0.4f;
    private float pourSpawnLifetime = 1.2f;
    private float pourSpawnTimer = 0f;

    private ParticleSystem currentParticle;
    private LineRenderer lineRenderer;
    private bool isPouring = false;

    // Nuove variabili per la gestione del primo pour spawn
    private GameObject firstPourSpawn;
    private Rigidbody firstPourRigidbody;

    // Velocità di caduta lenta
    public float pourFallSpeed = 0.5f;

    void Start()
    {
        // Setup LineRenderer
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = lineMaterial;
        lineRenderer.positionCount = 2;
        lineRenderer.enabled = false;
        lineRenderer.startWidth = 0.005f;
        lineRenderer.endWidth = 0.005f;
    }

    void Update()
    {
        bool pouringNow = false;

        // Check if origin is below center (in world space)
        if (originPoint.position.y < centerPoint.position.y)
        {
            pouringNow = true;

            // Gestione spawn oggetto ogni 0.4s
            pourSpawnTimer += Time.deltaTime;
            if (pourSpawnTimer >= pourSpawnInterval || firstPourSpawn == null)
            {
                pourSpawnTimer = 0f;
                if (pourSpawnPrefab != null)
                {
                    GameObject spawned = Instantiate(pourSpawnPrefab, originPoint.position, Quaternion.identity);

                    // Solo il primo pour spawn ha la linea e non decade
                    if (firstPourSpawn == null)
                    {
                        firstPourSpawn = spawned;
                        // Aggiungi Rigidbody per la caduta lenta
                        firstPourRigidbody = firstPourSpawn.GetComponent<Rigidbody>();
                        if (firstPourRigidbody == null)
                        {
                            firstPourRigidbody = firstPourSpawn.AddComponent<Rigidbody>();
                        }
                        firstPourRigidbody.useGravity = false;
                        firstPourRigidbody.linearVelocity = Vector3.zero;
                    }
                    else
                    {
                        // Gli altri decadono normalmente
                        Destroy(spawned, pourSpawnLifetime);
                    }
                }
            }

            // Aggiorna posizione del primo pour spawn (segue x/z, cade lentamente su y)
            if (firstPourSpawn != null)
            {
                Vector3 targetPosition = firstPourSpawn.transform.position;
                targetPosition.x = originPoint.position.x;
                targetPosition.z = originPoint.position.z;
                targetPosition.y += -pourFallSpeed * Time.deltaTime;
                firstPourSpawn.transform.position = targetPosition;

                // Linea dal collo della bottiglia al primo pour spawn
                lineRenderer.enabled = true;
                lineRenderer.SetPosition(0, originPoint.position);
                lineRenderer.SetPosition(1, firstPourSpawn.transform.position);
            }
            else
            {
                lineRenderer.enabled = false;
            }

            // Gestione particelle (opzionale, puoi rimuovere se non servono più)
            if (currentParticle == null && firstPourSpawn != null)
            {
                currentParticle = Instantiate(pourParticlePrefab, firstPourSpawn.transform.position + Vector3.up * 0.01f, Quaternion.identity);
                currentParticle.transform.localScale = Vector3.one * 2f;
                currentParticle.Play();
            }
            else if (currentParticle != null && firstPourSpawn != null)
            {
                currentParticle.transform.position = firstPourSpawn.transform.position + Vector3.up * 0.01f;
                currentParticle.transform.localScale = Vector3.one * 2f;
            }
        }
        else
        {
            pouringNow = false;
        }

        if (!pouringNow)
        {
            DisablePour();
        }

        isPouring = pouringNow;
    }

    void DisablePour()
    {
        if (currentParticle != null)
        {
            currentParticle.Stop();
            Destroy(currentParticle.gameObject);
            currentParticle = null;
        }
        lineRenderer.enabled = false;
        pourSpawnTimer = 0f;

        // Distruggi il primo pour spawn solo quando il pour termina
        if (firstPourSpawn != null)
        {
            Destroy(firstPourSpawn);
            firstPourSpawn = null;
            firstPourRigidbody = null;
        }
    }
}

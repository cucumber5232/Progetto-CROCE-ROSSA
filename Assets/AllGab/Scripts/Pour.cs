using UnityEngine;

public class Pour : MonoBehaviour
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

    void Start()
    {
        // Setup LineRenderer
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = lineMaterial;
        lineRenderer.positionCount = 2;
        lineRenderer.enabled = false;
        lineRenderer.startWidth = 0.03f; 
        lineRenderer.endWidth = 0.03f;  
    }

    void Update()
    {
        bool pouringNow = false;

        // Check if origin is below center (in world space)
        if (originPoint.position.y < centerPoint.position.y)
        {
            RaycastHit hit;
            Vector3 rayOrigin = originPoint.position;
            Vector3 rayDirection = Vector3.down;

            if (Physics.Raycast(rayOrigin, rayDirection, out hit, rayDistance))
            {
                pouringNow = true;

                // Spawn or move particle system
                if (currentParticle == null)
                {
                    currentParticle = Instantiate(pourParticlePrefab, hit.point + Vector3.up * 0.01f, Quaternion.identity);
                    currentParticle.transform.localScale = Vector3.one * 2f; 
                    currentParticle.Play();
                }
                else
                {
                    currentParticle.transform.position = hit.point + Vector3.up * 0.01f;
                    currentParticle.transform.localScale = Vector3.one * 2f;
                }

                // Draw line from origin to particle
                lineRenderer.enabled = true;
                lineRenderer.SetPosition(0, originPoint.position);
                lineRenderer.SetPosition(1, currentParticle.transform.position);

                // Gestione spawn oggetto ogni 0.4s
                pourSpawnTimer += Time.deltaTime;
                if (pourSpawnTimer >= pourSpawnInterval)
                {
                    pourSpawnTimer = 0f;
                    if (pourSpawnPrefab != null)
                    {
                    
                        GameObject spawned = Instantiate(pourSpawnPrefab, originPoint.position, Quaternion.identity);
                        Destroy(spawned, pourSpawnLifetime);
                    }
                }
            }
            else
            {
                pouringNow = false;
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
    }
}

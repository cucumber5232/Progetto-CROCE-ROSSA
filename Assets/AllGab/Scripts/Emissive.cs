using UnityEngine;

public class Emissive : MonoBehaviour
{
    [SerializeField] private Material emissiveMaterial;
    [SerializeField] private float minIntensity = 1f;
    [SerializeField] private float maxIntensity = 5f;
    [SerializeField] private float speed = 0.2f;
    [SerializeField] private string emissionProperty = "_EmissionColor";

    private float t = 0f;
    private bool increasing = true;
    private Color baseEmissionColor;

    void Start()
    {
        if (emissiveMaterial == null)
        {
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
                emissiveMaterial = renderer.material;
        }
        if (emissiveMaterial != null && emissiveMaterial.HasProperty(emissionProperty))
        {
            baseEmissionColor = emissiveMaterial.GetColor(emissionProperty);
        }
        else
        {
            Debug.LogWarning("Emissive material or emission property not set correctly.");
            enabled = false;
        }
    }

    void Update()
    {
        if (increasing)
        {
            t += Time.deltaTime * speed;
            if (t >= 1f)
            {
                t = 1f;
                increasing = false;
            }
        }
        else
        {
            t -= Time.deltaTime * speed;
            if (t <= 0f)
            {
                t = 0f;
                increasing = true;
            }
        }

        float intensity = Mathf.Lerp(minIntensity, maxIntensity, t);
        emissiveMaterial.SetColor(emissionProperty, baseEmissionColor * intensity);
    }
}

using UnityEngine;

public class dropHitbox : MonoBehaviour
{
    [SerializeField] private Material newMaterial;

    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("benda"))
        {
            SkinnedMeshRenderer rend = other.gameObject.GetComponent<SkinnedMeshRenderer>();

            rend.material = newMaterial;
        }
    }

    void Update()
    {

    }
}

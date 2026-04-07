using UnityEngine;


[RequireComponent(typeof(SkinnedMeshRenderer))]
public class ClothCollider : MonoBehaviour
{
    private SkinnedMeshRenderer smr;
    private BoxCollider boxCollider;


    private float extentX;
    private float extentY;
    private float extentZ;

    private void Awake()
    {
        smr = GetComponent<SkinnedMeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if (smr == null || boxCollider == null) return;

        Bounds meshBounds = smr.localBounds;

        extentX = meshBounds.extents.x * 15f * 4;
        extentY = meshBounds.extents.y * 0.14f * 4;
        extentZ = meshBounds.extents.z * 15f * 4;

        boxCollider.size = new Vector3(extentX, extentY, extentZ);

  
        Vector3 center = meshBounds.center;
        center.x *= 10f;
        center.y *= 0.14f;
        center.z *= 10f;
        boxCollider.center = center;

        if (boxCollider == null)
            boxCollider = gameObject.AddComponent<BoxCollider>();
    }

}

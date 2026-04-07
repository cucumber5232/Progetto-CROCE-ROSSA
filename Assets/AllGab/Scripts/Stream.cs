using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Stream : MonoBehaviour
{
   private LineRenderer lineRenderer = null;
   private ParticleSystem splashparticle = null;


    private Coroutine pourCoroutine = null;
    private Vector3 targetposition = Vector3.zero;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        splashparticle = GetComponentInChildren<ParticleSystem>();
    }

    public void Begin()
    {
        StartCoroutine(UpdateParticle());
        pourCoroutine = StartCoroutine(BeginPour());
    }

    public void End()
    {
        StopCoroutine(pourCoroutine);
        pourCoroutine = StartCoroutine(EndPour());
    }

    private IEnumerator EndPour()
    {
        while (!HasReachedPosition(0, targetposition))
        {
            AnimateToPosition(0, targetposition);
            AnimateToPosition(1, targetposition);
            yield return null;
        }

        Destroy(gameObject);
    }

    private void Start()
    {
        MoveToPosition(0, targetposition);
        MoveToPosition(1, targetposition);
    }

    private IEnumerator BeginPour()
    {
        while (gameObject.activeSelf)
        {
            targetposition = FindEndPoint();

            MoveToPosition(0, transform.position);
            AnimateToPosition(1, targetposition);

            yield return null;
        }
    }

    private Vector3 FindEndPoint() 
    {

        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);

        Physics.Raycast(ray, out hit, 2.0f);
        Vector3 endPoint = hit.collider ? hit.point : ray.GetPoint(2.0f);

        return endPoint;
    }

    private void MoveToPosition(int index, Vector3 position)
    {
        lineRenderer.SetPosition(index, targetposition);
    }

    private void AnimateToPosition(int index, Vector3 targetPosition)
    {
       Vector3 currentPosition = lineRenderer.GetPosition(index);
       Vector3 newPosition = Vector3.MoveTowards(currentPosition, targetPosition, Time.deltaTime * 1.75f);
       lineRenderer.SetPosition(index, newPosition);
    }

    private bool HasReachedPosition(int index, Vector3 targetPosition)
    {
        Vector3 currentPosition = lineRenderer.GetPosition(index);
        return currentPosition == targetPosition;
    }

    private IEnumerator UpdateParticle()
    {
        while(gameObject.activeSelf)
        {
            splashparticle.transform.position = targetposition;

            bool isHitting = HasReachedPosition(1, targetposition);
            splashparticle.gameObject.SetActive(isHitting);

            yield return null;
        }
    }
}

using UnityEngine;

public class CompareCanvas : MonoBehaviour
{
    public GameObject patologie;
    public GameObject trattamenti;
    public GameObject ustioni;

    public void Patologie()
    {
        if (patologie!=null)
        {
            if(patologie.activeSelf==true)
            {
                patologie.SetActive(false);
                ustioni.SetActive (false);
            }

            else
            {
                patologie.SetActive(true);
            }
        }
    }

    public void Trattamenti()
    {
        if(trattamenti!=null)
        {
            if(trattamenti.activeSelf==true)
            {
                trattamenti.SetActive(false);
            }
            else
            {
                trattamenti.SetActive(true);
            }
        }
    }

    public void Ustioni()
    {
        if (ustioni != null)
        {
            if (ustioni.activeSelf == true)
            {
                ustioni.SetActive(false);
            }

            else
            {
                ustioni.SetActive(true);
            }
        }
    }
}

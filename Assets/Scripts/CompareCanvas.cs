using UnityEngine;

public class CompareCanvas : MonoBehaviour
{

    public GameObject patologie;
    public GameObject trattamenti;
    public GameObject ustioni;

    
    public GameObject canvas;
    public GameObject canvas2;
    public void Compare()
    {
        if (patologie!=null)
        {
            if(patologie.activeSelf==true)
            {

                patologie.SetActive(false);
                ustioni.SetActive (false);

                canvas.SetActive(false);
                canvas2.SetActive(false);

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

    //public void Ustioni()
    //{
    //    if (canvas2!=null)
    //    {
    //        if(canvas2.activeSelf==true)
    //        {
    //            canvas2.SetActive(false);
    //        }

    //        else
    //        {
    //            canvas2.SetActive(true);
    //        }
    //    }
    //}
}

using UnityEngine;

public class CompareCanvas : MonoBehaviour
{
    public GameObject canvas;
    public GameObject canvas2;
    public void Compare()
    {
        if(canvas!=null)
        {
            if(canvas.activeSelf == true)
            {
                canvas.SetActive(false);
                canvas2.SetActive(false);
            }

            else
            {
                canvas.SetActive(true);
            }
        }    
    }

    public void Ustioni()
    {
        if (canvas2!=null)
        {
            if(canvas2.activeSelf==true)
            {
                canvas2.SetActive(false);
            }

            else
            {
                canvas2.SetActive(true);
            }
        }
    }
}

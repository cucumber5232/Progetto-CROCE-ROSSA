using UnityEngine;

public class CompareCanvas : MonoBehaviour
{
    public GameObject canvas;
    public void Compare()
    {
        if(canvas!=null)
        {
            if(canvas.activeSelf == true)
            {
                canvas.SetActive(false);
            }

            else
            {
                canvas.SetActive(true);
            }
        }    
    }
}

using UnityEngine;

public class CompareSottomenu : MonoBehaviour
{
    public GameObject canvas;
    public GameObject canvas2;
    public void Compare()
    {
            if (canvas.activeSelf == true)
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

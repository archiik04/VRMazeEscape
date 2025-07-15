using UnityEngine;

public class LightColorChanger : MonoBehaviour
{
    [SerializeField] private Light targetLight;

    public void SetLightRed()
    {
        if (targetLight != null)
        {
            targetLight.color = Color.red;
        }
        
    }
    public void SetLightBlue()
    {
        if (targetLight != null)
        {
            targetLight.color = Color.blue;
        }
        
    }
    public void SetLightGreen()
    {
        if (targetLight != null)
        {
            targetLight.color = Color.green;
        }
        
    }
}

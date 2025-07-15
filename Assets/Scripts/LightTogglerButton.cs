using UnityEngine;

public class LightTogglerButton : MonoBehaviour
{
    [Header("Assign the Light to toggle")]
    [SerializeField] private Light targetLight;

    public void ToggleLight()
    {
        if (targetLight != null)
        {
            targetLight.enabled = !targetLight.enabled;
        }
        else
        {
            Debug.LogWarning("LightToggler: No Light assigned in Inspector.");
        }
    }
}

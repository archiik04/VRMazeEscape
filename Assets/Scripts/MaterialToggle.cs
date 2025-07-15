using UnityEngine;

public class MaterialToggle : MonoBehaviour
{
    [Header("Assign the object with Renderer (e.g., Cube)")]
    [SerializeField] private Renderer targetObject;

    [Header("Material 1 (first click)")]
    [SerializeField] private Material material1;

    [Header("Material 2 (second click)")]
    [SerializeField] private Material material2;

    private bool useFirstMaterial = true;

    public void ToggleMaterial()
    {
        if (targetObject != null && material1 != null && material2 != null)
        {
            targetObject.material = useFirstMaterial ? material1 : material2;
            useFirstMaterial = !useFirstMaterial;
        }
        else
        {
            Debug.LogWarning("MaterialToggle: Missing references. Check Inspector.");
        }
    }
}

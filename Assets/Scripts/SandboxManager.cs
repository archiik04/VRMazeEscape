using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using TMPro;

public class SandboxManager : MonoBehaviour
{
    [Header("Lighting")]
    [SerializeField] private Light sandboxLight;
    [SerializeField] private TMP_Text lightButton;

    [Header("Gravity")]
    [SerializeField] private TMP_Text gravityButton;

    [Header("Materials")]
    [SerializeField] private TMP_Text materialButton;
    [SerializeField] private Material primaryMaterial;
    [SerializeField] private Material secondaryMaterial;

    [Header("Box Objects")]
    [SerializeField] private GameObject[] boxes;

    [Header("FPS Display (Optional)")]
    [SerializeField] private TMP_Text fpsText;

    private bool gravityStatus = true;
    private bool lightStatus = true;
    private bool primaryMatStatus = true;
    private float deltaTime = 0.0f;

    void Start()
    {
        Debug.Log($"Light button null? {lightButton == null}");
        Debug.Log($"Initial text: {lightButton?.text}");
    }

    void Update()
    {
        // Optional FPS counter
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        if (fpsText != null)
            fpsText.text = $"FPS: {Mathf.Ceil(fps)}";
    }

    public void SwitchLight()
    {
        if (sandboxLight != null)
            sandboxLight.enabled = !sandboxLight.enabled;

        if (lightButton != null)
            lightButton.text = lightStatus ? "OFF" : "ON";

        lightStatus = !lightStatus;
    }

    public void ToggleLightColor(string colorName)
    {
        if (sandboxLight == null) return;

        switch (colorName.ToLower())
        {
            case "red":
                sandboxLight.color = Color.red;
                break;
            case "blue":
                sandboxLight.color = Color.cyan;
                break;
            case "green":
                sandboxLight.color = Color.green;
                break;
        }
    }

    public void ToggleGravity()
    {
        if (gravityButton != null)
            gravityButton.text = gravityStatus ? "OFF" : "ON";

        foreach (GameObject box in boxes)
        {
            if (box.TryGetComponent<Rigidbody>(out var rb))
                rb.useGravity = !rb.useGravity;
        }

        gravityStatus = !gravityStatus;
    }

    public void ToggleMaterial()
    {
        if (materialButton != null)
            materialButton.text = primaryMatStatus ? "OFF" : "ON";

        foreach (GameObject box in boxes)
        {
            if (box.TryGetComponent<Renderer>(out var rend))
            {
                rend.material = primaryMatStatus ? primaryMaterial : secondaryMaterial;
            }
        }

        primaryMatStatus = !primaryMatStatus;
    }
}

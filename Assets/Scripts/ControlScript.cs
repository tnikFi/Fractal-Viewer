using UnityEngine;

/// <summary>
///     Handles panning and zooming as well as updating the fractal texture when needed
/// </summary>
public class ControlScript : MonoBehaviour
{
    private static readonly int Scale = Shader.PropertyToID("_Scale");
    private static readonly int XOffsetLow = Shader.PropertyToID("_XOffset");
    private static readonly int YOffsetHigh = Shader.PropertyToID("_YOffset");
    private static readonly int AspectRatio = Shader.PropertyToID("_Aspect");
    public Material fractalMaterial;

    public float mouseSensitivity = 0.5f;

    private void Start()
    {
        fractalMaterial.SetFloat(Scale, 4f);
        fractalMaterial.SetFloat(XOffsetLow, 0f);
        fractalMaterial.SetFloat(YOffsetHigh, 0f);
    }

    private void Update()
    {
        // Update aspect ratio
        fractalMaterial.SetFloat(AspectRatio, (float) Screen.width / Screen.height);

        // Get previous values
        var oldXOffset = fractalMaterial.GetFloat(XOffsetLow);
        var oldYOffset = fractalMaterial.GetFloat(YOffsetHigh);

        // If the zoom changes, update the texture
        if (Input.mouseScrollDelta.y != 0)
        {
            // Zoom in and out with the mouse wheel, but don't let it go below 0. Zoom should get slower as the scale gets smaller
            var oldScale = fractalMaterial.GetFloat(Scale);
            fractalMaterial.SetFloat(Scale, Mathf.Max(0, oldScale - Input.mouseScrollDelta.y * 0.1f * oldScale));
        }

        // Pan the fractal with the mouse
        if (Input.GetMouseButton(0))
        {
            // Calculate new offsets
            var scale = fractalMaterial.GetFloat(Scale);
            var xOffset = oldXOffset - Input.GetAxis("Mouse X") * mouseSensitivity * scale;
            var yOffset = oldYOffset - Input.GetAxis("Mouse Y") * mouseSensitivity * scale;

            // Set the x and y offset properties of the fractal material
            fractalMaterial.SetFloat(XOffsetLow, xOffset);
            fractalMaterial.SetFloat(YOffsetHigh, yOffset);
        }
    }
}
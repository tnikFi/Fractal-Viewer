using UnityEngine;

public class ScreenDrawer : MonoBehaviour
{
    public Material fractalMaterial;

    private RenderTexture _destination;

    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(null, _destination, fractalMaterial);
    }
}
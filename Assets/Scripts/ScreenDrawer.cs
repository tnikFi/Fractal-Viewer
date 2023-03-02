using UnityEngine;

public class ScreenDrawer : MonoBehaviour
{
    public Texture2D pixelTexture;
    public TextureProvider textureProvider;
    public ColorProvider colorProvider;

    void Start()
    {
        pixelTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        pixelTexture.Apply();
    }

    private void OnPreRender()
    {
        if (Screen.width != pixelTexture.width || Screen.height != pixelTexture.height)
        {
            pixelTexture.Reinitialize(Screen.width, Screen.height);
            pixelTexture.Apply();
        }
    }

    // Render the texture on the render texture
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        // Get the texture from the provider
        var texture = textureProvider.GetTexture(pixelTexture.width, pixelTexture.height, colorProvider);
        
        // Set the pixels of the texture
        pixelTexture.SetPixels(texture);
        pixelTexture.Apply();
        
        Graphics.Blit(pixelTexture, destination);
    }
}
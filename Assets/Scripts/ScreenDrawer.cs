using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class ScreenDrawer : MonoBehaviour
{
    public Texture2D pixelTexture;
    public TextureProvider textureProvider;
    public ColorProvider colorProvider;
    
    private RenderTexture _destination;

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

    public void Render()
    {
        // Get the texture from the provider
        var texture = textureProvider.GetTexture(pixelTexture.width, pixelTexture.height, colorProvider);

        // Set the pixels of the texture
        pixelTexture.SetPixels(texture);
        pixelTexture.Apply();

        Graphics.Blit(pixelTexture, _destination);
    }

    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        _destination = dest;
        Render();
    }
}
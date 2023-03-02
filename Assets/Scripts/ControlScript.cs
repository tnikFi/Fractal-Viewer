using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles panning and zooming as well as updating the fractal texture when needed
/// </summary>
public class ControlScript : MonoBehaviour
{
    public TextureProvider textureProvider;
    public ColorProvider colorProvider;
    
    public float mouseSensitivity = 0.5f;

    private void Update()
    {
        // If the zoom changes, update the texture
        if (Input.mouseScrollDelta.y != 0)
        {
            // Zoom in and out with the mouse wheel, but don't let it go below 0. Zoom should get slower as the scale gets smaller
            colorProvider.scale += Input.mouseScrollDelta.y * 0.1f * colorProvider.scale;

            textureProvider.ClearCache();
        }
        
        // Pan the fractal with the mouse
        if (Input.GetMouseButton(0))
        {
            colorProvider.xOffset -= Input.GetAxis("Mouse X") * 0.1f * colorProvider.scale;
            colorProvider.yOffset -= Input.GetAxis("Mouse Y") * 0.1f * colorProvider.scale;
            
            textureProvider.ClearCache();
        }
    }
}

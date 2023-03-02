using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class ColorProvider : MonoBehaviour
{
    public double scale = 1;
    public double xOffset = 0;
    public double yOffset = 0;
    public Gradient gradient;
    public int maxIterations = 100;

    // Calculate whether a point is in the Mandelbrot set. More iterations give a more accurate result, but take longer.
    public int CalculateMandelbrotIterations(float x, float y)
    {
        var relativeXCentered = (x / Screen.width - 0.5f) * 2;
        var relativeYCentered = (y / Screen.height - 0.5f) * 2;
        var trueX = relativeXCentered * scale + xOffset;
        var trueY = relativeYCentered * scale + yOffset;
        
        var c = new Complex(trueX, trueY);
        var z = new Complex(0, 0);
        var iterations = 0;
        while (iterations < maxIterations && z.Magnitude < 2)
        {
            z = z * z + c;
            iterations++;
        }
        return iterations;
    }
    
    // Debug method to get the color of a point. Shows the center of the screen as black, and the corners as different colors.
    public Color GetDebugColor(float x, float y)
    {
        var color = new Color(x / Screen.width, y / Screen.height, 0);
        return color;
    }
    
    public Color GetColor(int x, int y)
    {
        var iterations = CalculateMandelbrotIterations(x, y);
        var color = gradient.Evaluate(iterations / (float)maxIterations);
        return color;
    }
}
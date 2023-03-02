using System.Threading.Tasks;
using UnityEngine;

public class TextureProvider : MonoBehaviour
{
    public Color[] GetTexture(int width, int height)
    {
        var result = new Color[width * height];

        // Create the texture with up to 4 threads
        Parallel.For(0, result.Length, new ParallelOptions { MaxDegreeOfParallelism = 4 }, i =>
        {
            var x = i % width;
            var y = i / width;
            var color = new Color(x / (float)width, y / (float)height, 0);
            result[i] = color;
        });
        
        return result;
    } 
}

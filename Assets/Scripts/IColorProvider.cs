using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IColorProvider
{
    /// <summary>
    /// Get the color at the given position
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    Color GetColor(int x, int y);
}

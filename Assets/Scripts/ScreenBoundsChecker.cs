using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBoundsChecker : IBoundsChecker
{
    private float screenWidth;
    private float screenHeight;

    public ScreenBoundsChecker()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
    }

    public bool IsWithinBounds(Vector3 position)
    {
        float halfWidth = screenWidth / 2f;
        float halfHeight = screenHeight / 2f;

        float minX = -halfWidth;
        float maxX = halfWidth;
        float minY = -halfHeight;
        float maxY = halfHeight;

        return position.x > minX && position.x < maxX && position.y > minY && position.y < maxY;
    }

}

using UnityEngine;
using UnityEditor;

public class MathHelper
{
    public static Vector3 getWorldMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public static float getAngle(Vector2 direction)
    {
        return ((Mathf.Atan2(direction.y, direction.x) / Mathf.PI) * 180f);
    }
}
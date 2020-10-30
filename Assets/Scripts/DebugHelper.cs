using UnityEngine;

public static class DebugHelper
{
    static bool isActive = true;

    public static void drawBallistaToMouseDistance(Vector3 bp)
    {
        if (isActive)
        {
            Debug.DrawLine(bp, MathHelper.getWorldMousePosition(), Color.white, 0.05f);
        }
    }
}

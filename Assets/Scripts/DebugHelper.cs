using UnityEngine;

public static class DebugHelper
{
    static bool IsActive = true;

    public static void drawBallistaToMouseDistance(Vector3 bp)
    {
        if (IsActive)
        {
            Debug.DrawLine(bp, MathHelper.getWorldMousePosition(), Color.white, 0.05f);
        }
    }
}

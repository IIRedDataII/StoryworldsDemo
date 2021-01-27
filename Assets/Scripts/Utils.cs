using System;
using UnityEngine;

public static class Utils
{

    // turns of/on all player controls
    public static void SetPlayerControls(bool active)
    {
        PlayerMovement.CanMove = active;
        PlayerInteract.CanInteract = active;
        PlayerShoot.AllowInput = active;
    }
    
    // converts a 2D vector to an angle value in degree ((1, 0) is 0)
    public static double VectorToAngle(Vector2 vector)
    {
        double angleDeg = 180 / Math.PI * Math.Asin(Math.Abs(vector.y) / vector.magnitude);
        
        if (vector.x < 0)
            angleDeg = 180 - angleDeg;
        if (vector.y < 0)
            angleDeg *= -1;

        return angleDeg;
    }
    
    // converts an angle value in degree to a 2D vector (0 is (1, 0))
    public static Vector2 AngleToVector(double angleDeg)
    {
        double angleRad = angleDeg * Math.PI / 180;
        return new Vector2((float) Math.Cos(angleRad), (float) Math.Sin(angleRad)).normalized;
    }

    // checks wether the passed id is already used. returns false is yes, stores the new id and returns true is no.
    public static bool CheckOneTimeMessage(GameData.OneTimeMessageID messageId)
    {
        if (GameData.Instance.TriggeredMessages.Contains(messageId))
            return false;
        GameData.Instance.TriggeredMessages.Add(messageId);
        return true;
    }

}

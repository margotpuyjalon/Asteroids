using UnityEngine;

public enum ShipColor {
    NORMAL, BACKGROUND, ASTEROID
}
public class PerceptiveParameters
{
    public static float inertia = 0f;
    
    public static float lagPlayer = 0f;

    public static float lagAsteroid = 0f;

    public static ShipColor shipColor = ShipColor.NORMAL;

    public static bool coherentSound = true;

    public static float lagSound = 0f;

    

    //TODO
    public static void SaveToFile()
    {

    }

    //TODO
    public static void LoadFromFile()
    {

    }
}
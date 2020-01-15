using System.Collections.Generic;
using System.IO;
using UnityEngine;

public enum ShipColor {
    NORMAL,
    BACKGROUND,
    ASTEROID
}
public class PerceptiveParameters {
    public static float inertia = 0f;

    public static float lagPlayer = 0f;

    public static float lagAsteroid = 0f;

    public static ShipColor shipColor = ShipColor.NORMAL;

    public static bool coherentSound = true;

    public static float lagSound = 0f;

    private List<string[]> rowData = new List<string[]> ();

    //TODO
    public static void SaveToFile (int score, int seconds) {
        string line = "";
        if (!System.IO.File.Exists (Application.dataPath + "/log.csv")) {
            line += CreateFile() + "\n";
        }

        using (FileStream fs = new FileStream (Application.dataPath + "/log.csv", FileMode.Append, FileAccess.Write)) {
            using (StreamWriter sw = new StreamWriter (fs)) {
                sw.WriteLine (line + PerceptiveParameters.GetLine(score,seconds));
            }
        }
    }

    //TODO
    public static void LoadFromFile () {

    }

    public static string CreateFile () {

        string[] rowDataTemp = new string[8];
        rowDataTemp[0] = "Inertia";
        rowDataTemp[1] = "LagPlayer";
        rowDataTemp[2] = "LagAsteroid";
        rowDataTemp[3] = "ShipColor";
        rowDataTemp[4] = "CoherentSound";
        rowDataTemp[5] = "LagSound";
        rowDataTemp[6] = "Score";
        rowDataTemp[7] = "Temps";

        string line = "";

        for (int i = 0; i < rowDataTemp.Length; i++) {
            line += rowDataTemp[i] + ",";
        }

        line = line.Remove(line.Length - 1 );
        return line;
    }

    public static string GetLine(int score, int temps)
    {
        string[] rowDataTemp = new string[8];
        rowDataTemp[0] = PerceptiveParameters.inertia.ToString();
        rowDataTemp[1] = (PerceptiveParameters.lagPlayer*10).ToString();
        rowDataTemp[2] = (PerceptiveParameters.lagAsteroid*10).ToString();
        rowDataTemp[3] = PerceptiveParameters.shipColor.ToString();
        rowDataTemp[4] = PerceptiveParameters.coherentSound.ToString();
        rowDataTemp[5] = PerceptiveParameters.lagSound.ToString();
        rowDataTemp[6] = score.ToString();
        rowDataTemp[7] = temps.ToString();

        string line = "";

        for (int i = 0; i < rowDataTemp.Length; i++) {
            line += rowDataTemp[i] + ",";
        }

        line = line.Remove(line.Length - 1 );

        return line;
    }
}
/*==== FieldView.cs ====================================================
 * FieldView is an utility to draw fields
 * 
 * Author: Victor Le aka "Coac"
 * Repository : https://github.com/Coac/ingame-editor-ui.git
 * =========================================================================*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

public class FieldView
{
    public static string format = "0.000";

    public static Vector3 displayVector3(Vector3 vector)
    {
        GUILayout.BeginHorizontal();

        vector = new Vector3(
            float.Parse(GUILayout.TextField(vector.x.ToString(format))), 
            float.Parse(GUILayout.TextField(vector.y.ToString(format))),
            float.Parse(GUILayout.TextField(vector.z.ToString(format)))
            );

        GUILayout.EndHorizontal();

        return vector;
    }

    public static double displayDouble(double doubl)
    {
        return double.Parse(GUILayout.TextField(doubl.ToString(format)));
    }

    public static float displayFloat(float input)
    {
        return float.Parse(GUILayout.TextField(input.ToString(format)));
    }

    public static int displayInt(int input)
    {
        return int.Parse(GUILayout.TextField(input.ToString()));
    }

    public static bool displayBool(bool input)
    {
        return GUILayout.Toggle(input, "");
    }

    public static string displayString(string input)
    {
        return GUILayout.TextField(input);
    }

    public static List<string> displayListString(List<string> input)
    {
        GUILayout.BeginVertical();

        GUILayout.Label("Length: " + input.Count);
        foreach(string str in input)
        {
            GUILayout.Label(str);
        }

        GUILayout.EndVertical();

        return input;
    }
}
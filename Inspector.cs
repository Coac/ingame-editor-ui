using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

public class Inspector : MonoBehaviour
{

    public static void draw(Rect screenRect)
    {
        Inspector.inspectorRect = screenRect;
        inspectorRect = GUI.Window(1, inspectorRect, inspectorFunction, "Inspector");
    }

    static public string text = "";
    static private Rect inspectorRect = new Rect(Screen.width - 400, 0, 400, Screen.height);
    static private Vector2 scrollViewVector = Vector2.zero;
    static void inspectorFunction(int windowID)
    {

        scrollViewVector = GUI.BeginScrollView(new Rect(0, 20, Inspector.inspectorRect.width, Inspector.inspectorRect.height), scrollViewVector, new Rect(0, 0, Inspector.inspectorRect.width, Inspector.inspectorRect.height*10));
        GUILayout.TextArea(Inspector.text);
        GUI.EndScrollView();

    }

    public static void displayComponents(GameObject go)
    {
        Inspector.text = "";
        foreach (Component co in go.GetComponents(typeof(Component)))
        {
            Type t = co.GetType();
            Inspector.text += "\nType " + t;
            Inspector.text += "\nType information for:" + t.FullName;
            Inspector.text += "\n\tBase class = " + t.BaseType.FullName;
            Inspector.text += "\n\tIs Class = " + t.IsClass;
            Inspector.text += "\n\tIs Enum = " + t.IsEnum;
            Inspector.text += "\n\tAttributes = " + t.Attributes;
            System.Reflection.FieldInfo[] fieldInfo = t.GetFields();
            foreach (System.Reflection.FieldInfo info in fieldInfo)
                Inspector.text += "\nField:" + info.Name;
            System.Reflection.PropertyInfo[] propertyInfo = t.GetProperties();
            foreach (System.Reflection.PropertyInfo info in propertyInfo)
                Inspector.text += "\nProp:" + info.Name;
        }
        
    }
}
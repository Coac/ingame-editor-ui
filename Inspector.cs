using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

public class Inspector : MonoBehaviour
{

    public void draw(Rect screenRect)
    {
        this.inspectorRect = screenRect;
        inspectorRect = GUI.Window(1, inspectorRect, inspectorFunction, "Inspector");
    }

    private string text = "";
    private Rect inspectorRect = new Rect(Screen.width - 400, 0, 400, Screen.height);
    private Vector2 scrollViewVector = Vector2.zero;
    private void inspectorFunction(int windowID)
    {

        scrollViewVector = GUI.BeginScrollView(new Rect(0, 20, this.inspectorRect.width, this.inspectorRect.height), scrollViewVector, new Rect(0, 0, this.inspectorRect.width, this.inspectorRect.height*10));
        GUILayout.TextArea(this.text);
        GUI.EndScrollView();
    }

    public void displayComponents(GameObject go)
    {
        this.text = "";
        foreach (Component co in go.GetComponents(typeof(Component)))
        {
            Type t = co.GetType();
            this.text += "\nType " + t;
            this.text += "\nType information for:" + t.FullName;
            this.text += "\n\tBase class = " + t.BaseType.FullName;
            this.text += "\n\tIs Class = " + t.IsClass;
            this.text += "\n\tIs Enum = " + t.IsEnum;
            this.text += "\n\tAttributes = " + t.Attributes;
            System.Reflection.FieldInfo[] fieldInfo = t.GetFields();
            foreach (System.Reflection.FieldInfo info in fieldInfo)
                this.text += "\nField:" + info.Name;
            System.Reflection.PropertyInfo[] propertyInfo = t.GetProperties();
            foreach (System.Reflection.PropertyInfo info in propertyInfo)
                this.text += "\nProp:" + info.Name;
        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

public class ComponentView
{
    public Component co;
    private Inspector inspector;

    private string text;

    public ComponentView(Component co)
    {
        this.co = co;

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


    public void draw()
    {
        if(co == null) { return; }

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("X", GUILayout.Width(30)))
        {
            UnityEngine.Object.Destroy(this.co);
        }

        GUILayout.TextArea(this.co.GetType().Name);
        try
        {
            MonoBehaviour script = (MonoBehaviour)co;
            if(GUILayout.Button(script.enabled + " ")) {
                script.enabled = !script.enabled;
            }
        } catch
        {

        }

        GUILayout.EndHorizontal();
        GUILayout.TextArea(this.text);
        
    }


}
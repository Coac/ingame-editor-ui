using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

public class ComponentView
{
    public Component co;

    private string text;

    private bool displayField = false;
    private string fields = "";

    private bool displayProps = false;
    private string props = "";

    private bool displayMethod = false;
    private string methods = "";

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
            this.fields += "\n" + info.Name;
        System.Reflection.PropertyInfo[] propertyInfo = t.GetProperties();
        foreach (System.Reflection.PropertyInfo info in propertyInfo)
            this.props += "\n" + info.Name;

        MethodInfo[] methodInfos = t.GetMethods(BindingFlags.Public | BindingFlags.Instance);
        foreach (MethodInfo methodInfo in methodInfos)
        {
            this.methods += "\n" + methodInfo.ReturnType.Name + " " + methodInfo.Name + "(";
            foreach (ParameterInfo p in methodInfo.GetParameters())
            {
                this.methods += p.ParameterType.Name + " " + p.Name + ", ";
            }
            this.methods += ")";
            
        }
         
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

        if (fields != "" && GUILayout.Button("Fields", GUILayout.Height(16)))
        {
            this.displayField = !this.displayField;
        }
        if (displayField)
        {
            GUILayout.TextArea(this.fields);
        }

        if (GUILayout.Button("Props", GUILayout.Height(16)))
        {
            this.displayProps = !this.displayProps;
        }
        if (displayProps)
        {
            GUILayout.TextArea(this.props);
        }

        if (GUILayout.Button("Methods", GUILayout.Height(16)))
        {
            this.displayMethod = !this.displayMethod;
        }
        if(displayMethod)
        {
            GUILayout.TextArea(this.methods);
        }

    }


}
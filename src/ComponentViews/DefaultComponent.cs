﻿/*==== DefaultComponent.cs ====================================================
 * DefaultComponent is a general Component representation
 * 
 * Author: Victor Le aka "Coac"
 * Repository : https://github.com/Coac/debug-scene-ui
 * =========================================================================*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

public class DefaultComponent : AbstractComponent
{
    private string text;

    private bool displayField = false;
    private string fields = "";
    private System.Reflection.FieldInfo[] fieldInfo;


    private bool displayProps = false;
    private string props = "";

    private bool displayMethod = false;
    private string methods = "";

    public DefaultComponent(Component co)
    {
        this.co = co;

        Type t = co.GetType();
        this.text += "\nType " + t;
        this.text += "\nType information for:" + t.FullName;
        this.text += "\n\tBase class = " + t.BaseType.FullName;
        this.text += "\n\tIs Class = " + t.IsClass;
        this.text += "\n\tIs Enum = " + t.IsEnum;
        this.text += "\n\tAttributes = " + t.Attributes;
        this.fieldInfo = t.GetFields();
        System.Reflection.PropertyInfo[] propertyInfo = t.GetProperties();
        foreach (System.Reflection.PropertyInfo info in propertyInfo)
            this.props += "\n" + info.Name + " " + info.PropertyType;

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


    public override void draw()
    {
        if(co == null) { return; }

        base.draw();

        this.drawDefaultComponent();
    }


    private void drawDefaultComponent()
    {
        GUILayout.TextArea(this.text);


        if (this.fieldInfo.Length > 0 && GUILayout.Button("Fields", GUILayout.Height(16)))
        {
            this.displayField = !this.displayField;
        }
        if (displayField)
        {
            foreach (System.Reflection.FieldInfo info in fieldInfo)
            {
                GUILayout.BeginHorizontal();

                GUILayout.Label(info.Name);

                switch (info.FieldType.ToString())
                {
                    case "System.Boolean":
                        GUILayout.Label("");
                        info.SetValue(this.co, GUILayout.Toggle((bool)info.GetValue(this.co), info.Name));
                        break;
                    default:
                        GUILayout.Label(info.FieldType.ToString());
                        var value = info.GetValue(this.co);
                        if (value == null)
                        {
                            GUILayout.Label("null");
                        }
                        else
                        {
                            GUILayout.Label(value.ToString());
                        }
                        break;
                }

                GUILayout.EndHorizontal();
            }
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
        if (displayMethod)
        {
            GUILayout.TextArea(this.methods);
        }
    }


}
/*==== AbstractComponent.cs ====================================================
 * AbstractComponent is a base Component representation
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

public abstract class AbstractComponent
{
    protected Component co;

    public virtual void draw()
    {
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("X", GUILayout.Width(30)))
        {
            UnityEngine.Object.Destroy(this.co);
        }

        GUILayout.TextArea(this.co.GetType().Name);
        try
        {
            MonoBehaviour script = (MonoBehaviour)co;
            if (GUILayout.Button(script.enabled + " "))
            {
                script.enabled = !script.enabled;
            }
        }
        catch
        {

        }
        GUILayout.EndHorizontal();
    }

}
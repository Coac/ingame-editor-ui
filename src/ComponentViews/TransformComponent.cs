/*==== TransformComponent.cs ====================================================
 * TransformComponent is a Unity.Transform Component representation
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

public class TransformComponent : AbstractComponent
{
    private Transform trans;

    public TransformComponent(Transform trans)
    {
        this.trans = trans;
        this.co = trans;
    }

    public override void draw()
    {
        if(co == null) { return; }

        base.draw();

        GUILayout.BeginHorizontal();

        GUILayout.BeginVertical();
        GUILayout.Label("");
        GUILayout.Label("Position");
        GUILayout.Label("Rotation");
        GUILayout.Label("Scale");

        GUILayout.EndVertical();

        GUILayout.BeginVertical();
        GUILayout.Label("Local");
        GUILayout.Label(trans.localPosition.ToString());
        GUILayout.Label(trans.localRotation.ToString());
        GUILayout.Label(trans.localScale.ToString());
        GUILayout.EndVertical();

        GUILayout.BeginVertical();
        GUILayout.Label("Absolute");
        GUILayout.Label(trans.position.ToString());
        GUILayout.Label(trans.rotation.ToString());
        GUILayout.Label(trans.localScale.ToString());
        GUILayout.EndVertical();

        GUILayout.EndHorizontal();
    }

}
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
        trans.localPosition = FieldView.displayVector3(trans.localPosition);
        GUILayout.Label(trans.localRotation.ToString());
        trans.localScale = FieldView.displayVector3(trans.localScale);
        GUILayout.EndVertical();

        GUILayout.Space(10);

        GUILayout.BeginVertical();
        GUILayout.Label("Absolute");
        trans.position = FieldView.displayVector3(trans.position);
        GUILayout.Label(trans.rotation.ToString());
        trans.localScale = FieldView.displayVector3(trans.localScale);
        GUILayout.EndVertical();

        GUILayout.EndHorizontal();
    }

}
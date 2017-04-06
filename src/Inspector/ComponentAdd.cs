/*==== ComponentAdd.cs ======================================================
 * ComponentAdd show a list of components to add
 * 
 * Author: Victor Le aka "Coac"
 * Repository : https://github.com/Coac/ingame-editor-ui.git
 * =======================================================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentAdd
{
    private Inspector ins;

    public ComponentAdd(Inspector ins)
    {
        this.ins = ins;
    }

    public void draw()
    {
        if (GUILayout.Button("Add Component"))
        {
            ins.go.AddComponent<TransformVelocityLine>();
            ins.displayComponents();
        }
    }
}

/*==== Inspector.cs ========================================================
 * Inspector that holds the components
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

public class Inspector
{
    public GameObject go;
    private List<AbstractComponent> componentsViews = new List<AbstractComponent>();
    private ComponentAdd componentAdd;

    public Inspector(Rect inspectorRect)
    {
        this.inspectorRect = inspectorRect;
        this.componentAdd = new ComponentAdd(this);
    }

    public void draw()
    {
        inspectorRect = GUI.Window(1, inspectorRect, inspectorFunction, "Inspector");
    }

    private Rect inspectorRect = new Rect(Screen.width - 400, 0, 400, Screen.height);
    private Vector2 scrollViewVector = Vector2.zero;
    private void inspectorFunction(int windowID)
    {
        if (go == null) return;


        this.displayHeader();

        scrollViewVector = GUILayout.BeginScrollView(scrollViewVector);
        foreach (AbstractComponent view in this.componentsViews)
        {
            view.draw();
        }

        GUILayout.EndScrollView();

        componentAdd.draw();
    }

    public void setGameObject(GameObject go)
    {
        this.go = go;
        this.displayComponents();
    }

    private void displayHeader()
    {
        GUILayout.BeginHorizontal();

        GUILayout.Label(this.go.name);
        if(GUILayout.Button("X", GUILayout.Width(50))) {
            UnityEngine.Object.Destroy(this.go);
        }

        GUILayout.EndHorizontal();



        GUILayout.BeginHorizontal();

        GUILayout.Label("Tag", GUILayout.Width(30));
        GUILayout.TextField(this.go.tag);

        GUILayout.Space(50);

        GUILayout.Label("Layer", GUILayout.Width(40));
        GUILayout.TextField(LayerMask.LayerToName(this.go.layer));

        GUILayout.EndHorizontal();
    }

    public void displayComponents()
    {
        this.componentsViews.Clear();
        foreach (Component co in this.go.GetComponents(typeof(Component)))
        {
            this.componentsViews.Add(ComponentViewFactory.getComponentView(co));
        }
        
    }
}
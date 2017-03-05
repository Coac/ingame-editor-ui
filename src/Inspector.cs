using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

public class Inspector : MonoBehaviour
{

    private List<ComponentView> componentsViews = new List<ComponentView>();

    public void draw(Rect screenRect)
    {
        this.inspectorRect = screenRect;
        inspectorRect = GUI.Window(1, inspectorRect, inspectorFunction, "Inspector");
    }

    private Rect inspectorRect = new Rect(Screen.width - 400, 0, 400, Screen.height);
    private Vector2 scrollViewVector = Vector2.zero;
    private void inspectorFunction(int windowID)
    {

        scrollViewVector = GUI.BeginScrollView(new Rect(0, 20, this.inspectorRect.width, this.inspectorRect.height), scrollViewVector, new Rect(0, 0, this.inspectorRect.width, this.inspectorRect.height*10));
        foreach (ComponentView view in this.componentsViews)
        {
            view.draw();
        }
        
        GUI.EndScrollView();
    }

    public void displayComponents(GameObject go)
    {
        this.componentsViews.Clear();
        foreach (Component co in go.GetComponents(typeof(Component)))
        {
            this.componentsViews.Add(new ComponentView(co));
        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

public class GameObjectItem
{
    public GameObject go;
    private List<GameObjectItem> childItems = new List<GameObjectItem>();
    private int offsetSize = 10;
    private int childLevel = 0;
    private Inspector inspector;

    public GameObjectItem(GameObject go, Inspector inspector)
    {
        this.go = go;
        this.inspector = inspector;
    }

    public GameObjectItem(GameObject go, Inspector inspector, int childLevel)
    {
        this.go = go;
        this.childLevel = childLevel;
        this.inspector = inspector;
    }

    public void draw()
    {
        if (this.go == null) return;

        this.gameObjectDisplay();

        foreach (GameObjectItem item in this.childItems)
        {
            item.draw();
        }
    }

    private void gameObjectDisplay()
    {
        GUILayout.BeginHorizontal();

        GUILayout.Label("", GUILayout.Width(this.offsetSize * this.childLevel));

        if (GUILayout.Button("X", GUILayout.Width(30)))
        {
            UnityEngine.Object.Destroy(this.go);
        }

        if (GUILayout.Button(this.go.transform.name + " " + this.go.transform.childCount))
        {
            this.inspector.displayComponents(this.go);
        }

        if (GUILayout.Button("V", GUILayout.Width(30)))
        {
            if (childItems.Count > 0)
            {
                this.childItems.Clear();
            }
            else
            {
                foreach (Transform child in go.transform)
                {
                    this.childItems.Add(new GameObjectItem(child.gameObject, this.inspector, this.childLevel + 1));
                }
            }
        }

        GUILayout.EndHorizontal();
    }

}
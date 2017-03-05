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
    private int offset = 0;

    public GameObjectItem(GameObject go)
    {
        this.go = go;
    }

    public GameObjectItem(GameObject go, int offset)
    {
        this.go = go;
        this.offset = offset;
    }

    public void draw()
    {
        this.gameObjectDisplay();

        foreach (GameObjectItem item in this.childItems)
        {
            item.draw();
        }
    }

    void gameObjectDisplay()
    {
        GUILayout.BeginHorizontal();

        GUILayout.Label("", GUILayout.Width(this.offset));

        if (GUILayout.Button(this.go.transform.name))
        {
            if (childItems.Count > 0)
            {
                this.childItems.Clear();
            }
            else
            {
                foreach (Transform child in go.transform)
                {
                    Debug.Log(child.name);
                    this.childItems.Add(new GameObjectItem(child.gameObject, offset + 10));
                }
            }
           
        }

        if (GUILayout.Button("->", GUILayout.Width(30)))
        {
            Inspector.displayComponents(this.go);
        }
        GUILayout.EndHorizontal();
    }

}
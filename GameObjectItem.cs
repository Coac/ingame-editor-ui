﻿using System;
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
    private Inspector inspector;

    public GameObjectItem(GameObject go, Inspector inspector)
    {
        this.go = go;
        this.inspector = inspector;
    }

    public GameObjectItem(GameObject go, Inspector inspector, int offset)
    {
        this.go = go;
        this.offset = offset;
        this.inspector = inspector;
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

        if (GUILayout.Button(this.go.transform.name + " " + this.go.transform.childCount))
        {
            if (childItems.Count > 0)
            {
                this.childItems.Clear();
            }
            else
            {
                foreach (Transform child in go.transform)
                {
                    this.childItems.Add(new GameObjectItem(child.gameObject, this.inspector, offset + 10));
                }
            }
           
        }

        if (GUILayout.Button("->", GUILayout.Width(30)))
        {
            this.inspector.displayComponents(this.go);
        }
        GUILayout.EndHorizontal();
    }

}
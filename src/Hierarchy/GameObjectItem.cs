/*==== GameObjectItem.cs ===================================================
 * A GameObjectItem is a gameObject representation.
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

public class GameObjectItem
{
    public GameObject go;
    private List<GameObjectItem> childItems = new List<GameObjectItem>();
    private int offsetSize = 10;
    private int childLevel = 0;
    private Inspector inspector;
    public bool isSelected = false;
    public bool isExpanded = false;
    private Transform parent;

    protected static GameObjectItem lastSelected;

    public GameObjectItem(GameObject go, Inspector inspector)
    {
        this.go = go;
        this.inspector = inspector;
        this.parent = go.transform.parent;
    }

    public GameObjectItem(GameObject go, Inspector inspector, int childLevel)
    {
        this.go = go;
        this.childLevel = childLevel;
        this.inspector = inspector;
        this.parent = go.transform.parent;
    }

    public void draw()
    {
        if (this.go == null) return;

        if(this.isSelected) GUI.color = Color.gray;
        this.gameObjectDisplay();

        GUI.color = Color.white;

        for (int i = 0; i < childItems.Count; i++)
        {
            if(childItems[i].go != null)
            {
                childItems[i].draw();
            }
            else
            {
                childItems.RemoveAt(i);
                i--;
            }
        }
    }

    public void updateChild()
    {
        if(this.parent != this.go.transform.parent) // Parent changed
        {
            this.go = null;
            return;
        }

        if (!isExpanded) return;

        if (childItems.Count < this.go.transform.childCount)
        {
            foreach (Transform child in go.transform)
            {
                bool contains = false;
                foreach(var item in childItems)
                {
                    if(item.go.transform == child)
                    {
                        contains = true;
                        break;
                    }
                }
                if(!contains)
                    this.childItems.Add(new GameObjectItem(child.gameObject, this.inspector, this.childLevel + 1));
            }
        }

        foreach (var item in childItems)
        {
            item.updateChild();
        }
    }


    private void gameObjectDisplay()
    {
        GUILayout.BeginHorizontal();

        GUILayout.Label("", GUILayout.Width(this.offsetSize * this.childLevel));

        if (this.go.transform.childCount > 0 && GUILayout.Button(this.go.transform.childCount.ToString(), GUILayout.Width(30)))
        {
            this.toggleChild();
        }

        if (GUILayout.Button(this.go.transform.name))
        {
            if (GameObjectItem.lastSelected != null)
            {
                lastSelected.isSelected = false;
            }
            this.isSelected = true;
            GameObjectItem.lastSelected = this;

            this.inspector.setGameObject(this.go);
        }

        GUILayout.EndHorizontal();
    }

    private void toggleChild()
    {

        if (childItems.Count > 0)
        {
            this.childItems.Clear();
            isExpanded = false;
            return;
        }

        this.expandChild();
        isExpanded = true;
    }

    private void expandChild()
    {
        foreach (Transform child in go.transform)
        {
            this.childItems.Add(new GameObjectItem(child.gameObject, this.inspector, this.childLevel + 1));
        }
    }

    public override string ToString()
    {
        string str = "";
        for (int i = 0; i < this.childLevel; i++)
        {
            str += "  ";
        }
        str += this.go.name;

        foreach(GameObjectItem item in this.childItems)
        {
            str += "\n" + item.ToString();
        }

        return str;
    }

}
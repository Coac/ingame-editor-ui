/*==== Hierarchy.cs ======================================================
 * Hierarchy list the active gameObjects
 * 
 * Author: Victor Le aka "Coac"
 * Repository : https://github.com/Coac/debug-scene-ui
 * =======================================================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hierarchy {

    private List<GameObject> rootObjects;
    private List<GameObjectItem> rootObjectItems;
    private Inspector inspector;

    public Hierarchy(Inspector inspector)
    {
        this.rootObjects = new List<GameObject>();
        this.rootObjectItems = new List<GameObjectItem>();
        this.inspector = inspector;
        this.updateRootObjects();
    }

    private void updateRootObjects()
    {
        this.rootObjects.Clear();
        this.rootObjectItems.Clear();

        foreach (Transform xform in UnityEngine.Object.FindObjectsOfType<Transform>())
        {
            if (xform.parent == null)
            {
                rootObjects.Add(xform.gameObject);
                rootObjectItems.Add(new GameObjectItem(xform.gameObject, inspector));
            }
        }
    }

    public void draw()
    {
        hierachyRect = GUI.Window(0, hierachyRect, HierarchyFunction, "Hierarchy");
    }

    private Rect hierachyRect = new Rect(0, 0, 500, Screen.height);
    private Vector2 scrollViewVector = Vector2.zero;
    void HierarchyFunction(int windowID)
    {
        if (GUILayout.Button("Update GameObjects"))
        {
            this.updateRootObjects();
        }

        if (GUILayout.Button("Save GameObjects in TextFile"))
        {
            this.saveGameObjectsAsTxtFile();
        }

        scrollViewVector = GUILayout.BeginScrollView(scrollViewVector);

        foreach (GameObjectItem item in this.rootObjectItems)
        {
            item.draw();
        }

        GUILayout.EndScrollView();
    }

    private void saveGameObjectsAsTxtFile()
    {
        string gameobjects = this.ToString();
        Debug.Log(gameobjects);
        System.IO.File.WriteAllText(@"C:\Users\Coac\Downloads\go.txt", gameobjects);
    }

    public override string ToString()
    {
        string str = "";

        foreach(GameObjectItem item in this.rootObjectItems)
        {
            str += item.ToString() + "\n";
        }

        return str;
    }

}

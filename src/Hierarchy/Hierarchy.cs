/*==== Hierarchy.cs ======================================================
 * Hierarchy list the active gameObjects
 * 
 * Author: Victor Le aka "Coac"
 * Repository : https://github.com/Coac/ingame-editor-ui.git
 * =======================================================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hierarchy
{

    private List<GameObjectItem> rootObjectItems;
    private Inspector inspector;
    private MonoBehaviour mono;
    private float updateRate;

    public Hierarchy(Rect hierachyRect, Inspector inspector, MonoBehaviour mono)
    {
        this.rootObjectItems = new List<GameObjectItem>();
        this.inspector = inspector;
        this.hierachyRect = hierachyRect;
        this.mono = mono;
        this.updateRate = 1f;

        this.mono.StartCoroutine(updateGoCoroutine());
    }

    IEnumerator updateGoCoroutine()
    {
        while (true)
        {
            this.updateRootObjects();
            yield return new WaitForSeconds(this.updateRate);
        }
    }

    private void updateRootObjects()
    {
        List<GameObject> updatedRootObjects = new List<GameObject>(UnityEngine.Object.FindObjectsOfType<GameObject>());
        for (int i = 0; i < updatedRootObjects.Count; i++)
        {
            if (updatedRootObjects[i].transform.parent != null)
            {
                updatedRootObjects.RemoveAt(i);
                i--;
            }
        }

        for (int i = 0; i < rootObjectItems.Count; i++)
        {
            if (!updatedRootObjects.Contains(rootObjectItems[i].go))
            {
                this.rootObjectItems.Remove(rootObjectItems[i]);
                i--;
            }
            else
                updatedRootObjects.Remove(rootObjectItems[i].go);
        }

        foreach (GameObject go in updatedRootObjects)
        {
            rootObjectItems.Add(new GameObjectItem(go, inspector));
        }

        foreach(var item in rootObjectItems)
        {
            item.updateChild();
        }
    }

    public void draw()
    {
        hierachyRect = GUI.Window(0, hierachyRect, HierarchyFunction, "Hierarchy");
    }

    private Rect hierachyRect;
    private Vector2 scrollViewVector = Vector2.zero;
    void HierarchyFunction(int windowID)
    {
        if (GUILayout.Button("Update GameObjects"))
        {
            this.updateRootObjects();
        }

        GUILayout.BeginHorizontal();
        GUILayout.Label("Update Rate : " + this.updateRate.ToString("0.00") + " seconds");
        this.updateRate = GUILayout.HorizontalSlider(this.updateRate, 0.0f, 2.0f);
        GUILayout.EndHorizontal();

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

        foreach (GameObjectItem item in this.rootObjectItems)
        {
            str += item.ToString() + "\n";
        }

        return str;
    }

}

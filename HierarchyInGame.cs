using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HierarchyInGame : MonoBehaviour {

    private List<GameObject> rootObjects = new List<GameObject>();
	void Start () {
        this.updateRootObjects();
    }

    private void updateRootObjects()
    {
        this.rootObjects.Clear();
        foreach (Transform xform in UnityEngine.Object.FindObjectsOfType<Transform>())
        {
            if (xform.parent == null)
            {
                rootObjects.Add(xform.gameObject);
            }
        }
    }


    void OnGUI()
    {
        hierachyRect = GUI.Window(0, hierachyRect, HierarchyFunction, "Hierarchy");
        Inspector.draw(new Rect(Screen.width - 400, 0, 400, Screen.height));
    }

    private Rect hierachyRect = new Rect(0, 0, 400, Screen.height);
    private Vector2 scrollViewVector = Vector2.zero;
    void HierarchyFunction(int windowID)
    {
        if (GUILayout.Button("Update GameObjects"))
        {
            this.updateRootObjects();
        }

        int contentHeight = Screen.height * 2;
        int scrollViewMargin = 20;
        int contentWidth = (int)hierachyRect.width - scrollViewMargin - 20;

        scrollViewVector = GUI.BeginScrollView(new Rect(scrollViewMargin, 50, hierachyRect.width - scrollViewMargin - 10, hierachyRect.height), scrollViewVector, new Rect(0, 0, contentWidth, contentHeight));
    
            GUILayout.BeginArea(new Rect(0, 0, contentWidth, contentHeight));

                foreach (GameObject go in this.rootObjects)
                {
                    gameObjectDisplay(go);
                }

            GUILayout.EndArea();

        GUI.EndScrollView();
    }



    void gameObjectDisplay(GameObject go)
    {
        GUILayout.BeginHorizontal();
        if (GUILayout.Button(go.transform.name))
        {
            Debug.Log("lol");
        }

        if (GUILayout.Button("->", GUILayout.Width(30)))
        {
            Inspector.displayComponents(go);
        }
        GUILayout.EndHorizontal();
    }
}

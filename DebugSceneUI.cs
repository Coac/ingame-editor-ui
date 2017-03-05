using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugSceneUI : MonoBehaviour
{

    Hierarchy hierarchy;

    void Start()
    {
        this.hierarchy = new Hierarchy();
    }

    void OnGUI()
    {
        this.hierarchy.draw();
        Inspector.draw(new Rect(Screen.width - 400, 0, 400, Screen.height));
    }


}

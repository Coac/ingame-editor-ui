/*==== DebugSceneUI.cs =====================================================
 * Class that shows via IMGUI at runtime a Hierarchy and a Inspector like 
 * the built-in Editor. Can be useful when testing game on Android or doing 
 * some reverse-engineering ;)
 * 
 * Author: Victor Le aka "Coac"
 * Repository : https://github.com/Coac/debug-scene-ui
 * =========================================================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugSceneUI : MonoBehaviour
{

    private Hierarchy hierarchy;
    private Inspector inspector;

    public KeyCode toggleGuiKey = KeyCode.End;
    private bool toggleUI = true;

    void Start()
    {
        this.inspector = new Inspector();
        this.hierarchy = new Hierarchy(this.inspector);
    }

    void Update()
    {
        if(Input.GetKeyDown(toggleGuiKey))
        {
            toggleUI = !toggleUI;
        }
    }

    void OnGUI()
    {
        if (!toggleUI) return;

        this.hierarchy.draw();
        this.inspector.draw(new Rect(Screen.width - 400, 0, 400, Screen.height));
    }

}

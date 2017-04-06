/*==== DebugSceneUI.cs =====================================================
 * Class that shows via IMGUI at runtime a Hierarchy and a Inspector like 
 * the built-in Editor. Can be useful when testing game on Android or doing 
 * some reverse-engineering ;)
 * 
 * Author: Victor Le aka "Coac"
 * Repository : https://github.com/Coac/ingame-editor-ui.git
 * =========================================================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameEditorUI : MonoBehaviour
{

    private Hierarchy hierarchy;
    private Inspector inspector;
    private DebugConsole console;
    private FPSCounter fps;


    public KeyCode toggleGuiKey = KeyCode.End;
    private bool toggleUI = true;

    void Start()
    {
        this.inspector = new Inspector(new Rect(Screen.width - 400, 0, 400, Screen.height - Screen.height / 5));
        this.hierarchy = new Hierarchy(new Rect(0, 0, 500, Screen.height), this.inspector, this);
        this.console = new DebugConsole(new Rect(500, Screen.height - Screen.height / 5, Screen.width - 500, Screen.height / 5));
        this.fps = new FPSCounter(new Rect(Screen.width / 2, 0, 100, 100));
        StartCoroutine(this.fps.fpsCounter());
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

        this.console.draw();
        this.hierarchy.draw();
        this.inspector.draw();
        this.fps.draw();
    }
}

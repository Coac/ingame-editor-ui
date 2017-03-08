/*==== DebugConsole.cs ========================================================
 * DebugConsole displays Unity Logs/Errors
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

public class DebugConsole
{

    private Rect debugConsoleRect;
    private string logs;

    public DebugConsole(Rect debugConsoleRect)
    {
        this.debugConsoleRect = debugConsoleRect;
        this.logs = "";
        Application.logMessageReceived += this.logHandler;
    }

    private Vector2 scrollViewVector = Vector2.zero;

    public void draw()
    {
        debugConsoleRect = GUI.Window(3, debugConsoleRect, debugConsoleFunction, "Debug Console");
    }

    void logHandler(string message, string stackTrace, LogType type)
    {
        logs += message + "\n";
    }

    private void debugConsoleFunction(int windowID)
    {
        this.scrollViewVector = GUILayout.BeginScrollView(this.scrollViewVector);

        GUILayout.TextArea(this.logs);
    
        GUILayout.EndScrollView();
    }

}
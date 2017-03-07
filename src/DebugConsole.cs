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
    public DebugConsole(Rect debugConsoleRect)
    {
        this.debugConsoleRect = debugConsoleRect;
    }

    private Vector2 scrollViewVector = Vector2.zero;

    public void draw()
    {
        debugConsoleRect = GUI.Window(3, debugConsoleRect, debugConsoleFunction, "Debug Console");
    }

    private void debugConsoleFunction(int windowID)
    {

        this.scrollViewVector = GUILayout.BeginScrollView(this.scrollViewVector);

        for (int i = 0; i < 100; i++)
        {
            GUILayout.Label("Test log " + i);
        }

        GUILayout.EndScrollView();
    }

}
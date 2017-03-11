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
    private List<Log> logs;

    private class Log {
        public string log;
        public LogType logType;

        public Log(string log, LogType logType)
        {
            this.log = log;
            this.logType = logType;
        }
    }

    public DebugConsole(Rect debugConsoleRect)
    {
        this.debugConsoleRect = debugConsoleRect;
        this.logs = new List<Log>();
        Application.logMessageReceived += this.logHandler;
    }

    private Vector2 scrollViewVector = Vector2.zero;

    public void draw()
    {
        debugConsoleRect = GUI.Window(3, debugConsoleRect, debugConsoleFunction, "Debug Console");
    }

    void logHandler(string message, string stackTrace, LogType type)
    {
        this.logs.Insert(0, new Log(message + stackTrace, type));
    }

    private void drawLogs()
    {
        foreach (Log log in logs)
        {
            GUIStyle style = new GUIStyle();
            switch (log.logType)
            {
                case LogType.Exception:
                case LogType.Error:
                    if (!displayError) continue;
                    style.normal.textColor = Color.red;
                    break;
                case LogType.Warning:
                    if (!displayWarning) continue;
                    style.normal.textColor = Color.yellow;
                    break;
                default:
                    if (!displayNormal) continue;
                    style.normal.textColor = Color.white;
                    break;
            }

            GUILayout.TextArea(log.log, style);
        }
    }

    private void drawClearButton()
    {
        if(GUILayout.Button("Clear", GUILayout.Width(100)))
        {
            this.logs.Clear();
        }
    }


    private bool displayError = true;
    private bool displayWarning = true;
    private bool displayNormal = true;

    private void debugConsoleFunction(int windowID)
    {
        this.scrollViewVector = GUILayout.BeginScrollView(this.scrollViewVector);
        this.drawLogs();
        GUILayout.EndScrollView();

        GUILayout.BeginHorizontal();
        this.drawClearButton();
        GUILayout.BeginHorizontal(GUILayout.Width(200));
        displayNormal = GUILayout.Toggle(displayNormal, "Normal");
        displayWarning = GUILayout.Toggle(displayWarning, "Warning");
        displayError = GUILayout.Toggle(displayError, "Error");
        GUILayout.EndHorizontal();
        GUILayout.EndHorizontal();
    }

}
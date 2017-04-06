/*==== FPSCounter.cs ======================================================
 * FPSCounter computes and displays the number of frame per second
 * 
 * Author: Victor Le aka "Coac"
 * Repository : https://github.com/Coac/ingame-editor-ui.git
 * =======================================================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCounter {

    private Rect fpsRect;
    private float fps;

    public FPSCounter(Rect fpsRect)
    {
        this.fpsRect = fpsRect;
        this.fps = 0;
    }

    public IEnumerator fpsCounter()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            this.fps =  (Mathf.Round((1 / Time.deltaTime)));
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void draw()
    {
        GUI.Label(this.fpsRect, "FPS : " + this.fps);
    }

}

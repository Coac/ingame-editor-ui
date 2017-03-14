/*==== TransformVelocityLine.cs ========================================================
 * TransformVelocityLine sample script. Can be added via ComponentAdd
 * 
 * Author: Victor Le aka "Coac"
 * Repository : https://github.com/Coac/debug-scene-ui
 * =========================================================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TransformVelocityLine : MonoBehaviour
{
    private Vector3 lastPos;
    public Transform trans;

    void Update()
    {
        float speed = (Vector3.Distance(lastPos, this.transform.position) / Time.deltaTime);
        Vector3 velocity = speed * (lastPos - this.transform.position).normalized;
        DrawLine(this.transform.position, this.transform.position - velocity, Color.white, Time.deltaTime * 2);
        lastPos = this.transform.position;
    }

    void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0.2f)
    {
        GameObject line = new GameObject("Line");
        line.transform.position = start;
        line.AddComponent<LineRenderer>();
        LineRenderer lr = line.GetComponent<LineRenderer>();
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(line, duration);
    }
}





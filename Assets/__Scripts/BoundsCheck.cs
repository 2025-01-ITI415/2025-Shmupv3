using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// If you type /// in Visual Studio, it will automatically expand to a <summary
/// <summary
/// Keeps a GameObject on screen. 
/// Note that this ONLY works for an orthographic Main Camera.
/// </summary
public class BoundsCheck : MonoBehaviour
{                                    // a

    [Header("Dynamic")]
    public float camWidth;
    public float camHeight;

    void Awake()
    {
        camHeight = Camera.main.orthographicSize;           // b
        camWidth = camHeight * Camera.main.aspect;          // c
    }

    void LateUpdate()
    {                                                       // d
        Vector3 pos = transform.position;

        // Restrict the X position to camWidth
        if (pos.x > camWidth)
        {                                                   // e
            pos.x = camWidth;                               // e
        }
        if (pos.x < -camWidth)
        {                                                   // e
            pos.x = -camWidth;                              // e
        }

        // Restrict the Y position to camHeight
        if (pos.y > camHeight)
        {                                              // e
            pos.y = camHeight;                                                // e
        }
        if (pos.y < -camHeight)
        {                                             // e
            pos.y = -camHeight;                                               // e
        }

        transform.position = pos;
    }
}
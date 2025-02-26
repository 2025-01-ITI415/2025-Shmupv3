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

    public enum eType { center, inset, outset };                              // a

    [Header("Inscribed")]
    public eType boundsType = eType.center;                                   // a
    public float radius = 1f;

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
        // Find the checkRadius that will enable center, inset, or outset     // b
        float checkRadius = 0;
        if (boundsType == eType.inset) checkRadius = -radius;
        if (boundsType == eType.outset) checkRadius = radius;

        Vector3 pos = transform.position;

        // Restrict the X position to camWidth
        if (pos.x > camWidth + checkRadius)
        {                                                   // e
            pos.x = camWidth + checkRadius;                               // e
        }
        if (pos.x < -camWidth - checkRadius)
        {                                                   // e
            pos.x = -camWidth - checkRadius;                              // e
        }

        // Restrict the Y position to camHeight
        if (pos.y > camHeight + checkRadius)
        {                                              // e
            pos.y = camHeight + checkRadius;                                                // e
        }
        if (pos.y < -camHeight - checkRadius)
        {                                             // e
            pos.y = -camHeight - checkRadius;                                               // e
        }

        transform.position = pos;
    }
}
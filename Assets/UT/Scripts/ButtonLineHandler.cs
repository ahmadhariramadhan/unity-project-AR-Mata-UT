using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLineHandler : MonoBehaviour {
    public Transform pointA;
    public Transform pointB;
    public Transform pointC;

    public LineRenderer line;
    public int index;
    private void Awake()
    {
        Transform[] asd = GetComponentsInChildren<Transform>();
        foreach (var item in asd)
        {
            if (item.name == "PointALineRenderStart")
            {
                pointA = item;
            }
            if (item.name == "PointCLineRenderEnd")
            {
                pointC = item;
            }
        }
    }

    private void Start() {
        if (index == 3) {
            line.positionCount = 3;
            line.SetPosition(0, pointA.position);
            line.SetPosition(1, pointB.position);
            line.SetPosition(2, pointC.position);
        } else if (index==2) {
            line.positionCount = 2;
            line.SetPosition(0, pointB.position);
            line.SetPosition(1, pointC.position);
        }
    }

    private void Update() {
        if (index == 3) {
            line.positionCount = 3;
            line.SetPosition(0, pointA.position);
            line.SetPosition(1, pointB.position);
            line.SetPosition(2, pointC.position);
        } else if (index == 2) {
            line.positionCount = 2;
            line.SetPosition(0, pointB.position);
            line.SetPosition(1, pointC.position);
        }
    }

    public void DrawLine()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasWorldToCam : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    bool isActive;

    private void Start() {
    }
    private void OnEnable()
    {
        cam = Camera.main;
        isActive = true;
    }

    private void Update() {
        if (isActive && cam != null)
        {
            this.transform.rotation = Quaternion.Euler(cam.transform.eulerAngles.x,
                    cam.transform.eulerAngles.y, 0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomButton : MonoBehaviour
{
    public Image[] images;
    Image icon;
    private void Start()
    {
        images = this.gameObject.GetComponentsInChildren<Image>();
        foreach (var item in images)
        {
            if (item.name == "Button")
            {
                icon = item;
            }
        }
        icon.color = Color.grey;
    }

    public void Clicked()
    {
        icon.color = Color.green;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyePart : MonoBehaviour
{
    [SerializeField]
    private ButtonLineHandler lineHandler;
    private Camera cam;
    [SerializeField]
    private Button btn_part,
        btn_popUp;
    bool isPopUpActive = false;
    bool isRescale = false;

    private void Start()
    {
        lineHandler = GetComponent<ButtonLineHandler>();
        lineHandler.line.enabled = isPopUpActive;

        Button[] buttonCol = GetComponentsInChildren<Button>();
        cam = Camera.main;

        foreach (Button item in buttonCol)
        {
            if (item.name == "Btn_PopUpPanel")
            {
                btn_popUp = item;
                btn_popUp.gameObject.SetActive(isPopUpActive);
            }
            else if (item.name == "Btn_EyePart")
            {
                btn_part = item;
                btn_part.onClick.AddListener(() => TogglePopUpPanel());
            }
        }
    }

    private void Update()
    {
        if (isRescale)
        {
            RescaleButton();
        }
    }

    public void TogglePopUpPanel()
    {
        isPopUpActive = !isPopUpActive;
        EyePartHandler.Instance.ResetButtonEyePart();
        btn_popUp.gameObject.SetActive(isPopUpActive);
        lineHandler.line.enabled = isPopUpActive;
    }

    public void ResetBtnPopUp(){
        isPopUpActive = true;
        lineHandler.line.enabled=false;
        btn_popUp.gameObject.SetActive(false);
    }

    public void TogglePopUpPanelLeanTween()
    {
        isPopUpActive = !isPopUpActive;
        LeanTween.scale(btn_popUp.gameObject, Vector3.one, 0.5f);
        btn_popUp.gameObject.SetActive(isPopUpActive);
        btn_popUp.gameObject.transform.localScale = Vector3.zero;
        lineHandler.line.enabled = isPopUpActive;
    }

    float minDistance = 1f;
    float maxDistance = 3f;
    float minScale = 1f;
    float maxScale = 2f;
    float mdistance;

    public void RescaleButton()
    {
        mdistance = Vector3.Distance(this.gameObject.transform.position, cam.transform.position);
        //Debug.Log(mdistance + " " + maxDistance + " " + Mathf.InverseLerp(minDistance, maxDistance, mdistance));
        var scale = Mathf.Lerp(minScale, maxScale, Mathf.InverseLerp(minDistance, maxDistance, mdistance));

        if (btn_part.isActiveAndEnabled)
        {
            btn_part.transform.localScale = new Vector3(scale, scale, scale);
            //btn_part.transform.LookAt(cam.transform);
            btn_part.transform.rotation = Quaternion.Euler(cam.transform.eulerAngles.x,
                    cam.transform.eulerAngles.y, 0);
        }
        if (btn_popUp.isActiveAndEnabled)
        {
            btn_popUp.transform.localScale = new Vector3(scale, scale, scale);
            //btn_popUp.transform.LookAt(cam.transform);
            btn_popUp.transform.rotation = Quaternion.Euler(cam.transform.eulerAngles.x,
                    cam.transform.eulerAngles.y, 0);
        }
    }

    IEnumerator ButtonFacingCamera()
    {
        yield return new WaitForEndOfFrame();

        while (true && btn_part!= null && btn_popUp != null)
        {
            btn_part.transform.LookAt(cam.transform);
            btn_popUp.transform.LookAt(cam.transform);
            RescaleButton();
        }
    }
}

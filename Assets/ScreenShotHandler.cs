using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShotHandler : MonoBehaviour
{
    private bool takingScreenshot;
    [SerializeField]
    private GameObject buttonSave;
    [SerializeField]
    private GameObject buttonExit;

    public void TekaPhoto()
    {
        StartCoroutine(TakeScreenshotAndSave());
    }
    private IEnumerator TakeScreenshotAndSave()
    {
        takingScreenshot = true;
        StartCoroutine(HideBtnWhenTake());
        yield return new WaitForEndOfFrame();
        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        // Save the screenshot to Gallery/Photos
        ShowAndroidToastMessage("Photo Save To Gallery");
        string name = string.Format("{0}_Capture{1}.png", StaticData.username/*"Images"Application.productName*/, System.DateTime.Now.ToString("yyyy-MM-dd"));/*_HH-mm-ss*/
        Debug.Log("Permission result: " + NativeGallery.SaveImageToGallery(ss, /*Application.productName*/StaticData.username + " Captures", name));
        takingScreenshot = false;
    }

    private void ShowAndroidToastMessage(string message)
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        if (unityActivity != null)
        {
            AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
            unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                AndroidJavaObject toastObject = toastClass.CallStatic<AndroidJavaObject>("makeText", unityActivity, message, 0);
                toastObject.Call("show");
            }));
        }
    }

    public void QuitApplication(){
        Application.Quit();
    }

    private IEnumerator HideBtnWhenTake(){
        buttonSave.SetActive(false);
        buttonExit.SetActive(false);
        yield return new  WaitForSeconds(1f);
        buttonSave.SetActive(true);
        buttonExit.SetActive(true);

    }
}

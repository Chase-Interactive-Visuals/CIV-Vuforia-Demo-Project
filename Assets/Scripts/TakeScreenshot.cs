using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SA.iOS.UIKit;
using SA.Foundation.Utility;

public class TakeScreenshot : MonoBehaviour
{
    [SerializeField] Screenshot screenshotImagePreview;
    //[SerializeField] EmailManager emailManager;
    Texture2D myImage;

    bool takeScreenshot;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (takeScreenshot)
        {
            Debug.Log("Screenshot In progress");
            takeScreenshot = false;

            var temporaryRender = RenderTexture.GetTemporary(source.width, source.height);
            Graphics.Blit(source, temporaryRender);

            Texture2D temporaryTexture = new Texture2D(source.width, source.height, TextureFormat.RGBA32, false);
            Rect rect = new Rect(0, 0, source.width, source.height);
            temporaryTexture.ReadPixels(rect, 0, 0, false);
            temporaryTexture.Apply();
            screenshotImagePreview.OpenScreen(temporaryTexture);
            //emailManager.SetImageToSave(temporaryTexture);
            myImage = temporaryTexture;

            RenderTexture.ReleaseTemporary(temporaryRender);

        }
        Graphics.Blit(source, destination);
    }

    public void SaveScreenshot()
    {
        ISN_PhotoAlbum.UIImageWriteToSavedPhotosAlbum(myImage, (result) => {
            if (result.IsSucceeded)
                Debug.Log("Image saved");
            else
                Debug.Log("Error: " + result.Error.Message);
        });
    }

    public void invokeTakePicture()
    {
        Invoke("TakeScreenShot", 0.1f);
    }

    public void TakeScreenShot()
    {
        Debug.Log("Screenshot Started");

        takeScreenshot = true;
    }
}

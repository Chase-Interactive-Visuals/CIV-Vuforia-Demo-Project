using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using SA.iOS.UIKit;
using SA.Foundation.Utility;
using UnityEngine.UI;

public class TakeScreenshotURP : MonoBehaviour
{
    [SerializeField] ScreenShotImagePreviewURP screenshotImagePreview;
    private bool _takeScreenshot;
    Texture2D _screenshotTexture;
    private void OnEnable()
    {
        RenderPipelineManager.endCameraRendering += RenderPipelineManager_endCameraRendering;
    }
    private void OnDisable()
    {
        RenderPipelineManager.endCameraRendering -= RenderPipelineManager_endCameraRendering;
    }
    private void RenderPipelineManager_endCameraRendering(ScriptableRenderContext arg1, Camera arg2)
    {
        if(_takeScreenshot)
        {
            _takeScreenshot = false;

            int width = Screen.width;
            int height = Screen.height;
            Texture2D screenShotTexture = new Texture2D(width, height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0, 0, width, height);
            screenShotTexture.ReadPixels(rect, 0, 0);
            screenShotTexture.Apply();
            _screenshotTexture = screenShotTexture;
            screenshotImagePreview.OpenScreen(_screenshotTexture);
        }
    }
    private IEnumerator CoroutineScreenshot()
    {
        yield return new WaitForEndOfFrame();

        _takeScreenshot = false;

        int width = Screen.width;
        int height = Screen.height;
        Texture2D screenShotTexture = new Texture2D(width, height, TextureFormat.ARGB32, false);
        Rect rect = new Rect(0, 0, width, height);
        screenShotTexture.ReadPixels(rect, 0, 0);
        screenShotTexture.Apply();
        _screenshotTexture = screenShotTexture;
        screenshotImagePreview.OpenScreen(_screenshotTexture);
    }
    public void TakeScreenshot()
    {
        StartCoroutine(CoroutineScreenshot());
        //_takeScreenshot = true;
    }
    public void SaveScreenshot()
    {
        ISN_PhotoAlbum.UIImageWriteToSavedPhotosAlbum(_screenshotTexture, (result) => {
            if (result.IsSucceeded)
                Debug.Log("Image saved");
            else
                Debug.Log("Error: " + result.Error.Message);
        });
    }
}

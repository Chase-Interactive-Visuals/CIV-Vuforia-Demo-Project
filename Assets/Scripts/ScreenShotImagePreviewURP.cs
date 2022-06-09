using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenShotImagePreviewURP : ScreenURP
{
    [SerializeField] public RawImage screenshotImage;

    protected override void Start()
    {
        base.Start();
        CloseScreen();
    }

    public void OpenScreen(Texture imageTexture)
    {
        screenshotImage.texture = imageTexture;
        SetScreen(true);
    }
    public void CloseScreen()
    {
        SetScreen(false);
    }
}

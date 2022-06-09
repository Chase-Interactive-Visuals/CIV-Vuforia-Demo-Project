using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMove : MonoBehaviour
{
    private Touch touch1;
    private Touch touch2;

    private float speedModifier = 0.01f;

    private void OnMouseDrag()
    {
        if (Input.touchCount > 0 && Input.touchCount < 2)
        {
            //placementModelManager.currentARModel = this.gameObject;
            touch1 = Input.GetTouch(0);
            if (touch1.phase == TouchPhase.Moved)
            {
                transform.localPosition = new Vector3(
                    transform.localPosition.x + touch1.deltaPosition.x * speedModifier,
                    transform.localPosition.y,
                    transform.localPosition.z + touch1.deltaPosition.y * speedModifier);
            }
        }
        if (Input.touchCount == 2)
        {
            touch1 = Input.GetTouch(0);
            touch2 = Input.GetTouch(1);

            if (touch1.phase == TouchPhase.Moved)
            {
                transform.localEulerAngles = new Vector3(
                    transform.localEulerAngles.x,
                    transform.localEulerAngles.y + touch1.deltaPosition.y + touch2.deltaPosition.y * speedModifier,
                    transform.localEulerAngles.z);
            }
        }
    }
}

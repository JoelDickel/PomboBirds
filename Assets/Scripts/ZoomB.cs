using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomB : MonoBehaviour
{
    public float orthoZoomSpeed = 0.5f;
    public Camera cameraZ;
    private Touch toque0, toque1;
    private Vector2 toutchZeroPrevPos, toutchOnePrevPos;
    private float prevToutchDeltaMag, touchDeltaMag, deltaMagnitudeDiff;
   
    void Update()
    {
       if(Input.touchCount ==2)
        {
            toque0 = Input.GetTouch(0);
            toque1 = Input.GetTouch(1);

            toutchZeroPrevPos = toque0.position - toque0.deltaPosition;
            toutchOnePrevPos = toque1.position - toque1.deltaPosition;

            prevToutchDeltaMag = (toutchZeroPrevPos - toutchOnePrevPos).magnitude;
            touchDeltaMag = (toque0.position - toque1.position).magnitude;

            deltaMagnitudeDiff = prevToutchDeltaMag - touchDeltaMag;

            if (cameraZ.orthographic)
            {
                cameraZ.orthographicSize -= deltaMagnitudeDiff * (orthoZoomSpeed * Time.deltaTime);

                cameraZ.orthographicSize = Mathf.Max(cameraZ.orthographicSize, 5f);
                cameraZ.orthographicSize = Mathf.Min(cameraZ.orthographicSize, 10f);
            }
        }
    }
}

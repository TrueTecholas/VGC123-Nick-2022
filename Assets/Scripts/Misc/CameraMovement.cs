using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform player;

    public float minXClamp = -5.46f;
    public float minYClamp = -7.40f;
    public float maxXClamp = 96.35f;
    public float maxYClamp = 4.91f;


    void LateUpdate()
    {
        if(player)
        {
            Vector3 cameraTransform;
            cameraTransform = transform.position;

            cameraTransform.x = player.transform.position.x;
            cameraTransform.x = Mathf.Clamp(cameraTransform.x, minXClamp, maxXClamp);

            cameraTransform.y = player.transform.position.y + 3;
            cameraTransform.y = Mathf.Clamp(cameraTransform.y, minYClamp, maxYClamp);

            transform.position = cameraTransform;
        }
    }
}

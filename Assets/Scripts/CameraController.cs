using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraController : MonoBehaviour
{
    private Func<Vector3> getCameraFollowPositionFunction;
    
    public void SetUp(Func<Vector3> getCameraFollowPositionFunction)
    {
        this.getCameraFollowPositionFunction = getCameraFollowPositionFunction;
    }

    public void SetGetCameraFollowPositionFunction(Func<Vector3> getCameraFollowPositionFunction)
    {
        this.getCameraFollowPositionFunction = getCameraFollowPositionFunction;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.getCameraFollowPositionFunction != null)
        {
            Vector3 cameraFollowPosition = this.getCameraFollowPositionFunction();
            cameraFollowPosition.z = transform.position.z;

            Vector3 cameraMoveDirection = (cameraFollowPosition - transform.position).normalized;
            float distance = Vector3.Distance(cameraFollowPosition, transform.position);
            float cameraMoveSpeed = 2f;

            if(distance > 0)
            {
                Vector3 newCameraPosition = transform.position + cameraMoveDirection * distance * cameraMoveSpeed * Time.deltaTime;

                float distanceAfterMoving = Vector3.Distance(newCameraPosition, cameraFollowPosition);

                if(distanceAfterMoving > distance)
                {
                    // Overshot the target
                    newCameraPosition = cameraFollowPosition;
                }

                transform.position = newCameraPosition;
            }

           
        }
    }
}

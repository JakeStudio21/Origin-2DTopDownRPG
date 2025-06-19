using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : Singleton<CameraController>
{
    private CinemachineVirtualCamera cinemachineVirtualCamera;

    public void SetPlayerCameraFollow() {
        cinemachineVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        cinemachineVirtualCamera.Follow = PlayerController.Instance.transform;

        // Main Camera의 Projection을 Orthographic으로 강제
        Camera mainCam = Camera.main;
        if (mainCam != null) {
            mainCam.orthographic = true;
            mainCam.transform.rotation = Quaternion.identity; // (0,0,0)
        }

        // Virtual Camera의 Transform도 0,0,0으로 강제
        cinemachineVirtualCamera.transform.rotation = Quaternion.identity;
    }

    // public void SetPlayerCameraFollow() {
    //     cinemachineVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
    //     cinemachineVirtualCamera.Follow = PlayerController.Instance.transform;
    // }
}

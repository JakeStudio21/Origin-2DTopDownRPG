using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : Singleton<CameraController>
{
    private CinemachineStateDrivenCamera stateDrivenCamera;
    private CinemachineVirtualCamera cinemachineVirtualCamera;

    public void SetPlayerCameraFollow() {
        // State-Driven Camera가 있는지 먼저 찾아봅니다.
        stateDrivenCamera = FindObjectOfType<CinemachineStateDrivenCamera>();
        
        if (stateDrivenCamera != null)
        {
            // State-Driven Camera가 있다면, 그것의 Follow와 LookAt 타겟을 플레이어로 설정합니다.
            stateDrivenCamera.Follow = PlayerController.Instance.transform;
            stateDrivenCamera.LookAt = PlayerController.Instance.transform;
        }
        else
        {
            // State-Driven Camera가 없다면, 일반 Virtual Camera를 찾습니다.
            cinemachineVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
            if (cinemachineVirtualCamera != null)
            {
                cinemachineVirtualCamera.Follow = PlayerController.Instance.transform;
                cinemachineVirtualCamera.LookAt = PlayerController.Instance.transform;
            }
        }
    }
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Cinemachine;

// public class CameraController : Singleton<CameraController>
// {
//     private CinemachineStateDrivenCamera stateDrivenCamera;
//     private CinemachineVirtualCamera cinemachineVirtualCamera;

//     public void SetPlayerCameraFollow() {
//         // State-Driven Camera가 있는지 먼저 찾아봅니다.
//         stateDrivenCamera = FindObjectOfType<CinemachineStateDrivenCamera>();
        
//         if (stateDrivenCamera != null)
//         {
//             // State-Driven Camera가 있다면, 그것의 Follow와 LookAt 타겟을 플레이어로 설정합니다.
//             stateDrivenCamera.Follow = PlayerController.Instance.transform;
//             stateDrivenCamera.LookAt = PlayerController.Instance.transform;
//         }
//         else
//         {
//             // State-Driven Camera가 없다면, 일반 Virtual Camera를 찾습니다.
//             cinemachineVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
//             if (cinemachineVirtualCamera != null)
//             {
//                 cinemachineVirtualCamera.Follow = PlayerController.Instance.transform;
//                 cinemachineVirtualCamera.LookAt = PlayerController.Instance.transform;
//             }
//         }

//         // Main Camera의 Projection을 Orthographic으로 강제
//         Camera mainCam = Camera.main;
//         if (mainCam != null) {
//             mainCam.orthographic = true;
//             mainCam.transform.rotation = Quaternion.identity; // (0,0,0)
//         }

//         // Virtual Camera의 Transform도 0,0,0으로 강제
//         if (cinemachineVirtualCamera != null)
//         {
//             cinemachineVirtualCamera.transform.rotation = Quaternion.identity;
//         }
//     }

//     // public void SetPlayerCameraFollow() {
//     //     cinemachineVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
//     //     cinemachineVirtualCamera.Follow = PlayerController.Instance.transform;
//     // }
// }

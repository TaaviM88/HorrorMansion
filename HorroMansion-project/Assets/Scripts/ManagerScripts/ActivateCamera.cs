using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ActivateCamera : MonoBehaviour
{
    public CinemachineVirtualCameraBase switchToCam;

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            if (switchToCam)
            {
                Debug.Log("Hahaa osuit");
                switchToCam.MoveToTopOfPrioritySubqueue();
            }
        }
    }

}


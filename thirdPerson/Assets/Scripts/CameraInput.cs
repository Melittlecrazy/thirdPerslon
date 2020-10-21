using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraInput : MonoBehaviour
{
    private CinemachineFreeLook cineFree;

    private void Start()
    {
        cineFree = GetComponent<CinemachineFreeLook>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        var pointerDelta = context.ReadValue<Vector2>();
        cineFree.m_XAxis.Value += pointerDelta.x;
        cineFree.m_YAxis.Value += pointerDelta.y;
    }
}

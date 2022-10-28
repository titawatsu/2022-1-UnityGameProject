using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerRotation : MonoBehaviour
{

    private Camera mainCam;
    private void Start()
    {
        mainCam = Camera.main; // find main camera in scene
    }

    private void Update()
    {
        TryRotate();
    }

    private void TryRotate()
    {
        if (PauseController.paused) return;
        GunRotation();
    }

    private void GunRotation() // function to rotate player by change mouse cursor position
    {
        var direction = (Vector3)Mouse.current.position.ReadValue() - mainCam.WorldToScreenPoint(transform.position);

        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle + 90f, Vector3.forward);
    }
}

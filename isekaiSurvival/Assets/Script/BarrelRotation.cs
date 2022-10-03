using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BarrelRotation : MonoBehaviour
{
    // Start is called before the first frame update

    private Camera mainCam;
    private void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        TryRotate();
    }

    private void TryRotate()
    {
        if (PauseController.paused) return;
        GunRotation();
    }

    private void GunRotation()
    {
        var direction = (Vector3)Mouse.current.position.ReadValue() - mainCam.WorldToScreenPoint(transform.position);

        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle + 90f, Vector3.forward);
    }
}

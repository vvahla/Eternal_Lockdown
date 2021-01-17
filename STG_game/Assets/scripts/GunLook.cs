using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLook : MonoBehaviour
{
    public Transform gunBody;

    public GameObject camera;

    // Update is called once per frame
    void Update()
    {
        PlayerLook pl = camera.GetComponent<PlayerLook>();

        float mouseX = Input.GetAxis("Mouse X") * pl.mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * pl.mouseSensitivity * Time.deltaTime;

        gunBody.Rotate(Vector3.right * mouseY);
    }
}

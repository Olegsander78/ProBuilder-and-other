using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public CharacterController characterController;

    public Transform cam;
    public float lookSensitivity;
    public float minXRot;
    public float maxXRot;

    private float curXRot;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Move();

        if(Cursor.lockState == CursorLockMode.Locked)
            Look();
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 dir = (transform.right * x) + (transform.forward * z);
        dir.Normalize();

        dir *= moveSpeed * Time.deltaTime;

        characterController.Move(dir);
    }
    private void Look()
    {
        float x = Input.GetAxis("Mouse X") * lookSensitivity;
        float y = Input.GetAxis("Mouse Y") * lookSensitivity;

        transform.eulerAngles += Vector3.up * x;

        curXRot += y;
        curXRot = Mathf.Clamp(curXRot, minXRot, maxXRot);

        cam.localEulerAngles = new Vector3(-curXRot, 0f, 0f);
    }
}

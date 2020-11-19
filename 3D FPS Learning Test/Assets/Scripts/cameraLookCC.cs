using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraLookCC : MonoBehaviour
{

    public Transform playerBody;
    public Transform playedHead;
    private float xRotation;
    public float sensitivity = 100f;
    private float sensMultiplier = 2.5f;
    private float verticalSens = 1f;
    private float horizontalSens = 1f;
    private float xSens;



    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerBody.transform.position;
        transform.position = playedHead.transform.position;

        rotation();
    }


    private void rotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * sensMultiplier * horizontalSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * sensMultiplier * verticalSens * Time.deltaTime;


        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}

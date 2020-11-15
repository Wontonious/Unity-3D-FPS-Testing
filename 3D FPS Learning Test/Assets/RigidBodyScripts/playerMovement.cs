using System;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    //Assignable Variables
    public Transform playerCamera;
    public Transform playerBody;
    public object groundCheck;

    //Camera rotation stuff
    private float xRotation;
    private float yRotation;
    public float sensitivity = 100f;
    private float sensMultiplier = 2.5f;
    private float verticalSens = 1f;
    private float horizontalSens = 1f;
    private float xSens;

    //Jump
    public bool isGrounded = true;
    public float jumpForce = 550f;
    //private float gravity = -9.81f;

    //Movement
    private Rigidbody rb;
    public float movementSpeed = 100f;
    private float speedMultiplier = 40f;
    public LayerMask groundLayer;




    void Awake()
    {
        //Initalizes the Rigidbody
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        input();
        rotation();
    }

    void LateUpdate()
    {
        movement();
    }


    //Camera Rotation
    private void rotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * sensMultiplier * horizontalSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * sensMultiplier * verticalSens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        yRotation += mouseX;

        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        playerBody.transform.localRotation = Quaternion.Euler(0f, yRotation, 0f);

    }

    private void movement()
    {
        Vector2 xMov = new Vector2(Input.GetAxisRaw("Horizontal") * transform.right.x, Input.GetAxisRaw("Horizontal") * transform.right.z);
        Vector2 zMov = new Vector2(Input.GetAxisRaw("Vertical") * transform.forward.x, Input.GetAxisRaw("Vertical") * transform.forward.z);

        Vector2 velocity = (xMov + zMov).normalized * movementSpeed * Time.deltaTime * speedMultiplier;

        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.y);

    }

    private void OnCollisionStay(Collision other)
    {
        int layer = other.gameObject.layer;
        if (groundLayer != (groundLayer | (1 << layer))) return;
        isGrounded = true;
    }


    //private float groundDistance = Vecotr3.Distance(layer.Ground, groundCheck);
    private void input()
    {

        if (Input.GetButtonDown("Jump")&&isGrounded)
        {
            rb.AddForce(0f, jumpForce, 0f);
            isGrounded = false;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{

    public Animator slidingDoor;
    public LayerMask groundMask;
    public Transform playerCheck;


    public bool playerOn = false;
    private float playerDistance = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        slidingDoor = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerOn = Physics.CheckSphere(playerCheck.position, playerDistance, groundMask);

        if (playerOn)
        {
            slidingDoor.SetBool("playerCheck", true);
        }
    }
}

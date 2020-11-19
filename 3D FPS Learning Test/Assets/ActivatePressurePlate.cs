using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePressurePlate : MonoBehaviour
{

    public Transform playerCheck;

    public Animator pressurePlate;
    public LayerMask playerMask;


    public bool playerOn = false;
    private float playerDistance = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        pressurePlate = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        pressurePlate.SetBool("playerCheck", false);

        playerOn = Physics.CheckSphere(playerCheck.position, playerDistance, playerMask) ;

        if (playerOn)
        {
            pressurePlate.SetBool("playerCheck", true);

        }
    }

}

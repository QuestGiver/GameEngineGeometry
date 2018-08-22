using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 10;
    public int isunning = 1;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 normalizedMoevment = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isunning = 2;
        }
        else
        {
            isunning = 1;
        }


        if (Input.GetKey(KeyCode.W))
        {
            normalizedMoevment += transform.forward;
        }

        if (Input.GetKey(KeyCode.A))
        {
            normalizedMoevment += -transform.right;
        }

        if (Input.GetKey(KeyCode.S))
        {
            normalizedMoevment += -transform.forward;
        }

        if (Input.GetKey(KeyCode.D))
        {
            normalizedMoevment += transform.right;
        }



        controller.Move(normalizedMoevment.normalized * speed * isunning * Time.deltaTime);
        controller.Move(new Vector3(0, -9.8f, 0) * Time.deltaTime);


    }

}

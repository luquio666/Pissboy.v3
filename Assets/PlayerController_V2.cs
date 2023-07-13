using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_V2 : MonoBehaviour
{
    public float movementSpeed = 2f;
    public float diagonalReduction = .75f;
    public float x = 0;
    public float z = 0;
    [Space]
    private CharacterController controller;
    Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        moveDirection = Vector3.zero;
        x = 0;
        z = 0;

        // upright
        if (Input.GetKey(KeyCode.W))
        {
            x = 1;
        }

        // upleft
        if (Input.GetKey(KeyCode.A))
        {
            z = 1;
        }

        // downleft
        if (Input.GetKey(KeyCode.S))
        {
            x = -1;
        }

        // downright
        if (Input.GetKey(KeyCode.D))
        {
            z = -1;
        }

        // fix added values on diagonals
        if (Mathf.Abs(x) > 0 && Mathf.Abs(z) > 0)
        {
            x *= diagonalReduction;
            z *= diagonalReduction;
        }

        moveDirection = new Vector3(x, 0, z);

        controller.Move(moveDirection * movementSpeed * Time.deltaTime);
    }
}

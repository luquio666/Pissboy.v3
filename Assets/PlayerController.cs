using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 2f;             
    public float rotationSpeed = 100f;
    public float accelerationMulti = 1f;
    public float deccelerationMulti = 2f;
    public float smoothDecceleration = 5f;

    private CharacterController controller;

    private float verticalInput;
    private float horizontalInput;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        verticalInput = 0f;
        horizontalInput = 0f;
    }

    private void Update()
    {
        float rawVerticalInput = 0f;
        float rawHorizontalInput = 0f;

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            rawVerticalInput = 1f;
        }
        else
        {
            rawVerticalInput = 0f;

            if (Input.GetKey(KeyCode.A))
            {
                rawHorizontalInput = -1f;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                rawHorizontalInput = 1f;
            }
            else
            {
                rawHorizontalInput = 0f;
            }
        }

        if (verticalInput != rawVerticalInput)
        {
            // moving foward
            if (rawVerticalInput > 0f)
            {
                verticalInput += Time.deltaTime * accelerationMulti;
                if (verticalInput > rawVerticalInput)
                {
                    verticalInput = rawVerticalInput;
                }
            }
            // stop foward movement
            else 
            {
                verticalInput -= Time.deltaTime * deccelerationMulti;
                if (verticalInput < 0f)
                    verticalInput = 0f;
            }
            
        }

        if (horizontalInput != rawHorizontalInput)
        {
            if (rawHorizontalInput > 0f)
            {
                horizontalInput += Time.deltaTime * accelerationMulti;
                if (horizontalInput > rawHorizontalInput)
                {
                    horizontalInput = rawHorizontalInput;
                }
            }
            else if (rawHorizontalInput < 0f)
            {
                horizontalInput -= Time.deltaTime * accelerationMulti;
                if (horizontalInput < rawHorizontalInput)
                {
                    horizontalInput = rawHorizontalInput;
                }
            }
            else
            {
                horizontalInput = Mathf.Lerp(horizontalInput, 0f, smoothDecceleration * Time.deltaTime);
            }
        }


        // Calcula la dirección del movimiento
        Vector3 moveDirection = transform.forward * verticalInput;

        // Rota el personaje hacia la dirección del movimiento
        transform.Rotate(Vector3.up * horizontalInput * rotationSpeed * Time.deltaTime);

        // Aplica el movimiento al personaje
        controller.Move(moveDirection * movementSpeed * Time.deltaTime);

        // Configura los parámetros del Animator
        //animator.SetFloat("Speed", moveDirection.magnitude);

        // Otros parámetros de animación como saltar, atacar, etc.
        // animator.SetBool("IsJumping", isJumping);
        // animator.SetBool("IsAttacking", isAttacking);
    }
}
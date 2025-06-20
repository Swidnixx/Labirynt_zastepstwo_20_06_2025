using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 12f;

    public Transform groundCheck;
    public LayerMask groundMask;

    Vector3 velocity;
    CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }


    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;


        RaycastHit hit;
        if (Physics.Raycast(groundCheck.position,
            Vector3.down,
            out hit, 0.4f, groundMask))
        {
            string terrainType;
            terrainType = hit.collider.gameObject.tag;

            switch (terrainType)
            {
                default:
                    speed = 12;
                    break;
                case "Low":
                    speed = 3;
                    break;
                case "High":
                    speed = 20;
                    break;
            }
        }

        characterController.Move(move * speed * Time.deltaTime);

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "PickUp")
        {
            hit.gameObject.GetComponent<PickUp>().Picked();
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float moveSpeed = 12f;

    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    [SerializeField] private Transform shopSpawn;
    [SerializeField] private Transform arenaSpawn;

    

    Vector3 velocity;
    bool isGrounded;
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * moveSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.B))
            TeleportToShop();
        if (Input.GetKeyDown(KeyCode.T))
            TeleportToArena();

        if (Input.GetKeyDown(KeyCode.C))
            BuyCoolPoints();
    }

    void TeleportToShop()
    {
        gameObject.transform.position = shopSpawn.transform.position;
    }

    void TeleportToArena()
    {
        gameObject.transform.position = arenaSpawn.transform.position;
    }

    void BuyCoolPoints()
    {
        GetComponent<MoveTowardsPlayer>().soulsCollectedNumber -= 1;
    }
}

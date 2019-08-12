using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pallet : MonoBehaviour
{
    public float paddleSpeed = 1f;


    private Vector3 playerPos,  startingPos;

    private void Start()
    {
        playerPos = transform.position;
        startingPos = playerPos;
    }

    void Update()
    {
        // Get Horizontal Input
        float h = Input.GetAxisRaw("Horizontal");

        // Set Velocity (movement direction * speed)
        GetComponent<Rigidbody2D>().velocity = Vector2.right * h * paddleSpeed;


        if (Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene(0);
        }
    }
}

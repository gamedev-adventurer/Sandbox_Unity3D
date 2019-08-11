using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rigidBody2D;

    void Awake()
    {

        rigidBody2D = GetComponent<Rigidbody2D>();
        rigidBody2D.velocity = Vector2.up * speed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Hit the Racket?
        if (col.gameObject.tag == "racket")
        {
            // Calculate hit Factor
            float x = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.x);

            //float x = col.gameObject.GetComponent<Rigidbody2D>().velocity.x;
            // Calculate direction, set length to 1
            Vector2 dir = new Vector2(x, 1).normalized;
            Debug.Log(dir);
            // Set Velocity with dir * speed
            rigidBody2D.velocity = dir * speed;
        }

        if(col.gameObject.tag == "OutOfBounds")
        {
            SceneManager.LoadScene(0);
        }
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketWidth)
    {
        // ascii art:
        //
        // 1  -0.5  0  0.5   1  <- x value
        // ===================  <- racket
        //
        return (ballPos.x - racketPos.x) / racketWidth;
    }
}

    
    

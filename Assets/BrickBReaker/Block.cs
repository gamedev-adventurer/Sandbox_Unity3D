using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    Vector2 originalPosition;
    float xPos, movX, yPos, movY, angZ, rotZ, startTime, verticalTime = 1.5f, horizontaTime = 1.5f, zeroAngle = 0, rectAngle = 90;
    bool canMove, canJump;
    int direction = 1;

    Rigidbody2D rigidbody2D;
    BoxCollider2D collider;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        SaveOriginalPosition();
        InitialAnimation(0);
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        // Destroy the whole Block
        //Destroy(gameObject);
  
        EndAnimation(0);
        StartCoroutine(JumpCoroutine());
    }
 

    public void SaveOriginalPosition()
    {
        originalPosition = new Vector2(transform.position.x, transform.position.y);
    }


    public void InitialAnimation(float delay)
    {
        Reset();
        StartCoroutine(InitialAnimationsCoroutine(delay));
    }

    public void EndAnimation(float delay)
    {
         if(canMove)
        {
            StartCoroutine(EndAnimationsCoroutine(delay));
        }

    }

    void StartMovement()
    {
       StartCoroutine(AngularMovementCoroutine(1.5f));
    }

    void StopMovement()
    {
        canMove = false;
    }

    void Reset()
    {
        movX = 0;
        angZ = 0;
        canMove = true;
        canJump = false;
        direction = (Random.Range(0f, 10f) < 5) ? -1 : 1;
        transform.position = new Vector2(originalPosition.x, originalPosition.y);
        transform.eulerAngles = new Vector3(90, 0, 0);
    }

    IEnumerator InitialAnimationsCoroutine(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        float angle = 90;
        while (angle > 0)
        {
            transform.eulerAngles = new Vector3(angle, 0, 0);
            angle = transform.eulerAngles.x - Time.deltaTime * 90 / startTime;
            yield return new WaitForEndOfFrame();
        }
        transform.eulerAngles = new Vector3(0, 0, 0);
        StartMovement();
    }

    IEnumerator EndAnimationsCoroutine(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        StopMovement();
        float angle = 0;
        while (angle < 90)
        {
            transform.eulerAngles = new Vector3(angle, 0, 0);
            angle = transform.eulerAngles.x + Time.deltaTime * 90 / startTime;
            yield return new WaitForEndOfFrame();
        }

        canJump = true;
    }


    IEnumerator JumpCoroutine()
    {
        yield return new WaitForEndOfFrame();
        rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        rigidbody2D.velocity = new Vector2(2, 10);
        collider.isTrigger = true;

        yield return new WaitForSeconds(1f);
        rigidbody2D.velocity = new Vector2(2, -8);
    }

    IEnumerator AngularMovementCoroutine(float time)
    {
        while (canMove)
        {
            rotZ += Time.deltaTime * time * 5 * direction;
            angZ = Mathf.Sin(rotZ) * 4;
            transform.eulerAngles = new Vector3(0, 0, angZ);
            yield return new WaitForEndOfFrame();
        }
    }
}

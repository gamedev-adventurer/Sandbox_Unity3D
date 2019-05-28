using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GridController gamesGrid;

    public enum PlayerStates
    {
        idle,
        WaitForOpening,
        moving,
        reachedGoal
    }

    public PlayerStates state;
    public Transform target;

    [Header("Top View")]
    public bool inTop;
    public bool outTop;
    public GameObject topCell;

    [Header("Bottom View")]
    public bool inBottom;
    public bool outBottom;
    public GameObject bottomCell;

    [Header("Rigth View")]
    public bool inRight;
    public bool outRight;
    public GameObject rightCell;


    [Header("Left View")]
    public bool inLeft;
    public bool outLeft;
    public GameObject leftCell;


    // Start is called before the first frame update
    void Start()
    {
        gamesGrid = GameObject.Find("Grid").GetComponent<GridController>();
    }

    private void FixedUpdate()
    {
        RaycastInBlocks();
        RaycastOutBlocks();
    }

    void RaycastInBlocks()
    {
        int insideMask = 1 << gamesGrid.insideMask;
        RaycastHit2D hitBottom = Physics2D.Raycast(transform.position, Vector2.down, 2, insideMask);
        inBottom = false;
        if (hitBottom.collider != null)
        {

           if (hitBottom.collider.gameObject.CompareTag("open"))
            {
                Debug.Log("botton open");
                inBottom = true;
            }

        }

        RaycastHit2D hitTop = Physics2D.Raycast(transform.position, Vector2.up, 2, insideMask);
        inTop = false;
        if (hitTop.collider != null)
        {
            if (hitTop.collider.gameObject.CompareTag("open"))
            {
                Debug.Log("top open");
                inTop = true;
            }

        }

        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, 2, insideMask);
        inLeft = false;
        if (hitLeft.collider != null)
        {
            if (hitLeft.collider.gameObject.CompareTag("open"))
            {
                Debug.Log("left open");
                inLeft = true;
            }

        }

        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, 2, insideMask);
        inRight = false;
        if (hitRight.collider != null)
        {

            if (hitRight.collider.gameObject.CompareTag("open"))
            {
                Debug.Log("left open");
                inRight = true;
            }
        }
    }

    void RaycastOutBlocks()
    {
        int outsideMask = 1 << gamesGrid.outsideMask;
        RaycastHit2D hitBottom = Physics2D.Raycast(transform.position, Vector2.down, 2, outsideMask);
        outBottom = false;
        bottomCell = null;
        if (hitBottom.collider != null)
        {
            if (hitBottom.collider.gameObject.CompareTag("open"))
            {
                Debug.Log("botton open");
                outBottom = true;
                bottomCell = hitBottom.collider.transform.parent.transform.parent.gameObject;
            }

        }

        RaycastHit2D hitTop = Physics2D.Raycast(transform.position, Vector2.up, 2, outsideMask);
        outTop = false;
        topCell = null;
        if (hitTop.collider != null)
        {
            if (hitTop.collider.gameObject.CompareTag("open"))
            {
                Debug.Log("top open");
                outTop = true;
                topCell = hitTop.collider.transform.parent.transform.parent.gameObject;
            }

        }
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, 2, outsideMask);
        outLeft = false;
        leftCell = null;
        if (hitLeft.collider != null)
        {
            if (hitLeft.collider.gameObject.CompareTag("open"))
            {
                Debug.Log("left open");
                outLeft = true;
                leftCell = hitLeft.collider.transform.parent.transform.parent.gameObject;
            }

        }

        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, 2, outsideMask);
        outRight = false;
        rightCell = null;
        if (hitRight.collider != null)
        {
            if (hitRight.collider.gameObject.CompareTag("open"))
            {
                Debug.Log("left open");
                outRight = true;
                rightCell = hitRight.collider.transform.parent.transform.parent.gameObject;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case PlayerStates.idle:

                break;
            case PlayerStates.WaitForOpening:
                WaitingForOpening();
                break;
            case PlayerStates.moving:
                MoveToPosition();
                break;
            case PlayerStates.reachedGoal:

                break;
        }
    }


    void WaitingForOpening()
    {
        if(inBottom && outBottom)
        {
            target = bottomCell.transform;
            state = PlayerStates.moving;
        }
        else if (inTop && outTop)
        {
            target = topCell.transform;
            state = PlayerStates.moving;
        }

       else if (inLeft && outLeft)
        {
            target = leftCell.transform;
            state = PlayerStates.moving;
        }

        else if (inRight && outRight)
        {
            target = rightCell.transform;
            state = PlayerStates.moving;
        }
        else
        {
            state = PlayerStates.idle;
        }

    }

    void MoveToPosition()
    {
        // Move our position a step closer to the target.
        float step = 2 * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            state = PlayerStates.WaitForOpening;
        }
    }

    public void WinGame()
    {
        state = PlayerStates.reachedGoal;
    }
}

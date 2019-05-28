using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class cell : MonoBehaviour
{

    GridController grid;

    // Start is called before the first frame update
    void Start()
    {
        grid = transform.parent.GetComponent<GridController>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Rotate()
    {
        Debug.Log("Rotate");

        float rotationDegree = 90.0f;

        transform.RotateAround(transform.position, Vector3.forward, rotationDegree);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player enter");
            transform.GetComponentInChildren<Piece>().ChangeLayer(grid.insideMask);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player exit");
            transform.GetComponentInChildren<Piece>().ChangeLayer(grid.outsideMask);
            Rotate();
        }
    }


}

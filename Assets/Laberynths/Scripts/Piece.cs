using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public enum PiecesTypes
    {
        AllClosed,
        OneSide,
        OneWay,
        L,
        U,
        AllOpen

    }

    public PiecesTypes type;


    public void ChangeLayer(int newLayer)
    {
        this.gameObject.layer = newLayer;
        foreach(Transform child in transform)
        {
            child.gameObject.layer = newLayer;
        }
    }

}

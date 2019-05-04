using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Active,
    Taken,
    Inactive

}

public enum Type
{
    Fixed,
    Temporal,
    Drop

}
public class PowerUp : MonoBehaviour
{
    int price;
    State state;
    Type type;



    public void Set(int _price, State _state, Type _type)
    {
        price = _price;
        type = _type;
        state = State.Inactive;
    }

    public void Activate()
    {
        state = State.Active;

    }


    public void Take()
    {
        state = State.Taken;
    }

    public void Deactivate()
    {
        state = State.Inactive;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : PowerUp
{
    public ExtraLife(int price, State state, Type type)
    {
        Set(price, state, type);
    }
}

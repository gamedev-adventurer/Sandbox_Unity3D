using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarnStamina : PowerUp
{
    public EarnStamina(int price, State state, Type type)
    {
        Set(price, state, type);
    }
}

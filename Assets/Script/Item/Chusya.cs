using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chusya : BuyableItem,Buyable
{
    [SerializeField] GameObject bounusStage;
    public new void Buy()
    {
        base.Buy();
        bounusStage.SetActive(true);
        Destroy(gameObject);

    }
    
}

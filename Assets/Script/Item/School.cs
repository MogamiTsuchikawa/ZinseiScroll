using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class School : BuyableItem,Buyable
{
    [SerializeField] int gakuryoku;
    // Start is called before the first frame update
    float time = 0;
    public new void Buy()
    {
        if(time > 0.3f)
        {
            time = 0;
            base.Buy();
            playerStatus.gakuryoku += gakuryoku;
        }
        
    }
    void Update()
    {
        time += Time.deltaTime;
    }
}

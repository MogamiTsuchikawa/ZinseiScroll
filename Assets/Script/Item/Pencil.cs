using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pencil : BuyableItem,Buyable
{
    [SerializeField] int gakuryoku;
    // Start is called before the first frame update
    
    public new void Buy()
    {
        base.Buy();
        playerStatus.gakuryoku += gakuryoku;
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0.5f, -0.5f, 0));
    }
}

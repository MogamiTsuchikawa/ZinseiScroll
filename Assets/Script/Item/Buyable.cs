using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Buyable
{
    void Buy();
    string about { get; }
    int nedan { get; }
}

public class BuyableItem:MonoBehaviour
{
    [SerializeField] string aboutText;
    [SerializeField] int initnedan;
    public PlayerStatus playerStatus;
    public void Buy()
    {
        playerStatus.money -= initnedan;
        playerStatus.gameManager.PlaySE(SEKind.BuyItem);

    }
    public string about
    {
        get
        {
            return aboutText;
        }
    }
    public int nedan
    {
        get { return initnedan; }
    }
    void Start()
    {
        playerStatus = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
        
    }
}

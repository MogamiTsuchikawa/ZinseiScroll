using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public GameManager gameManager;
    
    [SerializeField]int maxHp;
    Animator animator;
    private int ihp;
    public int hp
    {
        get { return ihp; }
        set 
        {
            if (ihp > value) gameManager.OnDamage();
            ihp = value; 
        }
    }
    private int imoney=0;
    public int money
    {
        get
        {
            return imoney;
        }
        set
        {
            if (value < 0) gameManager.GameOver(GameOverKind.借金地獄で死);
            imoney = value;
        }
    }
    private int igakuryoku = 0;
    public int gakuryoku
    {
        get
        {
            return igakuryoku;
        }
        set
        {
            igakuryoku = value;

        }
    }
    private int izenkou = 0;
    public int zenkou { get { return izenkou; } set { izenkou = value; } }
    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
        animator = GetComponent<Animator>();
    }
    private int iseicho = 0;
    public int seicho
    {
        get { return iseicho; }
        set
        {
            animator.SetInteger("CharaStatus", value);
            iseicho = value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

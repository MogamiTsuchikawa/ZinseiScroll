using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oshigoto : MonoBehaviour
{
    public int value;
    public int zenkou;
    [SerializeField] SEKind sekind;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, -0.5f, 0));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            var playerStatus = collision.GetComponent<PlayerStatus>();
            if(playerStatus.seicho == 3)
            {
                value *= 5;
                zenkou *= 5;
            }
            playerStatus.money += value;
            playerStatus.zenkou += zenkou;
            playerStatus.gameManager.PlaySE(sekind);
            Destroy(gameObject);
        }
    }
}

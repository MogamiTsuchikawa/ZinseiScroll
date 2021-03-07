using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sagishi : MonoBehaviour
{
    [SerializeField] int value;
    [SerializeField] SEKind sekind;
    [SerializeField] float speed;
    private float ispeed=0;
    [SerializeField] Sprite laghImage;
    Rigidbody2D rigidbody;
    private bool flag = true;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = new Vector2(-ispeed, rigidbody.velocity.y);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && flag)
        {
            var playerStatus = collision.gameObject.GetComponent<PlayerStatus>();
            playerStatus.money -= value;
            playerStatus.gameManager.PlaySE(sekind);
            GetComponent<SpriteRenderer>().sprite = laghImage;
            flag = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "GimmickStart")
        {
            ispeed = speed;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] int value;
    [SerializeField] SEKind sekind;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0.5f, -0.5f,0));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            var playerStatus = collision.GetComponent<PlayerStatus>();
            playerStatus.money += value;
            playerStatus.gameManager.PlaySE(sekind);
            Destroy(gameObject);
        }
    }
}

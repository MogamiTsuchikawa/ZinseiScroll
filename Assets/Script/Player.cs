using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] GameManager gameManager;
    bool isGrounded;
    Animator animator;
    PlayerStatus playerStatus;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerStatus = GetComponent<PlayerStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal");
        
        if(x != 0 && gameManager.isAlive)
        {
            if (x > 0) transform.eulerAngles = new Vector3(0, 0, 0);
            else transform.eulerAngles = new Vector3(0, 180f, 0);
            animator.SetBool("IsWalk", true);
            rigidbody.velocity = new Vector2(x * speed, rigidbody.velocity.y);
        }
        else
        {
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
            animator.SetBool("IsWalk", false);
        }
        isGrounded = Physics2D.Linecast(transform.position, transform.position - (Vector3.up * 2f),groundLayer);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && gameManager.isAlive)
        {
            rigidbody.AddForce(Vector2.up * jumpForce);
        }

        if (transform.position.y < -5) gameManager.GameOver(GameOverKind.普通に死);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Syakai":
                playerStatus.hp -= 1;
                if (playerStatus.hp <= 0) gameManager.GameOver(GameOverKind.社会について行けなくて死);
                break;
            case "Truck":
                playerStatus.hp -= 1;
                if (playerStatus.hp <= 0) gameManager.GameOver(GameOverKind.トラックに挽かれて異世界転生して死);
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        switch (collision.tag)
        {
            case "Seicho":
                var seicho = collision.GetComponent<Seicho>();
                seicho.RunSeicho(playerStatus);
                break;
            case "Buyable":
                gameManager.buyPanel.SetActive(true);
                gameManager.buyPanelText.text = collision.GetComponent<Buyable>().nedan.ToString() + "円";
                break;
            case "Gimmick":
                var gimmick = collision.GetComponent<IGimmick>();
                gameManager.gimmickPanel.SetActive(true);
                gameManager.gimmickText.text = gimmick.about;
                break;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Buyable":
                gameManager.buyPanel.SetActive(false);
                break;
            case "Gimmick":
                gameManager.gimmickPanel.SetActive(false);
                break;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E)) switch (collision.tag)
        {
            case "Buyable":
                collision.GetComponent<Buyable>().Buy();
                break;
            case "Gimmick":
                collision.GetComponent<IGimmick>().Run();
                break;
        }
    }

}

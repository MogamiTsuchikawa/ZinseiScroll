using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saihu : MonoBehaviour,IGimmick
{
    Transform saihuPosition;
    GameManager gameManager;
    [SerializeField] Transform child;
    bool hasSaihu = false;
    Transform saihuOwner;
    Transform player;
    float time = 0;
    [SerializeField] Sprite yorokobi;
    public string about
    {
        get
        {
            return "財布を拾います";
        }
    }
    public void Run()
    {
        transform.parent = saihuPosition;
        saihuPosition.localPosition = Vector3.zero;
        gameManager.gimmickText.text = "財布を盗む";
        gameManager.gimmickPanel.SetActive(true);
        hasSaihu = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        saihuPosition = GameObject.Find("SaihuPosition").transform;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        saihuOwner = GameObject.Find("SaihuOwner").transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        child.Rotate(new Vector3(0, 0.5f, 0));
        var near = Vector3.Distance(player.position, saihuOwner.position) < 3;
        if (near && hasSaihu)
        {
            gameManager.gimmickText.text = "財布を返す";
            gameManager.gimmickPanel.SetActive(true);
        }
        if (!near && hasSaihu)
        {
            gameManager.gimmickText.text = "財布を盗む!";
            gameManager.gimmickPanel.SetActive(true);
        }
        if (hasSaihu) time += Time.deltaTime;

        if (hasSaihu && Input.GetKeyDown(KeyCode.E) &&time>0.2f)
        {
            var playerStatus = player.gameObject.GetComponent<PlayerStatus>();
            if (near)
            {
                //返す
                playerStatus.zenkou += 1000;
                playerStatus.money += 1000;
                saihuOwner.gameObject.GetComponent<SpriteRenderer>().sprite = yorokobi;
            }
            else
            {
                //盗む
                playerStatus.zenkou -= 1000;
                playerStatus.money += 10000;
                gameManager.PlaySE(SEKind.GetGold);
            }
            gameManager.gimmickPanel.SetActive(false);
            Destroy(gameObject);
        }
    }
}

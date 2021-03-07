using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seicho : MonoBehaviour
{
    [SerializeField] int toSeicho;
    GameManager gameManager;
    public void RunSeicho(PlayerStatus playerStatus)
    {
        if (toSeicho == 2&& playerStatus.gakuryoku >= 2000)toSeicho++;
        gameManager = playerStatus.gameManager;
        playerStatus.seicho = toSeicho;
        gameManager.PlaySE(SEKind.Seicho);
        gameManager.seichoPanel.SetActive(true);
        gameManager.seichoImage.sprite = gameManager.seichoImages[toSeicho-1];
        Invoke("ClosePanel", 0.7f);
    }
    void ClosePanel()
    {
        gameManager.seichoPanel.SetActive(false);
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

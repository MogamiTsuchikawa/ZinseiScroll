using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isAlive = true;
    [SerializeField] PlayerStatus playerStatus;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] Text gameOverText;
    [SerializeField] Image dieImage;
    [SerializeField] List<Sprite> dieImages=new List<Sprite>(); 
    [SerializeField] Text lifeText;
    [SerializeField] Image damagePanelImage;
    [SerializeField] Text moneyText;
    [SerializeField] Text gakuryokuText;
    [SerializeField] Text zenkouText;
    public GameObject buyPanel;
    public Text buyPanelText;
    public GameObject gimmickPanel;
    public Text gimmickText;
    public GameObject seichoPanel;
    public Image seichoImage;
    public List<Sprite> seichoImages = new List<Sprite>();
    [SerializeField] AudioClip damageSE;
    [SerializeField] AudioClip coingetSE;
    [SerializeField] AudioClip goldgetSE;
    [SerializeField] AudioClip itembuySE;
    [SerializeField] AudioClip gameoverSE;
    [SerializeField] AudioClip seichoSE;
    [SerializeField] AudioClip sagiSE;
    [SerializeField] CameraMove cameraMove;
    private AudioSource audioSource;
    public void GameOver(GameOverKind gameOverKind)
    {
        if (isAlive)
        {
            cameraMove.moveSpeed = 0;
            isAlive = false;
            playerStatus.gameObject.GetComponent<Animator>().SetBool("Dead", true);
            gameOverText.text = gameOverKind.ToString();
            dieImage.sprite = dieImages[(int)gameOverKind];
            gameOverPanel.SetActive(true);
            PlaySE(SEKind.GameOver);
            Invoke("GoToResult", 3f);
        }
    }
    void GoToResult()
    {
        PlayerPrefs.SetInt("Kane", playerStatus.money);
        PlayerPrefs.SetInt("Zenkou", playerStatus.zenkou);
        SceneManager.LoadScene("Result");
    }
    public void OnDamage()
    {
        //ダメージを受けたときのエフェクトのみを処理
        damagePanelImage.color = new Color(1,0,0,0.5f);
        audioSource.clip = damageSE;
        audioSource.Play();
    }
    
    public void PlaySE(SEKind sEKind)
    {
        switch (sEKind)
        {
            case SEKind.GetMoney:
                audioSource.clip = coingetSE;
                break;
            case SEKind.GetGold:
                audioSource.clip = goldgetSE;
                break;
            case SEKind.BuyItem:
                audioSource.clip = itembuySE;
                break;
            case SEKind.OnDamage:
                audioSource.clip = damageSE;
                break;
            case SEKind.GameOver:
                audioSource.clip = gameoverSE;
                break;
            case SEKind.Seicho:
                audioSource.clip = seichoSE;
                break;
            case SEKind.Sagi:
                audioSource.clip = sagiSE;
                break;

        }
        audioSource.Play();
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        string lifeStr = "";
        for (int i = 0; i < playerStatus.hp; i++) lifeStr += "O";
        lifeText.text = lifeStr;
        if(damagePanelImage.color.a != 0)
            damagePanelImage.color = new Color(1, 0, 0, damagePanelImage.color.a - 0.005f);
        moneyText.text = "所持金:" + playerStatus.money + "円";
        gakuryokuText.text = "学力:" + playerStatus.gakuryoku + "";
        zenkouText.text = "善行:" + playerStatus.zenkou;
    }
}
public enum GameOverKind
{
    社会について行けなくて死=0,トラックに挽かれて異世界転生して死,借金地獄で死,普通に死
}
public enum SEKind
{
    GetMoney,GetGold,OnDamage,BuyItem,GameOver,Seicho,Sagi
}


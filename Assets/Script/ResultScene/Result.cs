using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    [SerializeField] Text moneyText;
    [SerializeField] Text zenkouMoneyText;
    [SerializeField] Text sumText;
    [SerializeField] AudioClip kaneSE;
    [SerializeField] AudioClip waiSE;
    [SerializeField] GameObject btn;
    AudioSource audioSource;
    // Start is called before the first frame update
    IEnumerator RunResult()
    {
        int zenkou = PlayerPrefs.GetInt("Zenkou");
        int kane = PlayerPrefs.GetInt("Kane");
        Debug.Log(zenkou);
        moneyText.text = kane.ToString() + "円";
        yield return new WaitForSeconds(1f);
        moneyText.gameObject.SetActive(true);
        Kane();
        yield return new WaitForSeconds(0.5f);
        zenkouMoneyText.text = "0 x 100 = 0円";
        zenkouMoneyText.gameObject.SetActive(true);
        Kane(); 
        yield return new WaitForSeconds(0.1f);
        int p = 100;
        if (zenkou > 10000) p = 1000;
        int i = 0;
        /*for (;i<=zenkou;i += p)
        {
            zenkouMoneyText.text = $"{i} x 100 = {i * 100}円";
            Kane();
            yield return new WaitForSeconds(0.2f);
        }
        i -= p;
        Debug.Log(i + "iValue");*/
        if(zenkou > i)
        {
            Debug.Log("//");
            zenkouMoneyText.text = $"{zenkou} x 100 = {zenkou * 100}円";
            Kane();
            yield return new WaitForSeconds(0.2f);
        }
        if(zenkou < 0)
        {
            zenkouMoneyText.text = $"{zenkou} x 100 = {zenkou * 100}円";
            Kane();
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.7f);
        kane += zenkou * 100;
        sumText.text = $"合計 {kane}円";
        sumText.gameObject.SetActive(true);
        Kane();
        yield return new WaitForSeconds(1f);
        btn.SetActive(true);
    }
    public void OnClick()
    {
        SceneManager.LoadScene("Title");
    }
    void Kane()
    {
        audioSource.clip = kaneSE;
        audioSource.Play();
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(RunResult());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

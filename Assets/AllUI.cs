using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AllUI : Singleton<AllUI>
{
    [HideInInspector]
    public int coin;
    [HideInInspector]
    public int coin_total;
    public int life;
    public int life_total;
    [HideInInspector]
    public int chest;
    [HideInInspector]
    public int chest_total;

    public TextMeshProUGUI LifeLabel;

    public TextMeshProUGUI CoinLabel;

    public TextMeshProUGUI ChestLabel;
    public GameObject GameOverPanel;

    public AudioClip GameoverClip;
    public bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        CoinLabel.text = coin + "/" + coin_total;
        LifeLabel.text = life + "/" + life_total;
        ChestLabel.text = chest + "/" + chest_total;
    }
    public void damage(int value = 1)
    {
        if (isDead)
        {
            return;
        }
        //Debug.Log("damage " + value);
        life -= value;
        life = Mathf.Clamp(life, 0, life_total);
        LifeLabel.text = life + "/" + life_total;
        if (life == 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        isDead = true;
        GameOverPanel.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(GameoverClip);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void collect(int type,AudioClip clip)
    {
        if (isDead)
        {
            return;
        }
        //Debug.Log("collect "+type);
        if (type == 0)
        {
            coin += 1;
            coin = Mathf.Clamp(coin, 0, coin_total);
            CoinLabel.text = coin + "/" + coin_total;
        }
        else if(type == 1)
        {

            chest += 1;
            chest = Mathf.Clamp(chest, 0, chest_total);
            ChestLabel.text = chest + "/" + chest_total;
        }
        else if (type == 2)
        {
            damage(-1);
        }
        GetComponent<AudioSource>().PlayOneShot(clip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

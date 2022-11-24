using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int life;
    public int coins;
    public TextMeshProUGUI CoinText;
    public GameObject[] lifeImage;

    public GameObject gameWinUI,gameLoseUI, gameUI;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        life = 3;
        coins = 0;
        gameLoseUI.SetActive(false);
        gameWinUI.SetActive(false);
        gameUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(life<=0)
        {
            endGame();
        }
        if (coins>=100)
        {
            gameWin();
        }


        CoinText.text = "Coins: " + coins.ToString();
        for (int i = 0; i < lifeImage.Length; i++)
        {
            if( i<life)
            {
                
                lifeImage[i].SetActive(true);
            }else
            {
                lifeImage[i].SetActive(false);
            }
        }

    }
    public void decreaseHealth()
    {
        life--;
    }
    public void coinIncrease()
    {
        coins++;
    }

    public void endGame()
    {
        //game pause 
        Time.timeScale = 0;
        //show game end UI
        gameUI.SetActive(false);
        gameLoseUI.SetActive(true);

    }
    public void gameWin()
    {
        //game pause
        Time.timeScale = 0;
        gameUI.SetActive(false);
        gameWinUI.SetActive(true);
    }
}

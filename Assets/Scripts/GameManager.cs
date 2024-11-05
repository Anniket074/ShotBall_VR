using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;
    
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one instance of GameManager found!");
            return;
        }
        instance = this;
    }
    #endregion

    public GameObject currentPlayerTurn;
    public GameObject[] bot;
    private List<GameObject> botList;

    public bool isOut;
    public GameObject playerOut;
    bool isGameOver = true;
    public GameObject GameEndpanel;
    public GameObject GameWinpanel;
    private void Start()
    {
        // Convert the array to a List<GameObject>
        botList = new List<GameObject>(bot);
        //SetRandomBotToShoot();
        GameEndpanel.SetActive(false);
    }

    private void Update()
    {
        Debug.Log(botList.Count);
        GameOver();
        if (botList.Count == 0)
        {
            GameWinpanel.SetActive(true);
        }
    }
    public void GameOver()
    {

        if (!playerOut.activeSelf && isGameOver)
        {
            print("Game Over");
            isGameOver = false;
            GameEndpanel.SetActive(true);
        }
        
    }

    public void IsBotOut()
    {
        currentPlayerTurn.SetActive(false);
        Debug.Log("Bot is out!");

        for (int i = 0; i < bot.Length; i++)
        {
            if (!bot[i].activeSelf)
            {
                GameObject botToRemove = botList[i];
                botList.Remove(botToRemove);
                bot = botList.ToArray();
                isOut = true;
                SetRandomBotToShoot();
               
            }
        }
    }

    public void SetRandomBotToShoot()
    {
        if (botList.Count > 0)
        {
            int randomIndex = Random.Range(0, botList.Count);
            bot[randomIndex].GetComponent<TennisBallMachine>().isShoot = true;
        }
    }
}

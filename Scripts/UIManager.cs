using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject[] UIElements;
    public static UIManager instance = null;
    public static UIManager Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        instance = this;
    }
    public void DisableUIElements(bool disable)
    {
        if (disable)
        {
            for (int i = 0; i < UIElements.Length; i++)
            {
                UIElements[i].SetActive(false);
            }
        }
        if (!disable)
        {
            for (int i = 0; i < UIElements.Length; i++)
            {
                UIElements[i].SetActive(true);
            }
        }
    }
    int score;
    public int money = 5;
    [SerializeField] Text textScore;
    [SerializeField] Text textMoney;
    [SerializeField] Text textHealth;
    public float playerHealth = 10;

    public int IncreaseScore(bool getINT, bool Getmoney)
    {
        if (!getINT)
        {
            score += 100;
            money++;
            return 0;
        }
        if (Getmoney)
        {
            return money;
        }
        return 0;
    }
    public int selectedBuilding = 0;
    [SerializeField] GameObject[] selectedSquare;
    public void SelectBuiling(int building)
    {
        if(building == 1)
        {
            selectedSquare[1].SetActive(true);
            selectedSquare[0].SetActive(false);
            selectedBuilding = 1;
        }
        if (building == 0)
        {
            selectedSquare[1].SetActive(false);
            selectedSquare[0].SetActive(true);
            selectedBuilding = 0;
        }
    }
    void Start()
    {

    }

    void Update()
    {
        textHealth.text = "remaining health: " + playerHealth;
        textScore.text = "score: " + score;
        textMoney.text = "money: " + money;
    }
}
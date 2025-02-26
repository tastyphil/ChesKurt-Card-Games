using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoundOptionScript : MonoBehaviour
{
    public Sprite[] chipSheet;
    public TMP_Text roundType, betAmount, betCondition;
    public int bet;
    public double[] WAGER_RATES = {0.1, 0.25, 0.50, 1, 3};
    public Image chipType;
    public String[] betTitle = {
        "Small Bet", "Large Bet", "Larger Bet", "All-In Bet", "Crazy Bet"
    };
    public String[] betDesc = {
        "Betting 10% won't hurt!", "Quarter In, More Quarters Out!", "Betting 50% doesnt mean 50/50", "DOUBLE OR NOTHING", "RAAAAAAAAAA!!"
    };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update() {
        
    }

    public void InitButton(int x) {
        // Initialize Chip Type's Sprite
        chipType.GetComponent<Image>().sprite = chipSheet[x];

        // Initialize Round Type, Amount to Wager, Wager Description, and its textboxes
        roundType.text = betTitle[x];
        bet = Convert.ToInt32(Menu_Main.balance * WAGER_RATES[x]);
        betAmount.text = $"> Wager {bet} Chips!";
        betCondition.text = betDesc[x];        
    }

    public void loadGame() {
        GameParameters.SetGameParameters(roundType.text, bet, Menu_Main.balance);
        SceneManager.LoadScene("BlackJack_Game");
    }
}

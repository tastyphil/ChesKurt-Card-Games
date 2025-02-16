using UnityEngine;

public class GameParameters : MonoBehaviour
{
    public static string betType, printGameResult;
    public static int wagerAmount, round = 0, balance;
    public static int playerLastScore, dealerLastScore;
    public static int gameWinner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void SetGameParameters(string bet, int wager, int bal) {
        betType = bet;
        wagerAmount = wager;
        balance = bal;
        round++;
    }

    public static void SetGameResults(int winner, string result, int player, int dealer) {
        gameWinner = winner;

        if (gameWinner == 1) {
            balance += wagerAmount;
        } else if (gameWinner == -1) {
            balance -= wagerAmount;
        }

        printGameResult = result;
        playerLastScore = player;
        dealerLastScore = dealer;
    }

    public static void SetBalance(int x) {
        balance = x;
    }
}

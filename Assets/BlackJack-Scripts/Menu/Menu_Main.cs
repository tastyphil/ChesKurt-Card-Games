using Unity.Mathematics;
using UnityEngine;

public class Menu_Main : MonoBehaviour
{   
    public GameObject titleScreen, roundSelect, buttonTemp, buttonParent, balanceText;
    public GameObject loseScreen, winScreen, canvas;
    public static int balance = 2000, wager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        RoundOptionParent parent = buttonParent.GetComponent<RoundOptionParent>();
        if (GameParameters.balance == 0 && GameParameters.playerLastScore > 0) {
            canvas.SetActive(false);
            loseScreen.SetActive(true);
            AudioManager.Instance.PlayMusic("gameLose");
        } else if (GameParameters.balance == 100000 && GameParameters.playerLastScore > 0) {
            canvas.SetActive(false);
            winScreen.SetActive(true);
             AudioManager.Instance.PlayMusic("winner");
             AudioManager.Instance.PlaySFX("gameWin");
        } else {
            AudioManager.Instance.PlayMusic("MainMenu");
            // When Startup!
            if (GameParameters.playerLastScore == 0) {
                GameParameters.SetBalance(balance);
                titleScreen.SetActive(true);
                parent.AddOption(Instantiate(buttonTemp, parent.transform.position, Quaternion.identity), 0);
                parent.AddOption(Instantiate(buttonTemp, parent.transform.position, Quaternion.identity), 1);
                parent.AddOption(Instantiate(buttonTemp, parent.transform.position, Quaternion.identity), 2);
            } else if (GameParameters.playerLastScore > 0) { 
                UpdateBalance();
                parent.AddOption(Instantiate(buttonTemp, parent.transform.position, Quaternion.identity), 0);
                parent.AddOption(Instantiate(buttonTemp, parent.transform.position, Quaternion.identity), 1);
                parent.AddOption(Instantiate(buttonTemp, parent.transform.position, Quaternion.identity), 3);
            }

            Balance_Display balanceDisplay = balanceText.GetComponent<Balance_Display>();
            balanceDisplay.UpdateBalance();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void UpdateBalance() {
        balance = GameParameters.balance;
        int result = GameParameters.gameWinner;
        if (result == -1) {
            AudioManager.Instance.PlaySFX("Lose");
        } else if (result == 1) {
             AudioManager.Instance.PlaySFX("Win");
        }
    }
}

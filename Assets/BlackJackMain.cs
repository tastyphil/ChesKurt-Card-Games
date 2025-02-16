using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class BlackJackMain : MonoBehaviour {

    public GameObject drawPile, playerHand, dealerHand, betChip;
    public TMP_Text round, chips, betType, wager;
    private DrawPile pile;
    private PlayerHand player;
    private DealerHand dealer;
    private string gameResult;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        if (GameParameters.wagerAmount == GameParameters.balance) {
            AudioManager.Instance.PlayMusic("AllIn");
        } else {
            AudioManager.Instance.PlayMusic("Game");
        }
        pile = drawPile.GetComponent<DrawPile>();
        player = playerHand.GetComponent<PlayerHand>();
        dealer = dealerHand.GetComponent<DealerHand>();
        BetChipDisplay chipDisplay = betChip.GetComponent<BetChipDisplay>();        
        pile.InitDrawPile();
 
        chipDisplay.InitChip(GameParameters.betType);
        round.text = "ROUND " + GameParameters.round.ToString();
        chips.text = GameParameters.balance.ToString() + " C";
        betType.text = GameParameters.betType.ToUpper();
        wager.text = "WAGERED " + GameParameters.wagerAmount.ToString().ToUpper() + " C";
        for (int i = 1; i <= 2; i++) {
            player.AddCard(pile.DrawCard());
            dealer.AddCard(pile.DrawCard());
        }

        
    }

    // Update is called once per frame
    void Update() {
        
    }

    // Player draws a card
    public void player_hit() {

        player.AddCard(pile.DrawCard()); 

        if (player.GetScore() >= 21) {
            player_stand();
        }  
    }

    public void player_stand() {
        dealer.DealersTurn();
        while (!IsGameOver() && dealer.GetScore() < 17) {
            dealer.AddCard(pile.DrawCard());
        }

        if (IsGameOver()) LoadMenu();
    }

    public void LoadMenu() {
        GameParameters.SetGameResults(GetGameResults(), gameResult, player.GetScore(), dealer.GetScore());
        SceneManager.LoadScene("BlackJack_Menu");
    }

    public bool IsGameOver() {
        return GetGameResults() != 0;
    }

    public int GetGameResults() {
        int p = player.GetScore();
        int d = dealer.GetScore();
        int result = 0;

            if (p == d) {
                Debug.Log("Tie!");
                result = 2;
            } else {
                    if (p > 21) { // Player Busts
                        gameResult = "Player Busts! You lose!";
                        result = -1;
                    }

                    if (p == 21) { // Player BlackJack
                       gameResult = "Player BlackJack! You win!";
                        result = 1;
                    } 

                    if (p < 21) { // Player Stands
                        if (d > 21) { // Dealer Busts
                            gameResult = "Dealer busts! You win!";
                            result = 1;
                        } else if (d == 21) { // Dealer BlackJack
                            gameResult = "Dealer BlackJack! You lost!";
                            result = -1;
                        } else if (d >= 17 && d < 21) { // Dealer Stands
                            if (d > p) { // Dealer has higher total
                                gameResult = "Dealer has higher total! You lost!";
                                result = -1;
                            } else if (p > d){ // Player has higher total
                                gameResult = "Player higher total! You win!";
                                result = 1;
                            }
                        } 
                    }
            }
            

        return result;
    }
}

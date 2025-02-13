using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BlackJackMain : MonoBehaviour {

    public GameObject drawPile, playerHand, dealerHand;
    private DrawPile pile;
    private PlayerHand player;
    private DealerHand dealer;
    private GameObject status;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        pile = drawPile.GetComponent<DrawPile>();
        player = playerHand.GetComponent<PlayerHand>();
        dealer = dealerHand.GetComponent<DealerHand>();
        

        InitBoard();
    }

    // Update is called once per frame
    void Update() {
        
    }

    [ContextMenu("Initialize Board")]
    void InitBoard() {
        pile.InitDrawPile();
        player.ResetHand();
        dealer.ResetHand();

        for (int i = 1; i <= 2; i++) {
            player_hit();
            dealer.AddCard(pile.DrawCard());
        }
    }

    // Player draws a card
    public void player_hit() {
        if (!dealer.GetIsDealersTurn()) {
            player.AddCard(pile.DrawCard());  
        } else if (player.GetScore() == 21) {
            player_stand();
        }   
    }

    public void player_stand() {
        do {
            dealer.DealersTurn();

            while (!IsGameOver(player.GetScore(), dealer.GetScore()) && dealer.GetScore() < 17) {
                dealer.AddCard(pile.DrawCard());
            }
        } while (!IsGameOver(player.GetScore(), dealer.GetScore()));
    }

    public bool IsGameOver(int p, int d) {
        bool result = false;

            if (p > 21) {
                Debug.Log("Player Busts! You lose!");
                result = true;
            } else if (p == 21) {
                if (d == 21) {
                    Debug.Log("Both Blackjack! push!");
                    result = true;
                } else {
                    Debug.Log("Player BlackJack! You win!");
                    result = true;
                }
            } else if (p < 21) {
                if (d > 21) {
                    Debug.Log("Dealer busts! You win");
                    result = true;
                } else if (d == 21) {
                    Debug.Log("Dealer BlackJack! You lost");
                    result = true;
                } else if (d < 21) {
                    if (d > p) {
                        Debug.Log("Dealer Wins!");
                        result = true;
                    } else if (p > d){
                        Debug.Log("You Win");
                        result = true;
                    }
                }
            }
        return result;
    }
}

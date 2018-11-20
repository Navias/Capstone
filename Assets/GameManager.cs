using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	
	enum elements { Army = 1, Navy = 4, Marines = 2, Airforce = 5, Coastguard = 3}


    private int playerChoose = -1;
    private int botChoose = -1;
    private int[,] winTable = new int[6, 6]
    {
        {0,0,0,0,0,0  },
        {0,-1,1,3,1,5 },
        {0,1,-1,2,2,5 },
        {0,3,2,-1,4,3 },
        {0,1,2,4,-1,4 },
        {0,5,5,3,4,-1 }
    };

    private bool playersTurn = true;

    public GameObject WinnerText;

	// Update is called once per frame
	void Update () {

        if (playersTurn && playerChoose == -1) return;
        else
        {
            BotChoose();
        }

        CheckWinner();

	}

    void CheckWinner()
    {
        int winner = winTable[playerChoose, botChoose];
        Debug.Log(winner);
        if (winner == -1)
        {
            //draw!
            WinnerText.GetComponent<Text>().text = "It's a Draw!";
        }
        else if (winner == playerChoose)
        {
            //Player wins!
            WinnerText.GetComponent<Text>().text = "You won! Congratulations!";
        }
        else
        {
            // bot wins!
            WinnerText.GetComponent<Text>().text = "You lost! Better luck next time.";
        }
    }

    public void PlayerChoose(int choose)
    {
        playerChoose = choose;
        playersTurn = false;
    }

    public void BotChoose()
    {
        botChoose = Random.Range(1, 5);
    }
}

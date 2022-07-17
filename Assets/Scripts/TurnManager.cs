using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{

    public GameObject[] players = new GameObject[6];
    public static int turn = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Disable all players other than the one whose turn it is
        for (int i = 0; i < 6; i++)
        {
            if (players[i] != null && i != turn)
            {
                players[i].GetComponent<DieMovement>().enabled = false;
            }
        }
    }

    public void nextTurn()
    {
        validateTurn(); // Check turn

        players[turn].GetComponent<DieMovement>().enabled = false; // Disable die that just moved
        turn++;

        validateTurn(); // Check turn

        players[turn].GetComponent<DieMovement>().enabled = true; // Enable next die
    }

    // Makes sure the current turn belongs to a player
    private void validateTurn()
    {
        while (players[turn] == null)
        {
            turn++;
            if (turn >= 6)
            {
                turn = 0;
            }
        }
    }
}

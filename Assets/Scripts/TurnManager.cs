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
        for (int i = 0; i < 6; i++)
        {
            if (players[i] != null && i != turn)
            {
                players[i].GetComponent<DieMovement>().enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextTurn()
    {
        validateTurn();

        players[turn].GetComponent<DieMovement>().enabled = false;
        turn++;

        validateTurn();

        players[turn].GetComponent<DieMovement>().enabled = true;
    }

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

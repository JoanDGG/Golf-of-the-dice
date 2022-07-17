using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DiceMechanic : MonoBehaviourPunCallbacks
{
    // Array of dice sides sprites to load from Resources folder
    private Sprite[] diceSides;

    // Reference to sprite renderer to change sprites
    private SpriteRenderer rend;

    // Mouse release
    private bool MouseRelease = false;
    private Rigidbody2D rb2d;
    private float velocityX;
    private float velocityY;

    private PhotonView view;

	// Use this for initialization
	private void Start () {

        // Assign Renderer component
        rend = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        view = GetComponent<PhotonView>();

        // Load dice sides sprites to array from Dice subfolder of Resources folder
        diceSides = Resources.LoadAll<Sprite>("Dice");

	}

    private void Update(){
        if(view.IsMine)
        {
            MouseRelease = Input.GetMouseButtonUp(0);
            velocityX = Mathf.Abs(rb2d.velocity.x);
            velocityY = Mathf.Abs(rb2d.velocity.y);

            if (MouseRelease && velocityX < 0.1 && velocityY < 0.1)
            {
                StartCoroutine("RollTheDice");
            }
        }
    }
	
    /*
    // If you left click over the dice then RollTheDice coroutine is started
    private void OnMouseDown()
    {
        StartCoroutine("RollTheDice");
    }
*/

    // Coroutine that rolls the dice
    private IEnumerator RollTheDice()
    {
        // Variable to contain random dice side number.
        // It needs to be assigned. Let it be 0 initially
        int randomDiceSide = 0;

        // Final side or value that dice reads in the end of coroutine
        float finalSide = 0;

        // Loop to switch dice sides ramdomly
        // before final side appears. n itterations here.

        int n = 20;

        for (int i = 0; i <= n; i++)
        {
            // Pick up random value from 0 to 6 (All inclusive)
            randomDiceSide = Random.Range(0, 72);   //72 sprites present with 12 variations of each side

            

            // Set sprite to upper face of dice from array according to random value
            rend.sprite = diceSides[randomDiceSide];

            // Pause before next itteration
            yield return new WaitForSeconds(0.05f);
        }

        // Assigning final side so you can use this value later in the game
        finalSide = randomDiceSide + 1;

        // Show final dice value in Console
        finalSide = Mathf.Ceil(finalSide/12f);
        Debug.Log("Dice side: " + finalSide);
    }
}
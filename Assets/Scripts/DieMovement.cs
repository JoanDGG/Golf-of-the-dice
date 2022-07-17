using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Photon.Pun;
using Photon.Realtime;

public class DieMovement : MonoBehaviourPunCallbacks
{

    //-------------------------------------
    // Array of dice sides sprites to load from Resources folder
    private Sprite[] diceSides;

    // Reference to sprite renderer to change sprites
    private SpriteRenderer rend;
    //-------------------------------------

    // Inputs
    private bool MouseClick = false;
    private bool MouseHeld = false;
    private bool MouseRelease = false;
    private Vector3 mousePosition;
    
    // Values
    public float StrokePower;
    private int numberRolled;

    // Components
    private GameObject arrow;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        //-------------------------------------
        // Assign Renderer component
        rend = GetComponent<SpriteRenderer>();

        // Load dice sides sprites to array from Dice subfolder of Resources folder
        diceSides = Resources.LoadAll<Sprite>("Dice");
        //-------------------------------------

        arrow = GameObject.Find("ArrowRotation");
        arrow.SetActive(false);
        rb2d = GetComponent<Rigidbody2D>();
        
        foreach(Player player in PhotonNetwork.PlayerList) { Debug.Log(player); }
    }

    // Update is called once per frame
    void Update()
    {
        // Get inputs
        MouseClick = Input.GetMouseButtonDown(0);
        MouseHeld = Input.GetMouseButton(0);
        MouseRelease = Input.GetMouseButtonUp(0);
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Die's movement and position details
        float distanceX = mousePosition.x - arrow.transform.position.x;
        float distanceY = mousePosition.y - arrow.transform.position.y;
        float velocityX = Mathf.Abs(rb2d.velocity.x);
        float velocityY = Mathf.Abs(rb2d.velocity.y);

        // Start to aim
        if (MouseClick && velocityX < 0.1 && velocityY < 0.1)
        {
            arrow.SetActive(true);
        }

        // Aiming
        if (MouseHeld && velocityX < 0.1 && velocityY < 0.1)
        {
            // Arrow's rotation according to mouse position
            float angle = (Mathf.Atan(distanceY / distanceX) * Mathf.Rad2Deg);
            angle = distanceX < 0 ? angle + 180 : angle;
            arrow.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

            float distance = Mathf.Sqrt((distanceX * distanceX) + (distanceY * distanceY));

            if (distance < 0.5f) // Minimum arrow distance
            {
                distance = 0.5f;
            }
            else if (distance > 2f) // Maximum arrow distance
            {
                distance = 2f;
            }

            arrow.transform.localScale = new Vector3(distance, 1f, 1f); // Change arrow's size
        }

        // Strike die
        if (MouseRelease && velocityX < 0.1 && velocityY < 0.1 && arrow.activeSelf)
        {
            
            arrow.SetActive(false);
            Stroke(distanceX * StrokePower, distanceY * StrokePower);
            //-------------------------------------
            StartCoroutine("RollTheDice");
            //-------------------------------------
        }
    }

    private void Stroke(float x, float y)
    {
        rb2d.AddForce(new Vector2(x, y)); // Add movement
        numberRolled = Mathf.RoundToInt((Random.value) * 6); // Random number between 0.00 and 6.00
        numberRolled = numberRolled == 0 ? 1 : numberRolled; // If 0 set to 1
        Debug.Log("DICE: " + numberRolled);
        StartCoroutine(ChangeEnvironment()); // Acitvate / Deactivate obstacles
    }
    //--------------------------------------------------------------------------------------------------------
    private IEnumerator RollTheDice()
    {
        // Variable to contain random dice side number.
        // It needs to be assigned. Let it be 0 initially
        int randomDiceSide = 0;

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
        rend.sprite = diceSides[numberRolled*12-1];
    }
    //--------------------------------------------------------------------------------------------------------

    private IEnumerator ChangeEnvironment()
    {
        yield return new WaitForSeconds(0.5f); // Delay code execution to allow die to speed up

        // Wait for die to stop moving
        while (Mathf.Abs(rb2d.velocity.x) >= 0.1 || Mathf.Abs(rb2d.velocity.y) >= 0.1)
        {
            yield return new WaitForSeconds(0.05f);
        }

        // Go through all gameobjects
        string[] tags = {"1", "2", "3", "4", "5", "6"};
        GameObject[] obj = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject g in obj)
        {
            if (g.CompareTag(numberRolled.ToString())) // Activate obstacles according to number rolled
            {
                g.SetActive(true);
            }
            else if (tags.Contains(g.tag)) // Dectivate obstacles according to number rolled
            {
                g.SetActive(false);
            }
        }
    }
}

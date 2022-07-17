using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectDice : MonoBehaviour
{
    private Sprite[] diceSides;
    private SpriteRenderer rend;

    
    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
    }

    private void OnMouseDown()
    {
        StartCoroutine("RollTheDice");
    }

 
    private IEnumerator RollTheDice()
    {

        int randomDiceSide = 0;
        int finalSide = 0;
        for (int i = 0; i <= 20; i++)
        {

            randomDiceSide = Random.Range(0, 6);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }
        finalSide = randomDiceSide + 1;
        Debug.Log(finalSide);
    }
}
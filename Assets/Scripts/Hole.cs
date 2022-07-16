using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{

    public float velocityX;
    public float velocityY;

    private void Awake()
    {
        gameObject.GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb2d = other.gameObject.GetComponent<Rigidbody2D>();
            if (Mathf.Abs(rb2d.velocity.x) <= velocityX && Mathf.Abs(rb2d.velocity.y) <= velocityY)
            {
                ScorePoints();
                Destroy(other.gameObject);
            }
        }
    }

    private void ScorePoints()
    {
        Debug.Log("Score!!!");
    }
}
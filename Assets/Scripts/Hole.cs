using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class Hole : MonoBehaviourPunCallbacks
{

    public float velocityX;
    public float velocityY;
    private MapSelection mapSelection;

    private void Awake()
    {
        gameObject.GetComponent<Collider2D>().isTrigger = true;
    }

    private void Start()
    {
        mapSelection = FindObjectOfType<MapSelection>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb2d = other.gameObject.GetComponent<Rigidbody2D>();
            if (Mathf.Abs(rb2d.velocity.x) <= velocityX && Mathf.Abs(rb2d.velocity.y) <= velocityY)
            {
                ScorePoints(other.gameObject);
                Destroy(other.gameObject);
                //SceneManager.LoadScene("MapSelection");
                mapSelection.map++;
                if (mapSelection.map < 6) {
                    
                    PhotonNetwork.LoadLevel("GolfingScene");

                } else {
                    PhotonNetwork.LoadLevel("Scoreboard");
                }
                
            }
        }
    }

    private void ScorePoints(GameObject die)
    {
        Debug.Log("Score!!! " + die.GetComponent<DieMovement>().numberStrokes);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Pond : MonoBehaviourPunCallbacks
{
    private GameObject staritngPoint;
    private Transform[] spawnPoints;

    private void Awake()
    {
        gameObject.GetComponent<Collider2D>().isTrigger = true;
        staritngPoint = GameObject.Find("StartingPoint");
        spawnPoints = GameObject.Find("SpawnPlayers").GetComponent<SpawnPlayers>().spawnPoints;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, 0f, 0f);
            other.gameObject.transform.position = spawnPoints[PhotonNetwork.LocalPlayer.ActorNumber - 1].position;
        }
    }
}

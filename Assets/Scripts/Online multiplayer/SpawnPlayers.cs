using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class SpawnPlayers : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
    public Text debugText;
    public Transform[] spawnPoints = new Transform[6];

    private void Start()
    {
        PhotonNetwork.Instantiate(
            playerPrefab.name, 
            spawnPoints[PhotonNetwork.LocalPlayer.ActorNumber - 1].position, 
            Quaternion.identity);
        debugText.text = PhotonNetwork.CurrentRoom.ToString();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        debugText.text = PhotonNetwork.CurrentRoom.ToString();
    }
}

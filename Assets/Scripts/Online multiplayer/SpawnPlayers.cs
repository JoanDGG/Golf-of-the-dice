using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class SpawnPlayers : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
    private Text debugText;
    public Transform[] spawnPoints = new Transform[6];

    private void Start()
    {
        debugText = GameObject.Find("DebugText_Text").GetComponent<Text>();
        PhotonNetwork.Instantiate(
            playerPrefab.name, 
            spawnPoints[PhotonNetwork.LocalPlayer.ActorNumber - 1].position, 
            Quaternion.identity);
        debugText.text = PhotonNetwork.CurrentRoom.ToString() 
        + "\n" +  PhotonNetwork.LocalPlayer;
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        debugText.text = PhotonNetwork.CurrentRoom.ToString();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        debugText.text = PhotonNetwork.CurrentRoom.ToString();
    }
}

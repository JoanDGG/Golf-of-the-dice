using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Connect2Server : MonoBehaviourPunCallbacks
{
    public GameObject LoadingText;
    public Button CreateButton;
    public Button JoinButton;
    
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        CreateButton.interactable = false;
        JoinButton.interactable = false;
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        CreateButton.interactable = true;
        JoinButton.interactable = true;
        LoadingText.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Connect2Server : MonoBehaviourPunCallbacks
{
    public GameObject LoadingText;
    public GameObject onlinePanel;
    public Button connectButton;
    
    private void Start()
    {
        LoadingText.SetActive(false);
        onlinePanel.SetActive(false);
    }

    public void Connect()
    {
        LoadingText.SetActive(true);
        SelectRandomName.CheckUsername();
        PhotonNetwork.ConnectUsingSettings();
        connectButton.interactable = false;
    }


    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        onlinePanel.SetActive(true);
        LoadingText.SetActive(false);
        connectButton.gameObject.SetActive(false);
    }
}

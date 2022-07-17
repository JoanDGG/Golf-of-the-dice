using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class LeaveRoom : MonoBehaviourPunCallbacks
{
    public void OnClickLeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }
}

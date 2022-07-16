using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    // UI
    public InputField usernameInput;
    public InputField roomInput;
    public Text currentUsername;

    // Online properties
    private RoomOptions roomOptions = new RoomOptions();

    public void CreateRoom()
    {
        string lobbyName = usernameInput.text;
        if(!string.IsNullOrWhiteSpace(lobbyName))
        {
            CheckUsername();
            roomOptions.MaxPlayers = 6;
            PhotonNetwork.CreateRoom(lobbyName, roomOptions);
        }
        else
        {
            if(!currentUsername.text.Contains("Please enter a username name"))
                currentUsername.text += "\nPlease enter a username name";
        }
    }

    public void JoinRoom()
    {
        string lobbyName = roomInput.text;
        if(!string.IsNullOrWhiteSpace(lobbyName))
        {
            CheckUsername();
            PhotonNetwork.JoinRoom(roomInput.text);
        }
        else
        {
            if(!currentUsername.text.Contains("Please enter a lobby name"))
                currentUsername.text += "\nPlease enter a lobby name";
        }
    }

    public override void OnJoinedRoom()
    {
        currentUsername.text += "\n" + PhotonNetwork.CurrentRoom;
        foreach(Player player in PhotonNetwork.PlayerList) { print(player); }
        //PhotonNetwork.LoadLevel("GameScene");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        if(!currentUsername.text.Contains("No match found"))
            currentUsername.text += "\nNo match found";
    }

    private void CheckUsername()
    {
        string userName = usernameInput.text;
        if(!string.IsNullOrWhiteSpace(userName))
        {
            PhotonNetwork.NickName = usernameInput.text;
        }
        else
        {
            SetRandomName();
        }
        currentUsername.text = "Current Username: " + PhotonNetwork.NickName;
    }

    public void SetRandomName()
    {
        PhotonNetwork.NickName = AINamesGenerator.Utils.GetRandomName();
        usernameInput.text = PhotonNetwork.NickName;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    // UI
    public InputField roomInput;
    public Text debugMessage;
    public Text LoadingText;
    public RoomItem[] roomItemPrefabList = new RoomItem[4];
    List<RoomItem> roomItemList = new List<RoomItem>();
    public Transform contentObject;

    // Online properties
    private RoomOptions roomOptions = new RoomOptions();
    public float timeBetweenUpdates = 1.5f;
    private float nextUpdateTime;

    public void CreateRoom()
    {
        LoadingText.gameObject.SetActive(true);
        string lobbyName = PhotonNetwork.NickName;
        if(!string.IsNullOrWhiteSpace(lobbyName))
        {
            roomOptions.MaxPlayers = 6;
            SelectRandomName.CheckUsername();
            PhotonNetwork.CreateRoom(lobbyName, roomOptions);
        }
        else
        {
            debugMessage.text = "Please enter a username name to create a room";
            LoadingText.gameObject.SetActive(false);
        }
    }

    public void JoinRoom(string roomName = null)
    {
        LoadingText.gameObject.SetActive(true);
        if(!string.IsNullOrEmpty(roomName))
        {
            PhotonNetwork.JoinRoom(roomName);
        }
        else
        {
            string lobbyName = roomInput.text;
            if(!string.IsNullOrWhiteSpace(lobbyName))
            {
                SelectRandomName.CheckUsername();
                PhotonNetwork.JoinRoom(roomInput.text);
            }
            else
            {
                debugMessage.text += "Please enter a lobby name";
                LoadingText.gameObject.SetActive(false);
            }
        }
    }

    public override void OnJoinedRoom()
    {
        foreach(Player player in PhotonNetwork.PlayerList) 
        { 
            print(player);
            print(player.ActorNumber); 
        }
        PhotonNetwork.LoadLevel("TestSelect");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        debugMessage.text += "No match found";
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        if(Time.time >= nextUpdateTime)
        {
            UpdateRoomList(roomList);
            nextUpdateTime = Time.time + timeBetweenUpdates;
        }
    }

    private void UpdateRoomList(List<RoomInfo> list)
    {
        foreach (RoomItem item in roomItemList)
        {
            Destroy(item.gameObject);
        }
        roomItemList.Clear();

        foreach (RoomInfo room in list)
        {
            RoomItem newRoom = Instantiate(
                roomItemPrefabList[Random.Range(0, roomItemPrefabList.Length - 1)], 
                contentObject);
            newRoom.SetRoomName(room.Name);
            roomItemList.Add(newRoom);
        }
    }
}

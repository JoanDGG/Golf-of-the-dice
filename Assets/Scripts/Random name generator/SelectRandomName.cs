using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class SelectRandomName : MonoBehaviourPunCallbacks
{
    private static InputField usernameInput;
    private void Start()
    {
        usernameInput = GameObject.Find("UserName_InputField").GetComponent<InputField>();
    }

    public static void CheckUsername()
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
    }

    public static void SetRandomName()
    {
        PhotonNetwork.NickName = AINamesGenerator.Utils.GetRandomName();
        usernameInput.text = PhotonNetwork.NickName;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Connect2Server : MonoBehaviour
{
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
}

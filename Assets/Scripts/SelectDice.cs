using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class SelectDice : MonoBehaviourPunCallbacks
{
    private Sprite[] diceSides;
    private SpriteRenderer rend;
    private PhotonView view;
    public bool changeScene;
    private MapSelection mapSelection;

    private void Start()
    {
        mapSelection = FindObjectOfType<MapSelection>();
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        view = GetComponent<PhotonView>();
        CallSetting(false);
    }

    private void Update()
    {
        if (changeScene)
        {
            PhotonNetwork.LoadLevel("GolfingScene");
        }
    }

    private void OnMouseDown()
    {
        StartCoroutine("RollTheDice");
    }

 
    private IEnumerator RollTheDice()
    {
        if (view.IsMine && PhotonNetwork.LocalPlayer.ActorNumber == 1)
        {
            int randomDiceSide = 0;
            int finalSide = 0;
            for (int i = 0; i <= 20; i++)
            {

                randomDiceSide = Random.Range(0, 6);
                rend.sprite = diceSides[randomDiceSide];
                yield return new WaitForSeconds(0.05f);
            }
            finalSide = randomDiceSide + 1;
            Debug.Log(finalSide);
            yield return new WaitForSeconds(1f);
            CallSetting(true);
            CallSetMap(randomDiceSide);
        }
    }

    [PunRPC]
    void Setting (bool scene)
    {
        changeScene = scene;
    }

    void CallSetting(bool scene)
    {
        view.RPC("Setting", RpcTarget.All, scene);
    }

    [PunRPC]
    void Map (int map)
    {
        mapSelection.map = map;
    }

    void CallSetMap(int map)
    {
        view.RPC("Map", RpcTarget.All, map);
    }
}

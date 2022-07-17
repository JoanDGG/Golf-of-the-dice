using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelection : MonoBehaviour
{

    public GameObject[] maps = new GameObject[6];
    public int map = 0;
    private GameObject start;
    private GameObject die;

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "GolfingScene")
        {
            Debug.Log("Map: " + map);
            Instantiate(maps[map], new Vector3(2.5f, -1.5f, 20), Quaternion.identity);
        }
    }
}

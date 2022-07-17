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
<<<<<<< HEAD
        Debug.Log("Map: " + map);
        Instantiate(maps[map], new Vector3(2.5f, -1.5f, 20), Quaternion.identity);
        /*start = GameObject.Find("StartingPoint");
        die = GameObject.Find("PinkDice");
        die.transform.position = new Vector3(start.transform.position.x, start.transform.position.y, 0f);*/
    }

    // Update is called once per frame
    void Update()
    {
        
=======
        if(SceneManager.GetActiveScene().name == "GolfingScene")
        {
            Debug.Log("Map: " + map);
            Instantiate(maps[map], new Vector3(2.5f, -1.5f, 20), Quaternion.identity);
        }
>>>>>>> f95c389fc37b6294be6ad4d2ec70f0abf591c69a
    }
}

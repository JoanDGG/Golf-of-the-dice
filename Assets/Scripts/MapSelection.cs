using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelection : MonoBehaviour
{

    public GameObject[] maps = new GameObject[6];
    public static int map = 0;
    private GameObject start;
    private GameObject die;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Map: " + map);
        Instantiate(maps[map], new Vector3(2.5f, -1.5f, 20), Quaternion.identity);
        start = GameObject.Find("StartingPoint");
        die = GameObject.Find("PinkDice");
        die.transform.position = new Vector3(start.transform.position.x, start.transform.position.y, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

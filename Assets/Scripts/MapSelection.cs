using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelection : MonoBehaviour
{

    public GameObject[] maps = new GameObject[6];
    public static int map = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Map: " + map);
        Instantiate(maps[map], new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

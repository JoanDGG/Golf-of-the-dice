using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreChanger : MonoBehaviour
    
{
    public int Value = 0;
    public Text ScoreText;
    public bool Hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = Value.ToString();
        if (Hit)
        {
            AddPoint();
        }

        
    }
    public void AddPoint()
    {
        Value++;
        Hit = false;
    }
}

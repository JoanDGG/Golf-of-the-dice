using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreChangerTotal : MonoBehaviour
{
    public GameObject Hole1;
    public GameObject Hole2;
    public GameObject Hole3;
    public GameObject Hole4;
    public GameObject Hole5;
    public GameObject Hole6;

    ScoreChanger scoreChanger1;
    ScoreChanger scoreChanger2;
    ScoreChanger scoreChanger3;
    ScoreChanger scoreChanger4;
    ScoreChanger scoreChanger5;
    ScoreChanger scoreChanger6;
    public Text Total;
    public int Score;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Awake()
    {
        scoreChanger1 = Hole1.GetComponent<ScoreChanger>();
        scoreChanger2 = Hole2.GetComponent<ScoreChanger>();
        scoreChanger3 = Hole3.GetComponent<ScoreChanger>();
        scoreChanger4 = Hole4.GetComponent<ScoreChanger>();
        scoreChanger5 = Hole5.GetComponent<ScoreChanger>();
        scoreChanger6 = Hole6.GetComponent<ScoreChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        Score = scoreChanger1.Value + scoreChanger2.Value + scoreChanger3.Value + scoreChanger4.Value + scoreChanger5.Value + scoreChanger6.Value;
        Total.text = Score.ToString();
    }
}

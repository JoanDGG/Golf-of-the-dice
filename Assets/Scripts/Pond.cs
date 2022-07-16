using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pond : MonoBehaviour
{
    private GameObject staritngPoint;

    private void Awake()
    {
        gameObject.GetComponent<Collider2D>().isTrigger = true;
        staritngPoint = GameObject.Find("StartingPoint");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, 0f, 0f);
            other.gameObject.transform.position = new Vector3(staritngPoint.transform.position.x, staritngPoint.transform.position.y, 0f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandTrap : MonoBehaviour
{

    public float drag;

    private void Awake()
    {
        gameObject.GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody2D>().drag = drag;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody2D>().drag = 1f;
        }
    }
}

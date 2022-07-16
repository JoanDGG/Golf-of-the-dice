using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieMovement : MonoBehaviour
{

    private bool MouseClick = false;
    private bool MouseHeld = false;
    private bool MouseRelease = false;
    private Vector3 mousePosition;
    private float StrokePower = 0;

    private GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        arrow = GameObject.Find("ArrowRotation");
        arrow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        MouseClick = Input.GetMouseButtonDown(0);
        MouseHeld = Input.GetMouseButton(0);
        MouseRelease = Input.GetMouseButtonUp(0);
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distanceX = 1f; // Default value
        float distanceY = 1f; // Default value

        if (MouseClick)
        {
            arrow.SetActive(true);
        }

        if (MouseHeld)
        {
            distanceX = mousePosition.x - arrow.transform.position.x;
            distanceY = mousePosition.y - arrow.transform.position.y;
            float angle = (Mathf.Atan(distanceY / distanceX) * Mathf.Rad2Deg);
            angle = distanceX < 0 ? angle + 180 : angle;
            arrow.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        }

        if (MouseRelease)
        {
            distanceX = mousePosition.x - arrow.transform.position.x;
            distanceY = mousePosition.y - arrow.transform.position.y;
            StrokePower = Mathf.Sqrt((distanceX * distanceX) + (distanceY * distanceY));
            Debug.Log("Power: " + StrokePower.ToString("F2"));
            arrow.SetActive(false);
        }

        if (Cursor.visible)
        {
            Cursor.visible = false;
        }
    }
}

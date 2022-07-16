using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieMovement : MonoBehaviour
{

    private bool MouseHeld = false;
    private Vector3 mousePosition;
    private float StrokePower = 0;

    private GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        arrow = GameObject.Find("arrow");
    }

    // Update is called once per frame
    void Update()
    {
        MouseHeld = Input.GetMouseButton(0);
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float distanceX = mousePosition.x - transform.position.x;
        float distanceY = mousePosition.y - transform.position.y;
        float angle = (Mathf.Atan(distanceY / distanceX) * Mathf.Rad2Deg);
        angle = distanceX < 0 ? angle + 180 : angle; // If the mouse is behind the die add 180 degrees to compensate for flipping the arrow
        arrow.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        if (Cursor.visible)
        {
            Cursor.visible = false;
        }


        if (MouseHeld)
        {
            Debug.Log("Pressed primary button.");
        }
    }
}

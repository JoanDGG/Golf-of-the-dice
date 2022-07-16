using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieMovement : MonoBehaviour
{

    private bool MouseClick = false;
    private bool MouseHeld = false;
    private bool MouseRelease = false;
    private Vector3 mousePosition;
    public float StrokePower;

    private GameObject arrow;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        arrow = GameObject.Find("ArrowRotation");
        arrow.SetActive(false);
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MouseClick = Input.GetMouseButtonDown(0);
        MouseHeld = Input.GetMouseButton(0);
        MouseRelease = Input.GetMouseButtonUp(0);
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float distanceX = mousePosition.x - arrow.transform.position.x;
        float distanceY = mousePosition.y - arrow.transform.position.y;
        float velocityX = Mathf.Abs(rb2d.velocity.x);
        float velocityY = Mathf.Abs(rb2d.velocity.y);

        if (MouseClick && velocityX < 0.1 && velocityY < 0.1)
        {
            arrow.SetActive(true);
        }

        if (MouseHeld && velocityX < 0.1 && velocityY < 0.1)
        {
            float angle = (Mathf.Atan(distanceY / distanceX) * Mathf.Rad2Deg);
            angle = distanceX < 0 ? angle + 180 : angle;
            arrow.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

            float distance = Mathf.Sqrt((distanceX * distanceX) + (distanceY * distanceY));

            if (distance < 0.5f)
            {
                distance = 0.5f;
            }
            else if (distance > 2f)
            {
                distance = 2f;
            }

            arrow.transform.localScale = new Vector3(distance, 1f, 1f);
        }

        if (MouseRelease && velocityX < 0.1 && velocityY < 0.1 && arrow.activeSelf)
        {
            
            arrow.SetActive(false);
            Stroke(distanceX * StrokePower, distanceY * StrokePower);
        }
    }

    private void Stroke(float x, float y)
    {
        rb2d.AddForce(new Vector2(x, y));
        int numberRolled = Mathf.RoundToInt((Random.value) * 6);
        numberRolled = numberRolled == 0 ? 1 : numberRolled;
        Debug.Log(numberRolled);
        object[] obj = GameObject.FindSceneObjectsOfType(typeof (GameObject));
        foreach (object o in obj)
        {
            GameObject g = (GameObject) o;
            if (g.CompareTag(numberRolled.ToString()))
            {
                Debug.Log(g.name);
            }
        }
    }
}

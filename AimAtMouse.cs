using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtMouse : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        faceMouse();
    }

    void faceMouse()
    {
        Vector3 mousePosition = Input.mousePosition; //follow the mouse
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); // retreive a vector for the object this script is attached to to follow
        Vector2 direction = new Vector2(mousePosition.x + transform.position.x * -1, mousePosition.y - transform.position.y * -1);
        transform.right = direction; // point the attached object in a direction specified by the Vector2 variable direction
    }
}

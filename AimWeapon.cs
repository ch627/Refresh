using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimWeapon : MonoBehaviour
{
    public Transform aimTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        faceMouse();
    }

    void faceMouse()
    {
        Vector3 mouse = Input.mousePosition; //retrieve the mouse position
        mouse = Camera.main.ScreenToWorldPoint(mouse); // change the position to world space
        Debug.Log(mouse);
        Vector3 direction =(mouse - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // get an angle in radians, and multiply it to convertt the angle back into degrees
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
        Debug.Log(angle);
    }
}

using System.Collections;

using System.Collections.Generic;

using UnityEngine;

//https://www.youtube.com/watch?v=0yHBDZHLRbQ&ab_channel=Jayanam

public class Draggable : MonoBehaviour

{
    private Vector3 mOffset;
    private float mZCoord;

    void OnMouseDown()

    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;
        // z coordinate of game object on screen
        mousePoint.z = mZCoord;
        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }



    void OnMouseDrag()
    {
        //the y parameter is fixed but can be graggable  see the video on the top
        transform.position = new Vector3( GetMouseAsWorldPoint().x + mOffset.x,  3f  , GetMouseAsWorldPoint().z + mOffset.z);
    }

}
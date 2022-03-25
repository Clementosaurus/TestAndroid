using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    Vector3 init_pos;
    Quaternion init_angle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void get_dragged(Vector2 v)
    {
        transform.position -= 0.01f * v.x * transform.right;
        transform.position -= 0.01f * v.y * transform.up;
    }



    public void pinch_start()
    {
        init_pos = transform.position;
    }

    public void pinch(float ratio)
    {
        int cons = 5;
        transform.position = init_pos + cons * Mathf.Log(ratio) * transform.forward;
    }



    public void rotate_start()
    {
        init_angle = transform.rotation;
    }

    public void rotate(float angle)
    {
        transform.rotation = init_angle * Quaternion.AngleAxis(-angle, transform.forward);
    }


    public void double_drag_start()
    {

    }

    public void double_drag(Vector2 move)
    {
        // xyz graph
        // forward facing eye, y is up, -x is left, x is right, -z is frm the eye, z is forward
        // phi is angle from y axis to the vector from the origin to our point
        // theta is angle from x axis to vector of our point
        // phi = 0 is up 90°, phi = 180 is down 90°
        // only go from 0° t 180°, otherwise it would flip the camera
        // theta is the same but from left to right
        // all this mess gives a point in a sphere around the camera, and tell the camera to look at it

        float phi = 90 - 180 * move.y / Screen.height;
        phi *= Mathf.Deg2Rad;
        float theta = 90 - 180 * move.x / Screen.width;
        theta *= Mathf.Deg2Rad;
        Vector3 dir = new Vector3(Mathf.Cos(theta) * Mathf.Sin(phi), Mathf.Cos(phi), Mathf.Sin(theta) * Mathf.Sin(phi));
        dir = transform.InverseTransformPoint(dir);
        transform.LookAt(transform.position + dir);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    Renderer my_renderer;
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
        transform.position = init_pos / ratio;
    }



    public void rotate_start()
    {
        init_angle = transform.rotation;
    }

    public void rotate(float angle)
    {
        transform.rotation = init_angle * Quaternion.AngleAxis((-angle), Camera.main.transform.forward);
    }
}

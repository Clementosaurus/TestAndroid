using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControl : MonoBehaviour, IInteractable
{
    float distance = 0;
    Renderer my_renderer;
    bool is_selected = false;
    Vector3 init_scale;
    Quaternion init_angle;

    // Start is called before the first frame update
    void Start()
    {
        my_renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void select_toggle()
    {
        is_selected = !is_selected;

        if (is_selected)
        {
            my_renderer.material.color = Color.red;
        }
        else
        {
            my_renderer.material.color = Color.white;
        }
    }



    public void get_dragged(Ray ray)
    {
        // Drag at the same distance of the camera
        transform.position = ray.GetPoint(distance);
    }

    public void drag_start()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
    }

    public void drag_end()
    {

    }



    public void pinch_start()
    {
        init_scale = transform.localScale;
    }

    public void pinch(float ratio)
    {
        transform.localScale = init_scale * ratio;
    }


    public void rotate_start()
    {
        init_angle = transform.rotation;
    }

    public void rotate(float angle)
    {
        transform.rotation = Quaternion.AngleAxis(angle, transform.forward) * init_angle;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsulControl : MonoBehaviour, IInteractable
{
    Renderer my_renderer;
    bool is_selected = false;
    GameObject our_plane;
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
            my_renderer.material.color = Color.cyan;
            gameObject.layer = 2;
        }
        else
        {
            my_renderer.material.color = Color.white;
            gameObject.layer = 0;
        }
    }



    public void drag_start()
    {
        // Drag along a plane parrallel to the camera

        our_plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        our_plane.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, transform.position.z);
        our_plane.transform.localScale = new Vector3(10, 10, 10);
        our_plane.gameObject.tag = "Plane";
        our_plane.transform.up = (Camera.main.transform.position - our_plane.transform.position).normalized;
        our_plane.GetComponent<Renderer>().enabled = false;
    }

    public void get_dragged(Ray ray)
    {
        // Will check every raycast hit, but will only do stuff for the correct plane (to avoid the floor)
        RaycastHit[] hits = Physics.RaycastAll(ray, 100f);
        foreach(RaycastHit hit in hits)
        {
            if (hit.collider.CompareTag("Plane"))
            {
                transform.position = hit.point;
            }
        }

    }

    public void drag_end()
    {
        Destroy(our_plane);
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
        transform.rotation = init_angle * Quaternion.AngleAxis(angle, transform.forward);
    }
}
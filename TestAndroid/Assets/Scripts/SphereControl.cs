using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereControl : MonoBehaviour, IInteractable
{
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
            my_renderer.material.color = Color.yellow;
            gameObject.layer = 2;
        }
        else
        {
            my_renderer.material.color = Color.white;
            gameObject.layer = 0;
        }
    }



    public void get_dragged(Ray ray)
    {
        RaycastHit[] hits = Physics.RaycastAll(ray, 100f);
        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.CompareTag("Floor"))
            {
                transform.position = hit.point + hit.normal * (my_renderer.bounds.extents.magnitude/2);
            }
        }
    }

    public void drag_start()
    {

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



    //Quick question
    //Why would anyone rotate a ball ?
    public void rotate_start()
    {
        init_angle = transform.rotation;
    }

    public void rotate(float angle)
    {
        transform.rotation = init_angle * Quaternion.AngleAxis(angle, transform.forward);
    }
}
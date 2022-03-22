using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleTouchManagerScript : MonoBehaviour, ITouchController
{

    IInteractable selected_object;
    bool drag_started = false;
    bool pinch_started = false;
    bool rotate_started = false;
    CameraControl my_camera;
    private Vector2 starting_drag_position;


    public void drag(Vector2 current_position)
    {
        Ray our_ray = Camera.main.ScreenPointToRay(current_position);
        Debug.DrawRay(our_ray.origin, our_ray.direction * 100, Color.red, 4f);

        if (selected_object != null)
        {
            if (!drag_started)
            {
                selected_object.drag_start();
                drag_started = true;
            }
            selected_object.get_dragged(our_ray);
        }
        else
        {
            if (!drag_started)
            {
                starting_drag_position = current_position;
                drag_started = true;
            }
            my_camera.get_dragged(current_position-starting_drag_position);
            starting_drag_position = current_position;
        }
    }

    public void drag_end()
    {
        drag_started = false;
        if(selected_object != null)
        {
            selected_object.drag_end();
        }
    }



    public void double_drag(Vector2 current_position)
    {
        Ray our_ray = Camera.main.ScreenPointToRay(current_position);
        Debug.DrawRay(our_ray.origin, our_ray.direction * 100, Color.red, 4f);

        if (!drag_started)
        {
            starting_drag_position = current_position;
            drag_started = true;
        }

        my_camera.get_dragged(current_position - starting_drag_position);
        starting_drag_position = current_position;
    }



    public void pinch(float ratio)
    {
        if (selected_object != null)
        {
            if (!pinch_started)
            {
                selected_object.pinch_start();
                pinch_started = true;
            }
            selected_object.pinch(ratio);
        }

        else
        {
            if (!pinch_started)
            {
                my_camera.pinch_start();
                pinch_started = true;
            }
            my_camera.pinch(ratio);
        }
    }

    public void pinch_end()
    {
        pinch_started = false;
    }




    public void rotate(float angle)
    {
        if (selected_object != null)
        {
            if (!rotate_started)
            {
                selected_object.rotate_start();
                rotate_started = true;
            }
            selected_object.rotate(angle);
        }

        else
        {
            if (!rotate_started)
            {
                my_camera.rotate_start();
                rotate_started = true;
            }
            my_camera.rotate(angle);
        }
    }
    public void rotate_end()
    {
        rotate_started = false;
    }




    public void tap(Vector2 position)
    {
        Ray our_ray = Camera.main.ScreenPointToRay(position);
        Debug.DrawRay(our_ray.origin, our_ray.direction * 50, Color.red, 4f);
        RaycastHit hit_info;
        if (Physics.Raycast(our_ray, out hit_info))
        {
            IInteractable the_object = hit_info.transform.GetComponent<IInteractable>();

            if(( the_object != null))
            {

                if(selected_object != null)
                {
                    selected_object.select_toggle();
                }
                the_object.select_toggle();
                selected_object = the_object;
            }
            else
            {
                selected_object.select_toggle();
                selected_object = null;
            }
        }
        else
        {
            if(selected_object != null)
            {
                selected_object.select_toggle();
                selected_object = null;
            }
                
        }
    }




    // Start is called before the first frame update
    void Start()
    {
        my_camera = Camera.main.GetComponent<CameraControl>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
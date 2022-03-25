using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GestureIdentifier : MonoBehaviour
{
    //duration of the tap
    private float tap_timer;

    // pinch
    private float starting_distance = 0f;
    private float new_relative_distance = 0f;
    private float ratio = 0f;

    // rotation
    private float starting_angle = 0f;
    private float new_angle = 0f;

    // tap
    private bool has_moved;
    private float MAX_ALLOWED_TAP_TIME = 0.2f;

    ITouchController[] managers;
    // Start is called before the first frame update
    void Start()
    {
        managers = FindObjectsOfType<MonoBehaviour>().OfType<ITouchController>().ToArray();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)
        {
            tap_timer += Time.deltaTime;
            Touch[] all_touches = Input.touches;
            Touch first_touch = all_touches[0];

            // All the double touch things
            if(Input.touchCount == 2)
            {
                Touch second_touch = all_touches[1];

                if (second_touch.phase == TouchPhase.Began)
                {
                    // starting distance between the two touches, as well as the angle
                    starting_distance = Vector2.Distance(first_touch.position, second_touch.position);
                    starting_angle = Mathf.Atan2((second_touch.position.y - first_touch.position.y), (second_touch.position.x - first_touch.position.x));
                    starting_angle *= Mathf.Rad2Deg;
                }

                if (first_touch.phase == TouchPhase.Moved || second_touch.phase == TouchPhase.Moved)
                {
                    // update every time a touch moves, to find the new relative distance and the angle
                    new_relative_distance = Vector2.Distance(first_touch.position, second_touch.position);
                    new_angle = Mathf.Atan2((second_touch.position.y - first_touch.position.y), (second_touch.position.x - first_touch.position.x));

                    ratio = new_relative_distance / starting_distance;

                    new_angle = Mathf.Rad2Deg* new_angle;

                    foreach (ITouchController manager in managers)
                    {
                        (manager as ITouchController).pinch(ratio);
                        (manager as ITouchController).rotate(new_angle-starting_angle);
                        (manager as ITouchController).double_drag(first_touch.position);
                    }
                }

                if (second_touch.phase == TouchPhase.Ended)
                {
                    foreach (ITouchController manager in managers)
                    {
                        (manager as ITouchController).pinch_end();
                        (manager as ITouchController).rotate_end();
                        (manager as ITouchController).drag_end();
                    }
                }
            }

            //Single touch things
            if(Input.touchCount == 1)
            {
                switch (first_touch.phase)
                {
                    case TouchPhase.Began:
                        tap_timer = 0f;
                        has_moved = false;

                        break;

                    case TouchPhase.Stationary:

                        break;

                    case TouchPhase.Moved:
                        has_moved = true;

                        if (has_moved)
                        {
                            foreach (ITouchController manager in managers)
                                (manager as ITouchController).drag(first_touch.position);
                        }
                        break;

                    case TouchPhase.Ended:
                        if ((tap_timer < MAX_ALLOWED_TAP_TIME) && !has_moved)
                        {
                            foreach (ITouchController manager in managers)
                                (manager as ITouchController).tap(first_touch.position);
                        }

                        foreach (ITouchController manager in managers)
                            (manager as ITouchController).drag_end();
                        break;
                }
            }
        }
    }
}
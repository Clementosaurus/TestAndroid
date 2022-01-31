using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureIdentifier : MonoBehaviour
{
    private float tap_timer;
    private bool has_moved;
    private float MAX_ALLOWED_TAP_TIME = 0.2f;

    SampleTouchManagerScript manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<SampleTouchManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.touchCount > 0)
        {
            tap_timer += Time.deltaTime;
            Touch[] all_touches = Input.touches;
            Touch first_touch = all_touches[0];
            print(first_touch.phase);

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
                    break;
                case TouchPhase.Ended:
                    if ((tap_timer < MAX_ALLOWED_TAP_TIME) && (!has_moved))
                    {
                        (manager as ITouchController).tap(first_touch.position);
                    }
                    break;
            }
            //transform.position += Vector3.forward;
        }


    }
}

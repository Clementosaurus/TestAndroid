using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void select_toggle();

    void get_dragged(Ray ray);
    void drag_start();
    void drag_end();

    void pinch_start();
    void pinch(float ratio);

    void rotate_start();
    void rotate(float angle);
}
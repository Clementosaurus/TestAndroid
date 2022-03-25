using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITouchController
{
    void tap(Vector2 position);

    void drag(Vector2 current_poisition);
    void drag_end();

    void pinch(float ratio);
    void pinch_end();

    void rotate(float angle);
    void rotate_end();

    void double_drag(Vector2 position);
}

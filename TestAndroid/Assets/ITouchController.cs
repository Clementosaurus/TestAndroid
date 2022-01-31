using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITouchController
{
    void tap(Vector2 position);

    void drag(Vector2 current_poisition);

    void pinch(Vector2 pos1, Vector2 pos2, float relative_distance);
}

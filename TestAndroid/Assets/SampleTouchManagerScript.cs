using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleTouchManagerScript : MonoBehaviour, ITouchController
{
    public void drag(Vector2 current_poisition)
    {
        throw new System.NotImplementedException();
    }

    public void pinch(Vector2 pos1, Vector2 pos2, float relative_distance)
    {
        throw new System.NotImplementedException();
    }

    public void tap(Vector2 position)
    {
        print("I am the manager, tap recieved");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

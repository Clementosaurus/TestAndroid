using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour, IInteractable
{

    Renderer my_renderer;
    Vector3 init_pos;
    Quaternion init_angle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void drag_start()
    {

    }

    public void get_dragged(Ray ray)
    {
        Vector2 positionon_screen = convert(Camera.main.transform.InverseTransformPoint(ray.GetPoint(1)));
        print(positionon_screen);

        Vector3 position = perpendicular_component(Camera.main.transform.InverseTransformPoint(ray.GetPoint(1)), transform.forward);

        transform.position += position;
    }

    public Vector3 parrallel_component(Vector3 v, Vector3 n)
    {
        return Vector3.Dot(v, n) * n;
    }

    public Vector3 perpendicular_component(Vector3 v, Vector3 n)
    {
        return v - parrallel_component(v, n);
    }

    public Vector2 convert(Vector3 position)
    {
        return new Vector2((Screen.width - 1) * (position.x + 1) / 2, (Screen.height-1)*(position.y + 0.5f));
    }

    public void drag_end()
    {

    }



    public void pinch_start()
    {
        init_pos = transform.position;
    }

    public void pinch(float ratio)
    {
        transform.position = init_pos / ratio;
    }



    public void rotate_start()
    {
        init_angle = transform.rotation;
    }

    public void rotate(float angle)
    {
        transform.rotation = init_angle * Quaternion.AngleAxis((-angle), Camera.main.transform.forward);
    }

    public void select_toggle() { }
}

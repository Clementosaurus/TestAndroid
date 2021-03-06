using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateScenery : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject sphere;
    GameObject cube;
    GameObject capsule;
    GameObject floor;

    void Start()
    {
        // Generate the sphere and add SphereControl
        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.AddComponent<SphereControl>();
        sphere.transform.position = new Vector3(3.3f, 0.6f, -5f);

        // Generate the cube and add CubeControl
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.AddComponent<CubeControl>();
        cube.transform.position = new Vector3(-2.5f, 1.5f, -5f);

        // Generate the capsule and add CapsulControl
        capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        capsule.AddComponent<CapsulControl>();
        capsule.transform.position = new Vector3(0.5f, -0.5f, -5f);

        // Generate the ground and change it to green, for *style*
        floor = GameObject.CreatePrimitive(PrimitiveType.Plane);
        floor.transform.position = new Vector3(-0.9f, -2f, -15.5f);
        floor.transform.localScale = new Vector3(6f, 1f, 5f);
        floor.tag = "Floor";
        Renderer floor_renderer = floor.GetComponent<Renderer>();
        floor_renderer.material.color = new Color(0f, 1f, 0.25f);

        // Add the CameraControl script to the camera
        Camera.main.gameObject.AddComponent<CameraControl>();
    }
    void Update(){}
}
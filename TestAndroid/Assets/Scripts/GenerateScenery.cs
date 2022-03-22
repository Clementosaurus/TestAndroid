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
        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.AddComponent<SphereControl>();
        sphere.transform.position = new Vector3(3.3f, 0.6f, -5f);

        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.AddComponent<CubeControl>();
        cube.transform.position = new Vector3(-2.5f, 1.5f, -5f);

        capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        capsule.AddComponent<CapsulControl>();
        capsule.transform.position = new Vector3(0.5f, -0.5f, -5f);

        floor = GameObject.CreatePrimitive(PrimitiveType.Plane);
        floor.transform.position = new Vector3(-0.9f, -2f, -15.5f);
        floor.transform.localScale = new Vector3(6f, 1f, 5f);
        floor.tag = "Floor";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

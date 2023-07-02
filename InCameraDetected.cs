using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class InCameraDetected : MonoBehaviour
{
    Camera cam;
    MeshRenderer renderer;
    Plane[] cameraFrustum;
    Bounds bounds;

    private void Start()
    {
        cam = Camera.main;
        renderer = GetComponent<MeshRenderer>();
        bounds = GetComponent<Collider>().bounds;
    }
    private void Update()
    {
        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(cam);
        if (GeometryUtility.TestPlanesAABB(cameraFrustum, bounds))
        {
            renderer.sharedMaterial.color = Color.green; //in camera view
        }
        else
        {
            renderer.sharedMaterial.color = Color.red; //out camera view
        }
    }
}




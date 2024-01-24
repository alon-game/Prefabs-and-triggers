using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        WrapObject();
    }

    void WrapObject()
    {
        Vector3 viewPos = mainCamera.WorldToViewportPoint(transform.position);

        // Check if the object is outside the screen boundaries
        if (viewPos.x < 0 || viewPos.x > 1)
        {
            // Wrap the object to the opposite side of the screen
            Wrap();
        }
    }

    void Wrap()
    {
        Vector3 newPosition = transform.position;

        // Check if the object is to the left or right of the screen
        if (transform.position.x < mainCamera.ViewportToWorldPoint(Vector3.zero).x)
        {
            newPosition.x = mainCamera.ViewportToWorldPoint(Vector3.one).x;
        }
        else if (transform.position.x > mainCamera.ViewportToWorldPoint(Vector3.one).x)
        {
            newPosition.x = mainCamera.ViewportToWorldPoint(Vector3.zero).x;
        }

        transform.position = newPosition;
    }
}

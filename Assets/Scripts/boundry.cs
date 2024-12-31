using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundryMove : MonoBehaviour
{
    private GameObject cam;
    [SerializeField] private float parallaxEffect = 1;
    private float xPosition;
    private float length;

    void Start()
    {
        cam = GameObject.Find("Main Camera");
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        xPosition = transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distancemoved = cam.transform.position.x * (1 - parallaxEffect);
        float distance_to_move = cam.transform.position.x * parallaxEffect;
        transform.position = new Vector2(xPosition + distance_to_move, transform.position.y);
        if (distancemoved > xPosition + length)
        {
            xPosition = xPosition + length;
        }
        else if (distancemoved < xPosition - length)
        {
            xPosition = xPosition - length;
        }
    }
}

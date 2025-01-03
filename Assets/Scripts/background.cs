using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    private GameObject cam;
    [SerializeField] private float parallaxEffect = 0.1f;
    private float xPosition;
    private float length;

    void Start()
    {
        cam = GameObject.Find("Main Camera");
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        xPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
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

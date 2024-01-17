using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float lenght;
    private float startPos;

    public Transform cam;

    public float parallaxFactor;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float reposition = cam.transform.position.x * (1 - parallaxFactor);
        float distance = cam.transform.position.x * parallaxFactor;

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if(reposition > startPos + lenght)
        {
            startPos += lenght;
        }
    }
}

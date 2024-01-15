using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{
    public List<GameObject> platforms = new List<GameObject>();

    public float offset;

    void Start()
    {
        for(int i = 0; i < platforms.Count; i++)
        {
            Instantiate(platforms[i], new Vector2(i * 30, 0), transform.rotation);
            offset += 30f;
        }

    }

    
    void Update()
    {
        
    }

    public void Recycle(GameObject platform)
    {
        platform.transform.position = new Vector2(offset, 0f);
        offset += 30f;
    }
}

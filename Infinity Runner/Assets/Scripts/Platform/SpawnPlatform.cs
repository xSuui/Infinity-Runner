using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{
    public List<GameObject> platforms = new List<GameObject>(); //lista dos prefabs das plataformas

    private List<Transform> currentPlatforms = new List<Transform>(); //list de plataformas geradas na cena

    private Transform player;
    private Transform currentPlatformPoint;
    private int platformIndex = 0;

    public float offset;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        for(int i = 0; i < platforms.Count; i++)
        {
            Transform p = Instantiate(platforms[i], new Vector2(i * 30, -4.5f), transform.rotation).transform;
            currentPlatforms.Add(p);
            offset += 30f;
        }

        currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platform>().finalPoint;
    }

    
    void Update()
    {
        Move();
    }

    void Move()
    {
        float distance = player.position.x - currentPlatformPoint.position.x;

        if(distance >= 1)
        {
            Recycle(currentPlatforms[platformIndex].gameObject);
            platformIndex++;

            if(platformIndex > currentPlatforms.Count - 1)
            {
                platformIndex = 0;
            }

            currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platform>().finalPoint;
        }
    }

    public void Recycle(GameObject platform)
    {
        platform.transform.position = new Vector2(offset, -4.5f);

        if(platform.GetComponent<Platform>().spawnObj != null)
        {
            platform.GetComponent<Platform>().spawnObj.Spawn();
        }

        offset += 30f;
    }
}

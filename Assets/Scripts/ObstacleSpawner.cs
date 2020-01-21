using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle;

    private float _nextObstacleIn, currentTime;
    
    void Start()
    {
        _nextObstacleIn = 1.0f;
    }


    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > _nextObstacleIn)
        {
            float obstacleX = Random.Range(-1.5f, 1.5f);
            GameObject go = Instantiate(
                obstacle,
                new Vector3( obstacleX, transform.position.y + 0.5f),
                Quaternion.identity,
                transform
                );
            go.GetComponent<ObstacleMove>().speed = Random.Range(2.0f, 6.0f);
            currentTime = 0;
            _nextObstacleIn = Random.Range(1.0f, 2.0f);
        }

    }
}

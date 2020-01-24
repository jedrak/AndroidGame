using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle;
    public Vector3 direction;

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
            GameObject go;
            float obstacleX = Random.Range(-1.5f, 1.5f);
            if(direction.x == 0.0f)
            {
                go = Instantiate(
                obstacle,
                new Vector3( transform.position.x + obstacleX, transform.position.y + 0.5f, transform.position.z),
                transform.rotation,
                transform
                );
            }
            else
            {
                go = Instantiate(
                obstacle,
                new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z + obstacleX),
                transform.rotation,
                transform
                );
            }
           
            go.GetComponent<ObstacleMove>().speed = Random.Range(2.0f, 6.0f);
            go.GetComponent<ObstacleMove>().dir = direction;
            currentTime = 0;
            _nextObstacleIn = Random.Range(1.0f, 2.0f);
        }

    }
}

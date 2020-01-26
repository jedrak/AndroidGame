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
                go.transform.localScale = new Vector3(go.transform.localScale.x/(PlayerPrefs.GetInt("Slvl")+1), go.transform.localScale.y / (PlayerPrefs.GetInt("Slvl") + 1), go.transform.localScale.z / (PlayerPrefs.GetInt("Slvl") + 1));
            }
            else
            {
                go = Instantiate(
                obstacle,
                new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z + obstacleX),
                transform.rotation,
                transform
                );
                go.transform.localScale = new Vector3(go.transform.localScale.x / (PlayerPrefs.GetInt("Slvl") + 1), go.transform.localScale.y / (PlayerPrefs.GetInt("Slvl") + 1), go.transform.localScale.z / (PlayerPrefs.GetInt("Slvl") + 1));
            }
           
            go.GetComponent<ObstacleMove>().speed = Random.Range(1.0f, 20.0f) / (PlayerPrefs.GetInt("Wlvl")+1);
            go.GetComponent<ObstacleMove>().dir = direction;
            currentTime = 0;
            _nextObstacleIn = Random.Range(1.0f, 2.0f);
        }

    }
}

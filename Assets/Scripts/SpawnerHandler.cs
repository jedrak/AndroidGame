using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerHandler : MonoBehaviour
{
    public Transform player;
    public Quaternion lastRot;

    [SerializeField]
    private ObstacleSpawner[] ListOfSpawners;
    // Start is called before the first frame update
    void Start()
    {
        ListOfSpawners = GetComponentsInChildren<ObstacleSpawner>();
        foreach (ObstacleSpawner spawner in ListOfSpawners)
        {
            spawner.enabled = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        
        //debug.text = " " + ListOfSpawners[0].enabled + " " + ListOfSpawners[1].enabled + " " + ListOfSpawners[2].enabled + " " + ListOfSpawners[3].enabled;
        //Debug.Log(buff+ " " + (int)lastRot.eulerAngles.y / 90);

        int buff = (int)player.rotation.eulerAngles.y / 90;
        ListOfSpawners[buff].enabled = true;
        for(int i =0; i<4; i++)
        {
            if(buff != i)
            {
                ListOfSpawners[i].enabled = false;
            }
            
        }

            

        
    }
}

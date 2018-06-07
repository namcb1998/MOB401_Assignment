using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private GameObject[] groundArrays;
    [SerializeField] private float maxLengthJumpOfPlayer;
    private Vector2 whereToSpawn;
    private int randomType;
    private int lastType;
    private bool canSpawn;


    // Use this for initialization
    void Start()
    {
        //maxTimeToSpawn = 1.2f;
        canSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            canSpawn = false;
            randomType = getType();
            GameObject spawnObject = groundArrays[randomType];
            whereToSpawn = new Vector2(transform.position.x+GetRandomSpaceOffsetBetweenTwoSpawn(), transform.position.y);
            Instantiate(spawnObject, whereToSpawn, Quaternion.identity);
        }
    }


    int getType()
    {
        int type = Random.Range(0, groundArrays.Length-1);
        if (type == lastType)
        {
            if (type == 3)
            {
                type = 0;
            }
            else
            {
                type++;
            }
        }


        lastType = type;
        return type;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "LastPositionRespawn")
        {
            canSpawn = true;
        }
    }

    private float GetRandomSpaceOffsetBetweenTwoSpawn()
    {
        float offset = Random.Range(maxLengthJumpOfPlayer/3,maxLengthJumpOfPlayer);
        return offset;
    }

   
}
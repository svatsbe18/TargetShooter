using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    [SerializeField] GameObject player;

    [SerializeField] GameObject[] characters;
    [SerializeField] Transform[] spawnPositions;

    [SerializeField] float minSpawnTime = 2f;
    [SerializeField] float maxSpawnTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time>=Random.Range(minSpawnTime,maxSpawnTime))
        {
            SpawnCharacters();
            minSpawnTime += Time.time;
            maxSpawnTime += Time.time;
        }
    }

    void SpawnCharacters()
    {
        foreach(Transform position in spawnPositions)
        {
            GameObject character = Instantiate(characters[Random.Range(0, characters.Length)]);
            character.transform.position = position.position;
            character.transform.rotation = position.rotation;
            character.AddComponent<TimeObjectDestructor>();
            character.AddComponent<Target>();
        }
    }
}

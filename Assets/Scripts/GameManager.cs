using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    [SerializeField] GameObject player;

    public GameObject ground;
    public float groundMovementSpeed = 4f;
    [HideInInspector] public bool groundMoving = true;

    [SerializeField] GameObject[] characters;
    [SerializeField] Transform[] spawnPositions;

    [SerializeField] float minSpawnTime = 5f;
    [SerializeField] float maxSpawnTime = 10f;
    float nextMinSpawnTime;
    float nextMaxSpawnTime;

    UIManager uIManager;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;

        gm = GetComponent<GameManager>();
        uIManager = FindObjectOfType<UIManager>();

        nextMinSpawnTime = minSpawnTime;
        nextMaxSpawnTime = maxSpawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time>=Random.Range(nextMinSpawnTime,nextMaxSpawnTime))
        {
            SpawnCharacters();
            nextMinSpawnTime = Time.time + minSpawnTime;
            nextMaxSpawnTime = Time.time + maxSpawnTime;
            //minSpawnTime += Time.time;
            //maxSpawnTime += Time.time;
        }

        if(groundMoving)
        {
            ground.transform.Translate(new Vector3(0, 0, -groundMovementSpeed) * Time.deltaTime);
        }

        if(ground.transform.position.z<=player.transform.position.z)
        {
            ground.transform.position = new Vector3(0, 0, 0);
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

    public void GameOver()
    {
        Time.timeScale = 0;
    }

    public void Restart()
    {
        Time.timeScale = 1;
    }
}
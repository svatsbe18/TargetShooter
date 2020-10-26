using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    [SerializeField] GameObject player;

    public GameObject ground;
    public float groundMovementSpeed = 4f;
    [SerializeField] public bool groundMoving = true;

    [SerializeField] GameObject[] characters;
    [SerializeField] Transform[] spawnPositions;

    [SerializeField] float minSpawnTime = 7f;
    [SerializeField] float maxSpawnTime = 15f;

    UIManager uIManager;

    // Start is called before the first frame update
    void Start()
    {
        gm = GetComponent<GameManager>();
        uIManager = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time>=Random.Range(minSpawnTime,maxSpawnTime))
        {
            SpawnCharacters();
            minSpawnTime--;
            maxSpawnTime--;
            minSpawnTime += Time.time;
            maxSpawnTime += Time.time;
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
}
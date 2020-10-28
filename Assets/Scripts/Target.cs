using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    float spawnTime;
    float moveAfterTime = 1.5f;

    int score;
    int notDeadScore;

    UIManager ui;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        ui = FindObjectOfType<UIManager>();

        Score _score = GetComponent<Score>();
        score = _score.score;
        notDeadScore = _score.notDeadScore;

        spawnTime = Time.time;
        moveAfterTime += Time.time;
        GameManager.gm.groundMoving = false;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= moveAfterTime)
        {
            transform.Translate(new Vector3(0, 0, GameManager.gm.groundMovementSpeed) * Time.deltaTime);
            GameManager.gm.groundMoving = true;
        }

        if(transform.position.z<=player.transform.position.z)
        {
            NotDeadPoints();
            Destroy(gameObject);
        }
    }

    public void IsHit()
    {
        ui.ChangeScore(score);
        Destroy(gameObject);
    }

    public void NotDeadPoints()
    {
        ui.ChangeScore(notDeadScore);
    }
}

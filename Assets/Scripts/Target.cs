using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    float spawnTime;
    float moveAfterTime = 1.5f;

    int score;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Score>().score;

        spawnTime = Time.time;
        moveAfterTime += Time.time;
        GameManager.gm.groundMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time>=moveAfterTime)
        {
            transform.Translate(new Vector3(0, 0, GameManager.gm.groundMovementSpeed) * Time.deltaTime);
            GameManager.gm.groundMoving = true;
        }
    }

    public void IsHit()
    {
        FindObjectOfType<UIManager>().ChangeScore(score);
        Destroy(gameObject);
    }
}

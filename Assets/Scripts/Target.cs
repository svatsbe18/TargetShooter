using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    float spawnTime;
    [SerializeField] float moveAfterTime = 1.5f;

    int score;
    int notDeadScore;
    bool dead = false;

    Animator animator;

    Rigidbody rigidbody;

    UIManager ui;

    GameObject player;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        ui = FindObjectOfType<UIManager>();

        Score _score = GetComponent<Score>();
        if(_score==null)
        {
            Debug.LogError("Please add a Score script to the target");
        }
        score = _score.score;
        notDeadScore = _score.notDeadScore;

        spawnTime = Time.time;
        moveAfterTime += Time.time;
        GameManager.gm.groundMoving = false;

        animator = GetComponent<Animator>();
        if(animator==null)
        {
            animator = gameObject.AddComponent<Animator>();
        }

        rigidbody = GetComponent<Rigidbody>();
        if(rigidbody==null)
        {
            rigidbody = gameObject.AddComponent<Rigidbody>();
        }
        rigidbody.useGravity = false;

        audioSource = GetComponent<AudioSource>();

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= moveAfterTime && !dead)
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
        audioSource.Play();
        animator.SetBool("Dead", true);

        dead = true;

        rigidbody.useGravity = true;
        Invoke("Destruct", 1f);        
    }

    void Destruct()
    {
        ui.ChangeScore(score);
        Destroy(gameObject);
    }

    public void NotDeadPoints()
    {
        ui.ChangeScore(notDeadScore);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : MonoBehaviour {

    public ScoreCounter scoreCounter;

    [Header("Set in Inspector")]

    public float speed = 1f;

    public float leftAndRightEdge = 20f;

    public float chanceToChangeDirection = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
    }

     void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Projectile"))
        {
            Destroy(collidedWith);
            scoreCounter.score += 1;
        }
    }
    void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirection)
            speed *= -1;
    }
}
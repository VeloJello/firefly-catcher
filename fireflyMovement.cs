using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireflyMovement : MonoBehaviour
{
    //FLIES COUNT WILL HAVE TO BE HANDLED BY THE SPAWNER.
    //should the spawner move around randomly? that'd be a good way to get them to move around
    //if colliding with ground, try again? how to prevent colliding with ground
    //i can just have a few spawners for now and have them communicate with each other. parent
    //with blank objects for the spawners.
    //randomly picks between spawner1234 for which to spawn fly from

    //tracking velocity and maximum velocity of each instanced fly
    public float flyVelocity;
    public float minFlyVelocity;
    public float maxFlyVelocity;

    // Start is called before the first frame update
    void Start()
    {
        flyVelocity = Random.Range(minFlyVelocity,maxFlyVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(flyVelocity*Random.Range(-1, 2), 
        flyVelocity*Random.Range(-1, 2));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.gameObject);
            caughtTracker.scoreValue ++;
        }
        if (collision.gameObject.name == "Ground")
            DestroyObject(this.gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}

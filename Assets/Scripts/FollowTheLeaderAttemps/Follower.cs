using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public GameObject target;
    public List<Vector3> positions;
    public int distance_permitted;
    public float speed;
    private Vector3 lastLeaderPosition;
    // Use this for initialization
    void Start()
    {
        positions.Add(target.transform.position);
        transform.position = target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (lastLeaderPosition != positions[positions.Count - 1]) //if we move add new pos to array
        {
            positions.Add(target.transform.position);
        }

        if (positions.Count >= distance_permitted)
        {
            if (gameObject.transform.position != positions[0])
            {

                transform.position = Vector3.MoveTowards(transform.position, positions[0], Time.deltaTime * speed);

            }
            else
            {
                positions.Remove(positions[0]);
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                transform.position = Vector3.MoveTowards(transform.position, positions[0], Time.deltaTime * speed);

            }

        }
        lastLeaderPosition = target.transform.position;
    }
}

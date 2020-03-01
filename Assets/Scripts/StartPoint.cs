using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{

    FreeMovement player;
    public Vector2 lookDirection;
    public string pointName;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<FreeMovement>();
        if (player.startPoint == pointName)
        {
            player.transform.position = transform.position;
            player.lookDirection = lookDirection;
        }
        

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

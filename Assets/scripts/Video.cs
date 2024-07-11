using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Video : MonoBehaviour
{
    [SerializeField] Transform character;

    private Vector3 moveTemp;

    public float speed = 1000;
    [SerializeField] float xDifference;
    [SerializeField] float yDifference;

    public float movementThreshold = 10;

    void Update()
    {
        if (character.transform.position.x > transform.position.x)
        {
            xDifference = character.transform.position.x - transform.position.x;
        }
        else
        {
            xDifference = transform.position.x - character.transform.position.x;
        }

        if (character.transform.position.y > transform.position.y)
        {
            yDifference = character.transform.position.y - transform.position.y;
        }
        else
        {
            yDifference = transform.position.y - character.transform.position.y;
        }

        if (xDifference >= movementThreshold || yDifference >= movementThreshold)
        {
            moveTemp = character.transform.position;
            moveTemp.y = 0;
            transform.position = Vector3.MoveTowards (transform.position, moveTemp, speed * Time.deltaTime);
        }
    }
}

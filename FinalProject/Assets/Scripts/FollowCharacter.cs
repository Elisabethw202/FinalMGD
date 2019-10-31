using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCharacter : MonoBehaviour
{
    public Transform player;

    Vector3 startingPosition;
    float followDistance = 0;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = this.transform.position;
        followDistance = player.transform.position.x - this.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(player.position.x, startingPosition.y, startingPosition.z);
    }
}

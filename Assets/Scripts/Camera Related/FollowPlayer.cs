using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject Player;
    //Offset the camera behind the player by adding to players position
    private Vector3 offset = new Vector3(0, 6, -8);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Sets position of camera to position of players current position
        transform.position = Player.transform.position + offset;
    }
}

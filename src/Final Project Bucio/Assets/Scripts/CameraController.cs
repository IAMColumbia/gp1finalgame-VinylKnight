using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private PlayerController player;

    private Vector3 lastPlayerPositition;
    private float distanceToMove;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        lastPlayerPositition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToMove = player.transform.position.x - lastPlayerPositition.x;

        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);

        lastPlayerPositition = player.transform.position;
    }
}

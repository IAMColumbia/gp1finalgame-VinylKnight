using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject thePlatform;
    public Transform generationPoint;

    public float distanceBetween;

    private float platformWidth;

    [SerializeField]
    private float distanceBetweenMin;
    [SerializeField]
    private float distanceBetweenMax;

    // Start is called before the first frame update

    void Start()
    {
        platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);
            Instantiate(thePlatform, transform.position, transform.rotation);      
        }
    }
}

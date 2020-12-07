using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    private float[] platformWidths;
    public GameObject[] thePlatforms;
    
    public GameObject thePlatform;
    public Transform generationPoint;

    //public ObjectPooling theObjectPool;

    public float distanceBetween;
    private float platformWidth;
    private int platformSelector;

    [SerializeField]
    private float distanceBetweenMin;
    [SerializeField]
    private float distanceBetweenMax;

    // Start is called before the first frame update

    void Start()
    {
        //platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
        platformWidths = new float[thePlatforms.Length];

        for (int i = 0; i< thePlatforms.Length; i++)
        {
            platformWidths[i] = thePlatforms[i].GetComponent<BoxCollider2D>().size.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            transform.position = new Vector3(transform.position.x + platformWidths[platformSelector] + distanceBetween, transform.position.y, transform.position.z);

            platformSelector = Random.Range(0, thePlatforms.Length);

            //GameObject newPlatform = theObjectPool.GetPooledObject();

            //newPlatform.transform.position = transform.position;
            //newPlatform.transform.rotation = transform.rotation;
            //newPlatform.SetActive(true);

            Instantiate(thePlatforms[platformSelector], transform.position, transform.rotation);      
        }
    }
}

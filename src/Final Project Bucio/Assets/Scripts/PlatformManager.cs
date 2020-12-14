using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    private float[] platformWidths;
    //public GameObject[] thePlatforms;
    
    
    public GameObject thePlatform;
    public Transform generationPoint;
    public Transform maxHeightPoint;
    public ObjectPooling[] theObjectPool;

    public float distanceBetween;
    private float platformWidth;
    private int platformSelector;
    private float minHeight;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;

    [SerializeField]
    private float distanceBetweenMin;
    [SerializeField]
    private float distanceBetweenMax;

    // Start is called before the first frame update

    void Start()
    {
        //platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
        platformWidths = new float[theObjectPool.Length];

        for (int i = 0; i< theObjectPool.Length; i++)
        {
            platformWidths[i] = theObjectPool[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }
        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);
            if (heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }
            else if (heightChange < minHeight)
            {
                heightChange = minHeight;
            }
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, heightChange, transform.position.z);

            platformSelector = Random.Range(0, theObjectPool.Length);

            GameObject newPlatform = theObjectPool[platformSelector].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);
            
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector]/ 2), transform.position.y, transform.position.z);
            //Instantiate(thePlatforms[platformSelector], transform.position, transform.rotation);      
        }
    }
}

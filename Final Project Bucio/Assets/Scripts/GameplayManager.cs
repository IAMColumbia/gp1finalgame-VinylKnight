using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    [SerializeField]
    private PlayerController thePlayer;
    private Vector3 playerStartPoint;

    private PlatformRemover[] platformList;

    // Start is called before the first frame update
    void Start()
    {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;
    }

    // Update is called once per frame
    //void Update()
    //{

    //}
    public void RestartGame()
    {
        StartCoroutine("RestartGameCo");
    }
    public IEnumerator RestartGameCo()
    {
        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        platformList = FindObjectsOfType<PlatformRemover>();
        thePlayer.transform.position = playerStartPoint;
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);
    }
}

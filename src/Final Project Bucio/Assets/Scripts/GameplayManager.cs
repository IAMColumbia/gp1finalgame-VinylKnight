using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    [SerializeField]
    private PlayerController thePlayer;
    [SerializeField]
    private DeathMenu theDeathMenu;

    private ScoreManager theScoreManager;

    private Vector3 playerStartPoint;

    private PlatformRemover[] platformList;

    // Start is called before the first frame update
    void Start()
    {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;

        theScoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    //void Update()
    //{

    //}
    public void RestartGame()
    {
        theScoreManager.isScoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);

        theDeathMenu.gameObject.SetActive(true);

        //StartCoroutine("RestartGameCo");
    }

    public void Reset()
    {
        theDeathMenu.gameObject.SetActive(false);
        platformList = FindObjectsOfType<PlatformRemover>();
        thePlayer.transform.position = playerStartPoint;
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);
        theScoreManager.scoreCount = 0;
        theScoreManager.isScoreIncreasing = true;
    }
    //public IEnumerator RestartGameCo()
    //{
    //    theScoreManager.isScoreIncreasing = false;
    //    thePlayer.gameObject.SetActive(false);
    //    yield return new WaitForSeconds(0.5f);
    //    platformList = FindObjectsOfType<PlatformRemover>();
    //    thePlayer.transform.position = playerStartPoint;
    //    for (int i = 0; i < platformList.Length; i++)
    //    {
    //        platformList[i].gameObject.SetActive(false);
    //    }
    //    platformGenerator.position = platformStartPoint;
    //    thePlayer.gameObject.SetActive(true);
    //    theScoreManager.scoreCount = 0;
    //    theScoreManager.isScoreIncreasing = true;
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region variables
    public static GameManager Instance { set; get; }
    Coroutine exerciseCoroutine;

    public GameObject exercise;
    public Transform spawn;
    public float exerciseTime = 35f;
    #endregion

    #region singilton
    private void Awake()
    {
        // check if instance is already there
        if (Instance == null)
        {
            //reference to itself
            Instance = this;
            DontDestroyOnLoad(this.gameObject);

            //initialize
            //LoadCurrentHint();

        }
        else
        {
            //just one is allowed
            Destroy(this.gameObject);
        }
    }
    #endregion

    IEnumerator ExerciseChanger()
    {
        while(true)
        {
            Instantiate(exercise, spawn.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(exerciseTime);
        }
    }

    private void Start()
    {
        exerciseCoroutine = StartCoroutine(ExerciseChanger());
        //StopCoroutine(exerciseCoroutine); to stop specific coroutine
    }
}

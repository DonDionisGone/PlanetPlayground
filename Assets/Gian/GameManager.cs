using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region variables
    public static GameManager Instance { set; get; }
    Coroutine exerciseCoroutine;

    public GameObject[] exercise;
    public Transform spawn;
    public float exerciseTime = 35f;
    public int currentExercise = -1;

    // Mat Change
    protected Renderer render;
    public Material originalMat;
    public Material[] activeMat;

    public GameObject faceMask;
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
            if(currentExercise < 3) // exercise.length -1
            {
                currentExercise++;
            }
           
            foreach (GameObject go in exercise)
            {
                go.SetActive(false);
            }

            //Instantiate(exercise[], spawn.transform.position, Quaternion.identity);
            exercise[currentExercise].SetActive(true);
            ChangeMat();

            yield return new WaitForSeconds(exerciseTime);
        }
    }

    private void Start()
    {
        exerciseCoroutine = StartCoroutine(ExerciseChanger());
        //StopCoroutine(exerciseCoroutine); to stop specific coroutine
        //ChangeMatBack();
    }

    public virtual void ChangeMat()
    {
        //originalMat = render.material;
        render = faceMask.GetComponent<Renderer>(); //face mesh
        render.material = activeMat[currentExercise];
    }

    public virtual void ChangeMatBack()
    {
        render.material = originalMat;
    }
}

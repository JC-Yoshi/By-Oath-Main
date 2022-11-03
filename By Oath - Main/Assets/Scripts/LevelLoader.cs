using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    private IEnumerator Start()
    {
        yield return null;
        yield return new WaitForEndOfFrame();
        transition.SetTrigger("End");
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            LoadNextLevel();

        }*/
    }
    public void LoadMenu()
    {
       StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 1));
    }
    public void LoadMenuFromBoss()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 2));
    }
    public void LoadNextLevel()
    {
       StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
      
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSecondsRealtime(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }




}

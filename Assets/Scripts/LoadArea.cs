using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadArea : MonoBehaviour
{
    public string LevelToLoad;
    public GameObject obj;
    Animator levelLoader;

    private void Start()
    {
        levelLoader = obj.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Load new area!");
        levelLoader.SetTrigger("FadeOut");
        //Time.timeScale = 0;
        StartCoroutine("WaitForAnimation");
    }
    IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(LevelToLoad);
    }
}

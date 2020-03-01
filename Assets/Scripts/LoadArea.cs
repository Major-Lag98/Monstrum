using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadArea : MonoBehaviour
{
    public string LevelToLoad;
    public GameObject obj;
    Animator levelLoader;

    public string exitName;

    FreeMovement player;

    private void Start()
    {
        player = FindObjectOfType<FreeMovement>();
        levelLoader = obj.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.startPoint = exitName;
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

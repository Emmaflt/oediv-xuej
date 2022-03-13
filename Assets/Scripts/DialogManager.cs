using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]

public class DialogManager : MonoBehaviour
{

    public GameObject[] dialogObjects;
    public bool dialogFinished = false;
    public string levelToLoad;
    public GameObject fade;


    void Start()
    {
        StartCoroutine(showDialogs());
    }

    void Update()
    {
        if (dialogFinished) {
            SceneManager.LoadScene(levelToLoad);

        }
    }

    IEnumerator showDialogs() {
        yield return new WaitForSeconds(2.5f);
        for (int i = 0; i < dialogObjects.Length; i++) {
            dialogObjects[i].SetActive(true);
            yield return new WaitForSeconds(2.5f);
            Debug.Log("I showed a new dialog");
        }
        fade.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        dialogFinished = true;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] public string scenePath;
    public Animator transition;

    public void mainGameScene()
    {
        StartCoroutine(WaitBeforeLoadingScene());
    }

    IEnumerator WaitBeforeLoadingScene()
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(scenePath);
        loadOperation.allowSceneActivation = false;
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(2f);
        loadOperation.allowSceneActivation = true;
    }
}

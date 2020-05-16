using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private static LevelManager _instance;
    public static LevelManager Instance
    {
        get { return _instance; }
    }

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Animator cardAnimator;
    [SerializeField]
    private Slider loadBar;

    void Awake()
    {
        if (_instance == null || _instance != this)
        {
            _instance = this;
        }
    }

    public void LoadLevel(string levelName)
    {
        StartCoroutine(LoadLevelAsync(levelName));
    }

    private IEnumerator LoadLevelAsync(string levelName)
    {
        loadBar.value = 0;
        cardAnimator.StopPlayback();
        animator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1.0f);
        AsyncOperation op = SceneManager.LoadSceneAsync(levelName);
        while (!op.isDone)
        {
            loadBar.value = Mathf.Clamp01(op.progress / 0.9f);
            yield return null;
        }
        animator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1.0f);
        cardAnimator.StartPlayback();
    }
}

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

    public Theme theme;
    public Difficulty difficulty;

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Animator cardAnimator;
    [SerializeField]
    private Slider loadBar;
    private bool battleSceneLoaded;

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

    public void LoadBattleLevel()
    {
        if(theme == Theme.Select || difficulty == Difficulty.Select) {return;}
        StartCoroutine(LoadBattleLevelAsync());
    }

    public void OnBattleSceneLoaded(bool loaded)
    {
        if (loaded)
        {
            battleSceneLoaded = true;
            theme = Theme.Select;
            difficulty = Difficulty.Select;
        }
    }

    public void SetTheme(Theme _theme)
    {
        theme = _theme;
    }

    public void SetDifficulty(Difficulty _difficulty)
    {
        difficulty = _difficulty;
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

    private IEnumerator LoadBattleLevelAsync()
    {
        battleSceneLoaded = false;
        loadBar.value = 0;
        cardAnimator.StopPlayback();
        animator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1.0f);
        AsyncOperation op = SceneManager.LoadSceneAsync("GameScene");
        while (!op.isDone)
        {
            loadBar.value = Mathf.Clamp(op.progress / 0.9f, 0f, 0.97f);
            yield return null;
        }
        loadBar.value = 0.97f;
        while(!battleSceneLoaded)
        {
            yield return null;
        }
        animator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1.0f);
        cardAnimator.StartPlayback();
    }
}

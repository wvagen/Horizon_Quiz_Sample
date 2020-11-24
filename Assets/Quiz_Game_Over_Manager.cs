using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Quiz_Game_Over_Manager : MonoBehaviour
{
    public GameObject container;
    public GameObject GameOverPanel, PausedPanel, HowToPlayPanel;
    public GameObject[] successGameObjects;
    public GameObject[] failureGameObjects;

    public Sprite musicBtnOnSprite, musicBtnOffSprite;
    public Sprite sfxBtnOnSprite, sfxBtnOffSprite;

    public Image musicImg, sfxImg;

    public GameObject[] starsOwned;

    public static bool musicOn = true;
    public static bool sfxOn = true;

    public string levelMapGameName;

    bool isStarScaled = true;
    bool isContainerScaled = false;
    byte starsScaledCount = 0;

    const string gameDataKey = "game_data_level";
    const string LEVEL_REACHED_KEY = "Level_Reached";

    void Start()
    {
        Time.timeScale = 1;
        SoundsStats();
    }

    public void WinLoseLevelManager(bool isWin)
    {
        GameOverPanel.SetActive(true);
        foreach (GameObject o in successGameObjects)
        {
            o.SetActive(isWin);
        }
        foreach (GameObject o in failureGameObjects)
        {
            o.SetActive(!isWin);
        }
        foreach (GameObject star in starsOwned)
        {
            star.SetActive(false);
        }

        StartCoroutine(containerPanelAnimation());
    }


    public void WinLoseLevelManager(bool isWin, int starsCount)
    {
        WinLoseLevelManager(true);
        //SaveDataManager(starsCount, Memory_Game_Manager.levelIndex);
        StartCoroutine(starsAnimation(starsCount));
    }

    void SoundsStats()
    {
        if (musicOn)
        {
            musicImg.sprite = musicBtnOnSprite;
        }
        else
        {
            musicImg.sprite = musicBtnOffSprite;
        }

        if (sfxOn)
        {
            sfxImg.sprite = sfxBtnOnSprite;

        }
        else
        {
            sfxImg.sprite = sfxBtnOffSprite;
        }

    }

    IEnumerator containerPanelAnimation()
    {
        Vector2 initScale = container.transform.localScale;
        Vector2 wantedScale = initScale * 2;
        float realTimeScaleY = initScale.y;

        while (realTimeScaleY < wantedScale.y)
        {
            realTimeScaleY += Time.deltaTime * 5;
            container.transform.localScale = new Vector3(realTimeScaleY, realTimeScaleY);
            yield return new WaitForEndOfFrame();
        }

        while (realTimeScaleY > (initScale.y))
        {
            realTimeScaleY -= Time.deltaTime * 5;
            container.transform.localScale = new Vector3(realTimeScaleY, realTimeScaleY);
            yield return new WaitForEndOfFrame();
        }
        isContainerScaled = true;
    }

    IEnumerator starsAnimation(int starsCount)
    {
        while (!isContainerScaled)
        {
            yield return null;
        }

        do
        {
            yield return new WaitForEndOfFrame();
            while (isStarScaled)
            {
                StartCoroutine(starAnimation(starsOwned[starsScaledCount]));
                yield return new WaitForEndOfFrame();
            }
        } while (starsScaledCount < starsCount - 1);

    }

    IEnumerator starAnimation(GameObject star)
    {
        isStarScaled = false;
        Vector2 initScale = star.transform.localScale;
        star.SetActive(true);
        star.transform.localScale = Vector2.zero;
        Vector2 wantedScale = initScale * 2;
        float realTimeScaleY = initScale.y;

        while (realTimeScaleY < wantedScale.y)
        {
            realTimeScaleY += Time.deltaTime * 3;
            star.transform.localScale = new Vector3(realTimeScaleY, realTimeScaleY);
            yield return new WaitForEndOfFrame();
        }

        while (realTimeScaleY > (initScale.y))
        {
            realTimeScaleY -= Time.deltaTime * 3;
            star.transform.localScale = new Vector3(realTimeScaleY, realTimeScaleY);
            yield return new WaitForEndOfFrame();
        }
        isStarScaled = true;
        starsScaledCount++;
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().path);
    }

    public void NextLevel()
    {
        //Here we must adapt each code with the game
        //Game_110_Game_Manager.levelIndex++;
        RetryLevel();
    }

    public void MusicBtn()
    {
        if (musicOn)
        {
            musicOn = false;
            musicImg.sprite = musicBtnOffSprite;
        }
        else
        {
            musicOn = true;
            musicImg.sprite = musicBtnOnSprite;
        }
    }

    public void SfxBtn()
    {
        if (sfxOn)
        {
            sfxOn = false;
            sfxImg.sprite = sfxBtnOffSprite;
        }
        else
        {
            sfxOn = true;
            sfxImg.sprite = sfxBtnOnSprite;
        }
    }

    public void PauseBtn()
    {
        PausedPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void HowToPlayBtn()
    {
        HowToPlayPanel.SetActive(true);
    }

    public void ResumeBtn()
    {
        PausedPanel.SetActive(false);
        HowToPlayPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        //Here we must adapt each code with the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    void SaveDataManager(int starsOwned, byte levelIndex)
    {
        if (PlayerPrefs.HasKey(gameDataKey + levelIndex))
        {
            if (PlayerPrefs.GetInt(gameDataKey + levelIndex, 0) < starsOwned)
            {
                PlayerPrefs.SetInt(gameDataKey + levelIndex, starsOwned);
            }
        }
        else
        {
            PlayerPrefs.SetInt(gameDataKey + levelIndex, starsOwned);
        }

    }

    public void Set_Level_As_Finished()
    {
        PlayerPrefs.SetString(LEVEL_REACHED_KEY, PlayerPrefs.GetString(LEVEL_REACHED_KEY, "0") + "-" + levelMapGameName);
    }

}

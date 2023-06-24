using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class sceneMenu : MonoBehaviour
{
    Player player;
    public GameObject BtnContinueObj;

    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.GetInt("newGame") == 0)
        {
            BtnContinueObj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void BtnHunt()
    {
        SceneManager.LoadScene("sceneExploreWorld");
    }

    public void BtnContinue()
    {
        SceneManager.LoadScene("sceneBase");
    }

    public void BtnNewGame()
    {
        player = new Player();
        player.NewGame();

        SceneManager.LoadScene("sceneBase");
    }



}

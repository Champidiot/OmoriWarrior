using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private PlayerScript playerScript;

    [SerializeField] private GameObject PauseMenu;

    private void Update()
    {
        if(playerScript.HeroHp <= 0)
        {
            Time.timeScale = 0f;

            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }

        if (Input.GetKeyDown("escape"))
        {
            Time.timeScale = 0f;
            PauseMenu.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            if(Time.timeScale == 1)
            {
                Time.timeScale = 5;
            }
            else
            {
                Time.timeScale = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            EnemySpawnerManager.TimerJeu += 60;
        }


        if (EnemySpawnerManager.TimerJeu > 300)
        {
            SceneManager.LoadSceneAsync("Win", LoadSceneMode.Single);
        }
    }
}

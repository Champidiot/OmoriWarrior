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
    }
}

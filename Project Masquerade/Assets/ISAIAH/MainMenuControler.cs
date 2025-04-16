using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControler : MonoBehaviour
{
    public CanvasGroup OptionPanel;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Credits()
    {
        OptionPanel.alpha = 1;
        OptionPanel.blocksRaycasts = true;
    }
    public void Isaiah()
    {
        OptionPanel.alpha = 2;
        OptionPanel.blocksRaycasts = true;
    }
    public void Gabriel()
    {
        OptionPanel.alpha = 3;
        OptionPanel.blocksRaycasts = true;
    }
    public void Elias()
    {
        OptionPanel.alpha = 4;
        OptionPanel.blocksRaycasts = true;
    }
    public void Back()
    {
        OptionPanel.alpha = 0;
        OptionPanel.blocksRaycasts = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControler : MonoBehaviour
{
    public GameObject OptionPanel;
    public GameObject IsaiahPanel;
    public GameObject GabrielPanel;
    public GameObject EliasPanel;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Credits()
    {
        OptionPanel.gameObject.SetActive(true);
        IsaiahPanel.gameObject.SetActive(false);
        GabrielPanel.gameObject.SetActive(false);
        EliasPanel.gameObject.SetActive(false);
    }
    public void Isaiah()
    {
        OptionPanel.gameObject.SetActive(false);
        IsaiahPanel.gameObject.SetActive(true);
        GabrielPanel.gameObject.SetActive(false);
        EliasPanel.gameObject.SetActive(false);
    }
    public void Gabriel()
    {
        OptionPanel.gameObject.SetActive(false);
        IsaiahPanel.gameObject.SetActive(false);
        GabrielPanel.gameObject.SetActive(true);
        EliasPanel.gameObject.SetActive(false);
    }
    public void Elias()
    {
        OptionPanel.gameObject.SetActive(false);
        IsaiahPanel.gameObject.SetActive(false);
        GabrielPanel.gameObject.SetActive(false);
        EliasPanel.gameObject.SetActive(true);
    }
    public void Back()
    {
        OptionPanel.gameObject.SetActive(false);
        IsaiahPanel.gameObject.SetActive(false);
        GabrielPanel.gameObject.SetActive(false);
        EliasPanel.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

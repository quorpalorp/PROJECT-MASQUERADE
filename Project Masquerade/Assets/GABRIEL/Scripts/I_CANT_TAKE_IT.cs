using UnityEngine;
using UnityEngine.SceneManagement;

public class I_CANT_TAKE_IT : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void restart()
    {
        SceneManager.LoadScene("combat test 2 electric boogaloo");
    }
}

using UnityEngine;
using UnityEngine.UI;

public class healthui : MonoBehaviour
{
    public Image healthbar;
    public float totalHealth = 20;
    public float health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = totalHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.fillAmount = health / totalHealth;

        if (health <= 0)
        {
            Debug.Log("HAHHAHHAHHAH YOU DIED");
        }
    }
}

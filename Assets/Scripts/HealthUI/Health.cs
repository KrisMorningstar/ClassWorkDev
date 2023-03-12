using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Range(0f, 100)]
    public float health;

    private float healthNormalized;
    public Image healthBar;
    public Image healthSplat;



    // Start is called before the first frame update
    void Start()
    {
        EventManager.loseHealthEvent += ReduceHealth;

        float healthFlip = 1 - healthNormalized;

        healthSplat.color = new Color(healthSplat.color.r, healthSplat.color.g, healthSplat.color.b, healthFlip);
        healthNormalized = health / 100;
        healthBar.fillAmount = healthNormalized;

    }

    // Update is called once per frame
    void Update()
    {
        float healthFlip = 1 - healthNormalized;

        healthSplat.color = new Color(healthSplat.color.r, healthSplat.color.g, healthSplat.color.b, healthFlip);
        healthNormalized = health / 100;
        healthBar.fillAmount = healthNormalized;
    }

    public void ReduceHealth(float _damage)
    {
        if (health - _damage! > 0)
        {
            health -= _damage;
        }
        else
        {
            health = 0;
        }

    }
}
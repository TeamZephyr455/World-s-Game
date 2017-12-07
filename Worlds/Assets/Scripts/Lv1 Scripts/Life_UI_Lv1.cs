using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Life_UI_Lv1 : MonoBehaviour
{

    public Image currentHealthBar;
    public Text ratioText;

    public Text lifeCount;

    private int maxHitpoint;
    private float ratio;

    private void Start()
    {
        maxHitpoint = GetComponent<Health_Lv1>().startingHealth;
        UpdateLives(GetComponent<Player_Lv1>().lifes);
    }

    public void UpdateHealthBar(int currentHealth)
    {
        float ratio = (float)currentHealth / maxHitpoint;
        currentHealthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        ratioText.text = (ratio * 100).ToString() + '%';
    }

    public void UpdateMaxHealth(int maxHealth)
    {
        maxHitpoint = maxHealth;
    }

    public void UpdateLives(int lives)
    {
        lifeCount.text = "x " + lives;
    }
}

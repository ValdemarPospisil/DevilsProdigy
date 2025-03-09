
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Healthbar : MonoBehaviour
{

	public Slider slider;
	[SerializeField] private TextMeshProUGUI maxHealthText;
	[SerializeField] private TextMeshProUGUI currentHealthText;

	public Gradient gradient;
	public Image fill;

	private static Healthbar _instance;

    public static Healthbar instance
    {
        get
        {
        return _instance;
        }
    }

	private void Awake() {
        if (_instance != null && _instance != this)
    {
      Destroy(this.gameObject);
    }
    else
    {
      _instance = this;
    }

    }

	public void SetMaxHealth(float health)
	{
		slider.maxValue = health;
		
		maxHealthText.text = "/" + health.ToString();
	}


	public void SetFreshHealth(float health)
	{
		slider.maxValue = health;
		slider.value = health;
		maxHealthText.text = "/" + health.ToString();
		currentHealthText.text = health.ToString();
		fill.color = gradient.Evaluate(1f);
	}

    public void SetCurrentHealth(float health)
	{
		slider.value = health;
		currentHealthText.text = health.ToString();
		fill.color = gradient.Evaluate(slider.normalizedValue);
	}

}
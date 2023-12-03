using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    private Health vida;
    private Slider slider;
    private void Awake()
    {
        vida = Player.GetComponent<Health>();
        slider = GetComponent<Slider>();
    }

    private void Update()
    {
        slider.value = vida.currentHealth;
        Debug.Log(vida.currentHealth);
    }
}

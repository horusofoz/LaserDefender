using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthDisplay : MonoBehaviour {

    Slider healthSlider;
    GameSession gameSession;

    void Awake()
    {
        healthSlider = GameObject.Find("Health Slider").GetComponent<Slider>();
        gameSession = FindObjectOfType<GameSession>();
    }

    void Update()
    {
        healthSlider.value = gameSession.GetHealth();
    }
}

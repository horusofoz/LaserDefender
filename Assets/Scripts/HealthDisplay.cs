using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthDisplay : MonoBehaviour {

    Slider healthSlider;
    Player player;

    // Use this for initialization
    void Start()
    {
        healthSlider = GameObject.Find("Health Slider").GetComponent<Slider>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = player.GetHealth();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldDisplay : MonoBehaviour {

    Slider shieldSlider01;
    Slider shieldSlider02;
    Slider shieldSlider03;
    GameSession gameSession;

    void Start()
    {
        shieldSlider01 = GameObject.Find("Shield Slider 01").GetComponent<Slider>();
        shieldSlider02 = GameObject.Find("Shield Slider 02").GetComponent<Slider>();
        shieldSlider03 = GameObject.Find("Shield Slider 03").GetComponent<Slider>();
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        shieldSlider01.value = gameSession.GetShieldHealth();
        shieldSlider02.value = gameSession.GetShieldHealth();
        shieldSlider03.value = gameSession.GetShieldHealth();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldDisplay : MonoBehaviour {

    Slider shieldSlider01;
    Slider shieldSlider02;
    Slider shieldSlider03;
    GameSession gameSession;

    [SerializeField] GameObject shield01;
    [SerializeField] GameObject shield02;
    [SerializeField] GameObject shield03;

    void Start()
    {
        shieldSlider01 = GameObject.Find("Shield Slider 01").GetComponent<Slider>();
        shieldSlider02 = GameObject.Find("Shield Slider 02").GetComponent<Slider>();
        shieldSlider03 = GameObject.Find("Shield Slider 03").GetComponent<Slider>();
        gameSession = FindObjectOfType<GameSession>();
    }

    void Update()
    {
        if(gameSession.GetHealth() > 0)
        {
            DisplayShieldSlider();
            DisplayShieldSprite();
        }
    }

    private void DisplayShieldSprite()
    {
        shield03.SetActive(gameSession.GetShieldHealth() > gameSession.shieldLayer02);
        shield02.SetActive(gameSession.GetShieldHealth() > gameSession.shieldLayer01);
        shield01.SetActive(gameSession.GetShieldHealth() > 0);
    }

    private void DisplayShieldSlider()
    {
        shieldSlider01.value = gameSession.GetShieldHealth();
        shieldSlider02.value = gameSession.GetShieldHealth();
        shieldSlider03.value = gameSession.GetShieldHealth();
    }
}

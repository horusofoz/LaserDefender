using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldDisplay : MonoBehaviour {

    [SerializeField] Slider shieldSlider01;
    [SerializeField] Slider shieldSlider02;
    [SerializeField] Slider shieldSlider03;
    [SerializeField] GameSession gameSession;

    [SerializeField] GameObject shield01;
    [SerializeField] GameObject shield02;
    [SerializeField] GameObject shield03;

    void Update()
    {
        if(GameSession.Instance.GetHealth() > 0)
        {
            DisplayShieldSlider();
            DisplayShieldSprite();
        }
    }

    private void DisplayShieldSprite()
    {
        shield03.SetActive(GameSession.Instance.GetShieldHealth() > GameSession.Instance.shieldLayer02);
        shield02.SetActive(GameSession.Instance.GetShieldHealth() > GameSession.Instance.shieldLayer01);
        shield01.SetActive(GameSession.Instance.GetShieldHealth() > 0);
    }

    private void DisplayShieldSlider()
    {
        shieldSlider01.value = GameSession.Instance.GetShieldHealth();
        shieldSlider02.value = GameSession.Instance.GetShieldHealth();
        shieldSlider03.value = GameSession.Instance.GetShieldHealth();
    }
}

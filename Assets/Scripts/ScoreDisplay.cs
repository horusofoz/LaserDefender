using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreDisplay : MonoBehaviour {

    TextMeshProUGUI scoreText;
    [SerializeField] GameSession gameSession;

	// Use this for initialization
	void Start () 
	{
        scoreText = GetComponent<TextMeshProUGUI>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        scoreText.text = GameSession.Instance.GetScore().ToString();
	}
}

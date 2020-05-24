using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NumberWizard : MonoBehaviour {

    [SerializeField] int max;
    [SerializeField] int min;
    [SerializeField] TextMeshProUGUI guessText;

    int guess;

    // Use this for initialization
    void Start ()
    {
        StartGame();
	}
	
    void StartGame()
    {
        NextGuess();
        UpdateGuessText(guess.ToString());
        max = max + 1;
    }

    public void OnPressHigher() {
        min = guess;
        NextGuess();
    }

    public void OnPressLower() {
        max = guess;
        NextGuess();
    }
    void NextGuess()
    {
        guess = (max + min) / 2;
    }

    public void handleHigherButtonClick() {
        min = guess;
        NextGuess();
        UpdateGuessText(guess.ToString());
    }

    public void handleLowerButtonClick() {
        max = guess;
        NextGuess();
        UpdateGuessText(guess.ToString());
    }

    void UpdateGuessText(string text) {
        guessText.text = text;
    }
}

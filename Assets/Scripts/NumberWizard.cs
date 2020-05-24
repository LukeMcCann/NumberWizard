using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NumberWizard : MonoBehaviour {

    [SerializeField] int max;
    [SerializeField] int min;
    [SerializeField] TextMeshProUGUI guessText;

    List<int> usedValues = new List<int>();

    int guess;

    // Use this for initialization
    void Start ()
    {
        StartGame();
	}
	
    void StartGame()
    {
        NextGuess();
        max = max + 1;
    }

    void NextGuess()
    {
        // guess = (max + min) / 2;
        guess = Random.Range(min, max);
        if(usedValues.Contains(guess)) {
            NextGuess();
        }
        UpdateGuessText(guess.ToString());
        usedValues.Add(guess);
    }

    public void HandleHigherButtonClick() {
        min = guess;
        NextGuess();
    }

    public void HandleLowerButtonClick() {
        max = guess;
        NextGuess();
    }

    void UpdateGuessText(string text) {
        guessText.text = text;
    }
}

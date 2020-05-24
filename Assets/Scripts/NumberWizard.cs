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
    }

    void NextGuess()
    {
        // guess = (max + min) / 2;
        guess = Random.Range(min, max+1);
        if(usedValues.Contains(guess)) {
            NextGuess();
        }
        UpdateGuessText(guess.ToString());
        usedValues.Add(guess);
    }

    public void HandleHigherButtonClick() {
        min = guess+1;
        NextGuess();
    }

    public void HandleLowerButtonClick() {
        max = guess-1;
        NextGuess();
    }

    void UpdateGuessText(string text) {
        guessText.text = text;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System;
using UnityEngine;

namespace NumberWizardUI.Assets.Scripts {
    public class NumberWizard : MonoBehaviour
    {
        [SerializeField] int lowestNumber;
        [SerializeField] int highestNumber;

        int currentGuess;
        System.Random random = new System.Random();

        // Start is called before the first frame update
        void Start()
        {
            StartGame();
        }

        // Update is called once per frame
        void Update()
        {
            ListenForInput();
        }

        void StartGame() {
            PrintBanner();
            ThinkOfANumber();
            GuessUserNumber(NextGuess(lowestNumber, highestNumber));
        }

        private void ListenForInput() {
            if(Input.GetKeyDown(KeyCode.UpArrow)) {
                lowestNumber = currentGuess;
                var nextGuess = NextGuess(lowestNumber, highestNumber);
                if(currentGuess == nextGuess && currentGuess < highestNumber) {
                    nextGuess = currentGuess + highestNumber - currentGuess;
                }
                GuessUserNumber(nextGuess);
            } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
                highestNumber = currentGuess;
                var nextGuess = NextGuess(lowestNumber, highestNumber);
                if(currentGuess == nextGuess && currentGuess > lowestNumber) {
                    nextGuess = currentGuess + highestNumber - currentGuess;
                }
                GuessUserNumber(nextGuess);
            } else if(Input.GetKeyDown(KeyCode.Return)) {
                Debug.Log(string.Format("I knew your number was {0} all along.", currentGuess.ToString()));
                StartGame();
            } else {
                // Do nothing
            }
        }

        private void PrintBanner() {
            Debug.Log("Welcome to NumberWizard!");
        }

        private void ThinkOfANumber() {
            string template = "Think of a number between: {0} and {1}";
            string[] data = {lowestNumber.ToString(), highestNumber.ToString()};
            Debug.Log(string.Format(template, data));
        }

        private int NextGuess(int min, int max) {
            if(min > max || max < min) {
                var temp = min;
                min = max;
                max = temp;
            }
            currentGuess = random.Next(min, max);
            return currentGuess;
        }

        private void GuessUserNumber(int number) {
            string guess = number.ToString();
            Debug.Log(string.Format("Is your number greater or lower than {0}?", guess));
            Debug.Log("Press ↓ if lower, ↑ if higher, Enter if equal");
        }
    }
}


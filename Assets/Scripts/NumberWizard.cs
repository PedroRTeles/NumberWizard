using UnityEngine;
using TMPro;

public class NumberWizard : MonoBehaviour
{
    [SerializeField] int max;
    [SerializeField] int min;
    [SerializeField] TextMeshProUGUI guessText;
    [SerializeField] TextMeshProUGUI attemptsText;
    [SerializeField] int attempts;
    int guess;

    // Start is called before the first frame update
    void Start()
    {
        SetAttemptText();
        NextGuess();
    }

    void SetAttemptText()
    {
        attemptsText.text = "I have " + attempts.ToString() + " attempts";
    }

    public void OnHeigherPressed()
    {
        min = guess + 1;
        attempts -= 1;
        NextGuess();
        SetAttemptText();
    }

    public void OnLowerPressed()
    {
        max = guess - 1;
        attempts -= 1;
        NextGuess();
        SetAttemptText();
    }

    void NextGuess()
    {
        if (WizardHasMoreAttempts())
        {
            guess = Random.Range(min, max);
            guessText.text = guess.ToString();
        }
        else
        {
            gameObject.AddComponent<SceneLoader>().LoadPlayerWinScene();
        }
    }

    bool WizardHasMoreAttempts()
    {
        return attempts > 0;
    }
}


using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerInputUI : MonoBehaviour
{
    [SerializeField] private FlashAnzanManager gameManager;
    [SerializeField] private TMP_InputField answerInput;
    [SerializeField] private Button submitButton;

    private void Start()
    {
        answerInput.gameObject.SetActive(false);
        submitButton.gameObject.SetActive(false);

        submitButton.onClick.AddListener(OnSubmit);
        gameManager.OnQuestionFinished += ShowInput;
    }

    private void OnDestroy()
    {
        if (gameManager != null)
        {
            gameManager.OnQuestionFinished -= ShowInput;
        }

        if (submitButton != null)
        {
            submitButton.onClick.RemoveListener(OnSubmit);
        }
    }

    private void ShowInput()
    {
        answerInput.text = "";
        answerInput.gameObject.SetActive(true);
        submitButton.gameObject.SetActive(true);
        answerInput.ActivateInputField();
    }

    private void OnSubmit()
    {
        if (!int.TryParse(answerInput.text, out int answer))
        {
            Debug.Log("”š‚ğ“ü—Í‚µ‚Ä‚­‚¾‚³‚¢");
            return;
        }

        gameManager.SubmitAnswer(answer);

        Debug.Log("³‰ğ: " + gameManager.GetCorrectAnswer());
        Debug.Log("“ü—Í‚µ‚½‰ñ“š: " + gameManager.GetPlayerAnswer());

        answerInput.gameObject.SetActive(false);
        submitButton.gameObject.SetActive(false);

    }
}

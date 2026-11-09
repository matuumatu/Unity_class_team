
using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class FlashAnzanManager : MonoBehaviour
{
    [Header("出題設定")]
    [SerializeField] private int questionCount = 5;
    [SerializeField] private int minNumber = 1;
    [SerializeField] private int maxNumber = 9;

    [Header("表示設定")]
    [SerializeField] private float displayTime = 1.0f;
    [SerializeField] private float intervalTime = 0.2f;

    [Header("UI")]
    [SerializeField] private TMP_Text numberText;

    [Header("カウントダウン設定")]
    [SerializeField] private TMP_Text countdownText;
    [SerializeField] private float countdownInterval = 1.0f;

    private int correctAnswer;
    private int playerAnswer;
    private bool hasAnswered;

    // リザルト担当が使うGetter
    public int GetCorrectAnswer() => correctAnswer;
    public int GetPlayerAnswer() => playerAnswer;
    public bool HasAnswered() => hasAnswered;

    // 他のクラスへの通知
    public event Action OnQuestionFinished;
    public event Action OnAnswerSubmitted;

    private void Start()
    {
        countdownText.gameObject.SetActive(false);
        StartCoroutine(Countdown());
    }

    public void StartQuestion()
    {
        if (questionCount <= 0 ||
            minNumber > maxNumber ||
            displayTime <= 0f ||
            intervalTime < 0f)
        {
            Debug.LogError("出題設定が正しくありません");
            return;
        }

        StopAllCoroutines();

        correctAnswer = 0;
        playerAnswer = 0;
        hasAnswered = false;

        numberText.gameObject.SetActive(false);

        StartCoroutine(ShowNumbers());
    }

    private IEnumerator ShowNumbers()
    {
        for (int i = 0; i < questionCount; i++)
        {
            int number =
                UnityEngine.Random.Range(minNumber, maxNumber + 1);

            correctAnswer += number;

            numberText.text = number.ToString();
            numberText.gameObject.SetActive(true);

            yield return new WaitForSeconds(displayTime);

            numberText.gameObject.SetActive(false);

            if (i < questionCount - 1)
            {
                yield return new WaitForSeconds(intervalTime);
            }
        }

        OnQuestionFinished?.Invoke();
    }

    // プレイヤーの回答を保存
    public void SubmitAnswer(int answer)
    {
        if (hasAnswered)
        {
            return;
        }

        playerAnswer = answer;
        hasAnswered = true;

        GameResultData.CorrectAnswer = correctAnswer;
        GameResultData.PlayerAnswer=playerAnswer;

        OnAnswerSubmitted?.Invoke();
    }


    private IEnumerator Countdown()
    {
        // 数字表示はカウントダウン中に隠す
        numberText.gameObject.SetActive(false);
        countdownText.gameObject.SetActive(true);

        // 3 → 2 → 1
        for (int i = 3; i >= 1; i--)
        {
            countdownText.text = i.ToString();

            yield return new WaitForSeconds(countdownInterval);
        }

        // START! を表示
        countdownText.text = "START!";

        yield return new WaitForSeconds(countdownInterval);

        // カウントダウンを非表示
        countdownText.gameObject.SetActive(false);

        // 数字の出題開始
        yield return StartCoroutine(ShowNumbers());
    }

}


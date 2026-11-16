using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    public TMP_Text answerText;
    public TMP_Text playerText;
    public TMP_Text judgeText;

    [SerializeField] private int correctAnswer = 0;
    [SerializeField] private int playerAnswer = 0;    

    void Start()
    {
        correctAnswer = GameResultData.CorrectAnswer;
        playerAnswer = GameResultData.PlayerAnswer;

        // 正解の値を表示
        answerText.text = "正解の値：" + correctAnswer;

        // プレイヤーの入力値を表示
        playerText.text = "入力した値：" + playerAnswer;

        // 正解・不正解を判定
        if (correctAnswer == playerAnswer)
        {
            judgeText.text = "正解！";
            judgeText.color = Color.greenYellow;
            Debug.Log("正解です！");
        }
        else
        {
            judgeText.text = "不正解！";
            judgeText.color = Color.red;
            Debug.Log("不正解です！");
        }
    }

    // リトライ
    public void Retry()
    {
        Debug.Log("リトライボタンが押されました！");
        //SceneManager.LoadScene();
    }

    // タイトルへ戻る
    public void GoToTitle()
    {
        Debug.Log("タイトルボタンが押されました！");
        //SceneManager.LoadScene();
    }
}

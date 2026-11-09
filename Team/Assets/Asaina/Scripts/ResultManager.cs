
using UnityEngine;
using TMPro;

public class ResultManager : MonoBehaviour
{
    public TMP_Text answerText;
    public TMP_Text playerText;
    public TMP_Text judgeText;

    void Start()
    {
        // 仮のテストデータ
        int correctAnswer = 125;
        int playerAnswer = 125;

        // 正解の値を表示
        answerText.text = "正解の値：" + correctAnswer;

        // プレイヤーの入力値を表示
        playerText.text = "入力した値：" + playerAnswer;

        // 正解・不正解を判定
        if (correctAnswer == playerAnswer)
        {
            judgeText.text = "正解！";
            Debug.Log("正解です！");
        }
        else
        {
            judgeText.text = "不正解！";
            Debug.Log("不正解です！");
        }
    }

    // リトライ
    public void Retry()
    {
        Debug.Log("リトライボタンが押されました！");
    }

    // タイトルへ戻る
    public void GoToTitle()
    {
        Debug.Log("タイトルボタンが押されました！");
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StartButton : MonoBehaviour
{
    [SerializeField]
    private Button button = null;
    private RectTransform rectTransform;

    private bool is_init = false;

    private const float INIT_POSITION_Y     = -600.0f; // 初期位置
    private const float MOVE_END_POSITION_Y = -220.0f; // 最終位置

    private float timer = 0.0f;
    private float move_duration = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        if (rectTransform == null)
            return;

        is_init = true;

        button.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        if (!is_init)
        {
            Debug.Log("ボタンのトランスフォーム取得してない");
            return;
        }

        //var position = rectTransform.position;
        //position.x = 0.0f;
        //position.y = Mathf.Lerp(INIT_POSITION_Y, MOVE_END_POSITION_Y, timer / move_duration);
        //rectTransform.position = position;

        //timer += Time.deltaTime;
        //timer = Mathf.Clamp(timer, 0, move_duration);

        ////Debug.Log(timer);
        //Debug.Log(rectTransform.position);
    }

    void OnClick()
    {
        SceneManager.LoadScene("Game");
    }
}

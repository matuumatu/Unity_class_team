using GoogleMobileAds.Api;
using UnityEngine;
namespace Day9
{
    /* 
     * EventSystem が無いと広告が閉じないです。
     */
    
    public class AdManager : MonoBehaviour
    {
        [SerializeField] private RewardedAdService rewardedAd;

        public bool canShowAd = false;

        // 初期化
        private void Init()
        {
            this.rewardedAd.Init();
        }

        // 初期化
        private void Start()
        {
            // Google Admob の初期化
            // 完了時のコールバックに Init() を呼ぶ
            MobileAds.Initialize((InitializationStatus initStatus) =>
            {
                Init();
            });
        }

        private void Update()
        {
            if (canShowAd)
            {
                Debug.Log("広告表示");
                rewardedAd.ShowRewardAd();
                canShowAd = false;
            }
        }
    }
}
using GoogleMobileAds.Api;
using UnityEngine;

namespace Day9
{
    /// <summary>
    /// リワード広告
    /// </summary>
    public class RewardedAdService : MonoBehaviour
    {
        // 変数を宣言済
        private RewardedAd rewardedAd;

        // テストID定数を宣言
        private const string rewardedAdUnitId = "ca-app-pub-3940256099942544/5224354917";

        // 初期化
        public void Init()
        {
            // 広告のロード
            MobileAds.Initialize((InitializationStatus initStatus) =>
            {
                this.LoadRewardAd();
            });
        }

        // 課題はボタンから呼ばれるようにしている。
        public void ShowRewardAd()
        {
            if (this.rewardedAd == null) return;        // 初期化してない
            if (!this.rewardedAd.CanShowAd()) return;   // 表示出来る状況じゃない

            // 広告の表示
            // Reward クラスは本番広告を作る時に設定出来る。
            // テスト広告は Type：Reward Amount：10 を取得出来る
            // ロードした広告を見たので、リワード広告の再ロードも忘れずに
            this.rewardedAd.Show((Reward reward) =>
            {
                Debug.Log($"[Type：{reward.Type}] [Amount：{reward.Amount}]");
                this.LoadRewardAd();
            });
        }

        // リワード広告のロード
        private void LoadRewardAd()
        {
            // 既存のリワード広告が残っていれば破棄
            this.rewardedAd?.Destroy();

            // 広告リクエスト
            var adRequest = new AdRequest();

            // 広告をリクエストして、貰った広告をロード
            RewardedAd.Load(rewardedAdUnitId, adRequest, (RewardedAd ad, LoadAdError error) =>
            {
                // ロード失敗 
                if (error != null)
                {
                    return;
                }

                // ロード成功 
                this.rewardedAd = ad;
            });
        }

        // 破棄時
        private void OnDestroy()
        {
            // 残ってる広告を破棄
            this.rewardedAd?.Destroy();
        }
    }
}

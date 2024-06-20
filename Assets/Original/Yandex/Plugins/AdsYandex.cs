using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class AdsYandex : SingletonBase<AdsYandex>
{
    [DllImport("__Internal")]
    private static extern void ShowFullscreen();

    [DllImport("__Internal")]
    private static extern void ShowRewarded();

    public void ShowFullScreenAds()
    {
        ShowFullscreen();
    }

    public void ShowReawardAds()
    {
        ShowRewarded();
    }

    public void AddLives()
    {
        PlayerController.Instance.AddPlayerDrone(3);
        // выдаём бонусы пользователю за просмотр рекламы
    }

    public void CloseReward()
    {
        Time.timeScale = 1;
        AudioController.Instance.AudioSettings.LoadAudioSettings();
    }
    public void OpenReward()
    {
        Time.timeScale = 0;
        AudioController.Instance.AudioSettings.SoundOff();
    }

}

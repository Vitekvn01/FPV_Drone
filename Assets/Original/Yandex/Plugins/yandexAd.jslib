mergeInto(LibraryManager.library, {

  ShowFullscreen: function () {
      ysdk.adv.showFullscreenAdv({
      callbacks: {
          onOpen: function(wasShown) {
            console.log('Реклама Fullscreen открылась.');
            myGameInstance.SendMessage("StartAds", "OpenReward");
          },
          onClose: function(wasShown) {
            console.log("Реклама Fullscreen закрылась.");
            myGameInstance.SendMessage("StartAds", "CloseReward");
          },
          onError: function(error) {
            console.log("Ошибка по рекламе Fullscreen.");
            myGameInstance.SendMessage("StartAds", "CloseReward");
          }
      }
      })
  },

  ShowRewarded: function () {
      ysdk.adv.showRewardedVideo({
      callbacks: {
          onOpen: () => {
            console.log('Реклама Rewarded открылась.');
            myGameInstance.SendMessage("StartAds", "OpenReward");
          },
          onRewarded: () => {
            console.log('Реклама Rewarded просмотрена, и производим награду игроку за просмотр.');
            myGameInstance.SendMessage("StartAds", "AddLives");
          },
          onClose: () => {
            console.log('Реклама Rewarded закрылась.');
            myGameInstance.SendMessage("StartAds", "CloseReward");
          }, 
          onError: (e) => {
            console.log('Ошибка по рекламе Rewarded:', e);
            myGameInstance.SendMessage("StartAds", "CloseReward");
          }
      }
  })
  },

});
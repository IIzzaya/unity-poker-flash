
# unity-poker-flash
扑克牌铺满又散去的unity过场动画
参考游戏《Fortune-499》过场动画元素，模拟仿制的。

![PokerFlash](https://github.com/IIzzaya/unity-poker-flash/blob/master/Static/PokerFlash.gif)

## FlashController 可调参数

* play 播放动画
* pause 暂停动画
* replay 重新播放动画
* globalDelay 播放开始到卡牌开始移动之间的时间延迟
* globalTimeCost 卡牌移动到/离开预定位置所需时间
* globalTimeStay 卡牌在预定位置停留时间
* fromDirection 卡牌飞入的角度（暂不支持热更新）
* toDirection 卡牌飞出的角度（暂不支持热更新）
* screenBorder 防止卡牌在等候区时候被屏幕捕捉预留的边界（暂不支持热更新）

## Card 可调参数

* relativeDelay 相对全局设定飞入延迟差
* relativeTimeCost 相对全局飞入所需时间差
* relativeTimeStay 相对全局滞留时间差

## 时间轴（对单个卡牌）

* if (play == true)
* +(globalDelay + relativeDelay)s
* +(globalTimeCost + relativeTimeCost)s
* +(globalTimeStay + relativeTimeStay)s
* +(globalTimeCost + relativeTimeCost)s
* play = false

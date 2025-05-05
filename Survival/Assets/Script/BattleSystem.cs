using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//战斗系统类
public enum BattleState{ GAMESTART, PLAYERTURN, ENEMYTURN, WON, LOST }
public class BattleSystem : MonoBehaviour
{
    //战斗状态变量
    //枚举类型，表示战斗的状态
    public BattleState state;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    public TextMeshProUGUI dialogText;

    Unit playerUnit;
    Unit enemyUnit;

    public GameObject buttons;

    public BattleHud playerHud;
    public BattleHud enemyHud;

    void Start()
    {
        //在游戏开始时调用SetupBattle方法
        //设置战斗状态为GAMESTART
        state = BattleState.GAMESTART;
        SetupBattle();
    }

    //设置战斗
    //实例化玩家和敌人预制体在战斗站点上
    //在游戏开始时调用
    void SetupBattle()
    {
        buttons.SetActive(false);
        //实例化玩家和敌人预制体在战斗站点上
        GameObject playerGameObject = Instantiate(playerPrefab, playerBattleStation);
        //获取玩家的信息脚本
        playerUnit = playerGameObject.GetComponent<Unit>();
        GameObject enemyGameObject = Instantiate(enemyPrefab, enemyBattleStation);
        //获取敌人的信息脚本
        enemyUnit = enemyGameObject.GetComponent<Unit>();
        dialogText.text = enemyUnit.unitName + " Rua! ";

        //设置玩家和敌人的血条和文本
        //调用BattleHud类中的SetHud方法，传入Unit对象，先公开unit各个参数数值的代码，然后再创建一个battlehud的脚本，设置各个参数的值等于unit脚本里的参数，然后再公开battlehud的参数带入进去
        playerHud.SetHud(playerUnit);
        enemyHud.SetHud(enemyUnit);

        StartCoroutine(ShowButtonsDelay());
    }

    //延迟两秒显示按钮并隐藏dialogText
    IEnumerator ShowButtonsDelay()
    {
        yield return new WaitForSeconds(2f);
        buttons.SetActive(true);
        dialogText.gameObject.SetActive(false);
    }

}

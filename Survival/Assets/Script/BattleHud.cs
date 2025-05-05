using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    //公开文本和血条，让别的脚本可以调用
    public TextMeshProUGUI nameText, levelText, healthText;
    public Slider healthSlider;

    //传入一个Unit对象，设置血条和文本
    public void SetHud(Unit unit)
    {
        nameText.text = unit.unitName;
        levelText.text = "Lv." + unit.unitLevel;
        healthSlider.maxValue = unit.unitMaxHealth;
        healthSlider.value = unit.unitCurrentHealth;
        healthText.text = unit.unitCurrentHealth + "/" + unit.unitMaxHealth;
    }
    public void SetHealth(int health)
    {
        healthSlider.value = health;
    }
}

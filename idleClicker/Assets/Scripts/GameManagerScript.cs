﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;
    public Text moneyCurrentDisplay;
    public Text levelOnePrice, levelTwoPrice, levelThreePrice, levelFourPrice, levelFivePrice, clickLevelPrice;
    public Text levelOneAmount, levelTwoAmount, levelThreeAmount, levelFourAmount, levelFiveAmount, clickLevelAmount;
    public GameObject levelOnePrefab;
    public float moneyCurrent;
    public int level1Current, level2Current, level3Current, level4Current, level5Current;
    public float upgrade1Price = 50;
    public float upgrade2Price = 100;
    public float upgrade3Price = 150;
    public float upgrade4Price = 200;
    public float upgrade5Price = 250;
    public float clickMultiplier = 0;
    public float clickUpgrade1Price = 200;
    // Use this for initialization
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        moneyCurrentDisplay.text = "Cowoncy: " + (int)moneyCurrent;
        levelOnePrice.text = "Level One Price: " + upgrade1Price;
        levelOneAmount.text = "" + level1Current;
        levelTwoPrice.text = "Level Two Price " + upgrade2Price;
        levelTwoAmount.text = "" + level2Current;
        levelThreePrice.text = "Level Three Price " + upgrade3Price;
        levelThreeAmount.text = "" + level3Current;
        levelFourPrice.text = "Level Four Price " + upgrade4Price;
        levelFourAmount.text = "" + level4Current;
        levelFivePrice.text = "Level Five Price " + upgrade5Price;
        levelFiveAmount.text = "" + level5Current;

        clickLevelPrice.text = "Click Level Price: " + clickUpgrade1Price;
        clickLevelAmount.text = "" + clickLevelAmount;

        moneyCurrent += 0.0005f * level1Current;
        moneyCurrent += 0.0045f * level2Current;
        moneyCurrent += 0.01f * level3Current;
        moneyCurrent += 0.018f * level4Current;
        moneyCurrent += 0.035f * level5Current;
    }

    public void GainCurrency()
    {
        moneyCurrent += 1 + clickMultiplier;
    }

    public void GainLevelOne()
    {
        if (moneyCurrent >= upgrade1Price)
        {
            moneyCurrent -= upgrade1Price;
            level1Current += 1;
            upgrade1Price *= 1.15f;

            Instantiate(levelOnePrefab, new Vector3(Random.Range(-7, 7), Random.Range(-5, 5), 0), Quaternion.identity);
        }
    }
    public void GainLevelTwo()
    {
        if(moneyCurrent >= upgrade2Price)
        {
            moneyCurrent -= upgrade2Price;
            level2Current++;
            upgrade2Price *= 1.4f;
        }
    }
    public void GainLevelThree()
    {
        if (moneyCurrent >= upgrade3Price)
        {
            moneyCurrent -= upgrade3Price;
            level3Current++;
            upgrade3Price *= 1.60f;
        }
    }
    public void GainLevelFour()
    {
        if (moneyCurrent >= upgrade4Price)
        {
            moneyCurrent -= upgrade4Price;
            level4Current++;
            upgrade4Price += 1.80f;
        }
    }
    public void GainLevelFive()
    {
        if (moneyCurrent >= upgrade5Price)
        {
            moneyCurrent -= upgrade5Price;
            level5Current++;
            upgrade5Price += 2;
        }
    }

    public void GainClickLevel()
    {
        if(moneyCurrent >= clickUpgrade1Price)
        {
            moneyCurrent -= clickUpgrade1Price;
            clickUpgrade1Price *= 1.5f;
            clickMultiplier++;
        }
    }

}


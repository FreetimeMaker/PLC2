using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{
    public TMP_Text scoreText;
    public float currentScore;
    public float hitPower;
    public float scoreIncreasedPerSecond;
    public float x;
    public float CurrentButton;

    public GameObject C;
    public GameObject CS;
    public GameObject CPP;
    public GameObject CSS;
    public GameObject GO;
    public GameObject HTML;
    public GameObject Java;
    public GameObject JavaScript;
    public GameObject Kotlin;
    public GameObject Lua;
    public GameObject PHP;
    public GameObject Python;
    public GameObject React;
    public GameObject SQL;
    public GameObject Swift;
    public GameObject TypeScript;
    public GameObject Flutter;
    public GameObject Dart;

    public int shop1price;
    public TMP_Text shop1text;
    public TMP_Text shop1bt;

    public int shop2price;
    public TMP_Text shop2text;
    public TMP_Text shop2bt;

    public int shop3price;
    public TMP_Text shop3text;
    public TMP_Text shop3bt;

    public int shop4price;
    public TMP_Text shop4text;
    public TMP_Text shop4bt;

    public int shop5price;
    public TMP_Text shop5text;
    public TMP_Text shop5bt;

    public int shop6price;
    public TMP_Text shop6text;
    public TMP_Text shop6bt;

    void Start()
    {
        currentScore = 0;
        hitPower = 1;
        scoreIncreasedPerSecond = 0;
        x = 0f;
        CurrentButton = 0;

        currentScore = PlayerPrefs.GetInt("currentScore", 0);
        CurrentButton = PlayerPrefs.GetInt("CurrentButton", 0);
        hitPower = PlayerPrefs.GetInt("hitPower", 1);
        if (hitPower < 1)
        {
            hitPower = 1;
            PlayerPrefs.SetInt("hitPower", 1); // korrigierten Wert zurückspeichern
        }
        scoreIncreasedPerSecond = PlayerPrefs.GetInt("scoreIncreasedPerSecond", 0);
        x = PlayerPrefs.GetInt("x", 0);
        shop1price = PlayerPrefs.GetInt("shop1price", 25);
        shop2price = PlayerPrefs.GetInt("shop2price", 100);
        shop3price = PlayerPrefs.GetInt("shop3price", 400);
        shop4price = PlayerPrefs.GetInt("shop4price", 400);
        shop5price = PlayerPrefs.GetInt("shop5price", 800);
        shop6price = PlayerPrefs.GetInt("shop6price", 1600);
    }

    void Update()
    {
        scoreText.text = "PLC's: " + (int)currentScore;

        // Punkte pro Sekunde berechnen
        scoreIncreasedPerSecond = x * Time.deltaTime;
        currentScore += scoreIncreasedPerSecond;

        // Shoptexte updaten
        shop1text.text = "Autoclicker 1: " + shop1price + " PLC's";
        shop2text.text = "Autoclicker 2: " + shop2price + " PLC's";
        shop3text.text = "Next Button: " + shop3price + " PLC's";
        shop4text.text = "Autoclicker 3: " + shop4price + " PLC's";
        shop5text.text = "Upgrade PLC's per Click: " + shop5price + " PLC's";
        shop6text.text = "Upgrade PLC's per Second: " + shop6price + " PLC's";

        if (shop1price >= 75)
        {
            shop1text.text = "Autoclicker 1: Maxed out";
            shop1bt.text = "Maxed out";
        }

        if (shop2price >= 300)
        {
            shop2text.text = "Autoclicker 2: Maxed out";
            shop2bt.text = "Maxed out";
        }
            
        if (shop3price >= 13107200)
        {
            shop3text.text = "Next Button: Maxed out";
            shop3bt.text = "Maxed out";
        }

        if (shop4price >= 1200)
        {
            shop4text.text = "Autoclicker 3: Maxed out";
            shop4bt.text = "Maxed out";
        }

        if (shop5price >= 7200)
        {
            shop5text.text = "Upgrade PLC's per Click: Maxed out";
            shop5bt.text = "Maxed out";
        }

        if (shop6price >= 14400)
        {
            shop6text.text = "Upgrade PLC's per Second: Maxed out";
            shop6bt.text = "Maxed out";
        }

        PlayerPrefs.SetInt("currentScore", (int)currentScore);
        PlayerPrefs.SetInt("CurrentButton", (int)CurrentButton);
        PlayerPrefs.SetInt("hitPower", (int)hitPower);
        PlayerPrefs.SetInt("scoreIncreasedPerSecond", (int)scoreIncreasedPerSecond);
        PlayerPrefs.SetInt("x", (int)x);
        PlayerPrefs.SetInt("shop1price", (int)shop1price);
        PlayerPrefs.SetInt("shop2price", (int)shop2price);
        PlayerPrefs.SetInt("shop3price", (int)shop3price);
        PlayerPrefs.SetInt("shop4price", (int)shop4price);
        PlayerPrefs.SetInt("shop5price", (int)shop5price);
        PlayerPrefs.SetInt("shop6price", (int)shop6price);
    }

    public void Hit()
    {
        currentScore += hitPower;
    }

    public void Shop1()
    {
        if (shop1price <= 75)
        {
            if (currentScore >= shop1price)
            {
                currentScore -= shop1price;
                x += 1;
                shop1price += 25;
            }    
        }
    }

    public void Shop2()
    {
        if (shop2price <= 300)
        {
            if (currentScore >= shop2price)
            {
                currentScore -= shop2price;
                x += 2;
                shop2price += 100;
            }
        }
    }

    public void Shop3()
    {
        if (shop3price <= 26214400)
        {
            if (currentScore >= shop3price)
            {
                currentScore -= shop3price;
                shop3price *= 2;
                CurrentButton += 1;
                hitPower *= 2;
                x *= 2;
            }
        }
    }

    public void Shop4()
    {
        if (shop4price <= 1200)
        {
            if (currentScore >= shop4price)
            {
                currentScore -= shop4price;
                x += 4;
                shop4price += 400;
            }
        }
    }

    public void Shop5()
    {
        if (shop5price <= 21600)
        {
            if (currentScore >= shop5price)
            {
                currentScore -= shop5price;
                hitPower *= 2;
                shop5price *= 3;
            }
        }
    }

    public void Shop6()
    {
        if (shop6price <= 43200)
        {
            if (currentScore >= shop6price)
            {
                CurrentButton -= shop6price;
                x *= 2;
                shop6price *= 3;
            }
        }
    }

    public void CB()
    {
        if (CurrentButton == 1)
        {
            C.SetActive(false);
            CS.SetActive(true);
            CPP.SetActive(false);
            CSS.SetActive(false);
            GO.SetActive(false);
            HTML.SetActive(false);
            Java.SetActive(false);
            JavaScript.SetActive(false);
            Kotlin.SetActive(false);
            Lua.SetActive(false);
            PHP.SetActive(false);
            Python.SetActive(false);
            React.SetActive(false);
            SQL.SetActive(false);
            Swift.SetActive(false);
            TypeScript.SetActive(false);
            Flutter.SetActive(false);
            Dart.SetActive(false);
        }

        if (CurrentButton == 2)
        {
            C.SetActive(false);
            CS.SetActive(false);
            CPP.SetActive(true);
            CSS.SetActive(false);
            GO.SetActive(false);
            HTML.SetActive(false);
            Java.SetActive(false);
            JavaScript.SetActive(false);
            Kotlin.SetActive(false);
            Lua.SetActive(false);
            PHP.SetActive(false);
            Python.SetActive(false);
            React.SetActive(false);
            SQL.SetActive(false);
            Swift.SetActive(false);
            TypeScript.SetActive(false);
            Flutter.SetActive(false);
            Dart.SetActive(false);
        }

        if (CurrentButton == 3)
        {
            C.SetActive(false);
            CS.SetActive(false);
            CPP.SetActive(false);
            CSS.SetActive(true);
            GO.SetActive(false);
            HTML.SetActive(false);
            Java.SetActive(false);
            JavaScript.SetActive(false);
            Kotlin.SetActive(false);
            Lua.SetActive(false);
            PHP.SetActive(false);
            Python.SetActive(false);
            React.SetActive(false);
            SQL.SetActive(false);
            Swift.SetActive(false);
            TypeScript.SetActive(false);
            Flutter.SetActive(false);
            Dart.SetActive(false);
        }

        if (CurrentButton == 4)
        {
            C.SetActive(false);
            CS.SetActive(false);
            CPP.SetActive(false);
            CSS.SetActive(false);
            GO.SetActive(true);
            HTML.SetActive(false);
            Java.SetActive(false);
            JavaScript.SetActive(false);
            Kotlin.SetActive(false);
            Lua.SetActive(false);
            PHP.SetActive(false);
            Python.SetActive(false);
            React.SetActive(false);
            SQL.SetActive(false);
            Swift.SetActive(false);
            TypeScript.SetActive(false);
            Flutter.SetActive(false);
            Dart.SetActive(false);
        }
        
        if (CurrentButton == 5)
        {
            C.SetActive(false);
            CS.SetActive(false);
            CPP.SetActive(false);
            CSS.SetActive(false);
            GO.SetActive(false);
            HTML.SetActive(true);
            Java.SetActive(false);
            JavaScript.SetActive(false);
            Kotlin.SetActive(false);
            Lua.SetActive(false);
            PHP.SetActive(false);
            Python.SetActive(false);
            React.SetActive(false);
            SQL.SetActive(false);
            Swift.SetActive(false);
            TypeScript.SetActive(false);
            Flutter.SetActive(false);
            Dart.SetActive(false);
        }
        
        if (CurrentButton == 6)
        {
            C.SetActive(false);
            CS.SetActive(false);
            CPP.SetActive(false);
            CSS.SetActive(false);
            GO.SetActive(false);
            HTML.SetActive(false);
            Java.SetActive(true);
            JavaScript.SetActive(false);
            Kotlin.SetActive(false);
            Lua.SetActive(false);
            PHP.SetActive(false);
            Python.SetActive(false);
            React.SetActive(false);
            SQL.SetActive(false);
            Swift.SetActive(false);
            TypeScript.SetActive(false);
            Flutter.SetActive(false);
            Dart.SetActive(false);
        }
        
        if (CurrentButton == 7)
        {
            C.SetActive(false);
            CS.SetActive(false);
            CPP.SetActive(false);
            CSS.SetActive(false);
            GO.SetActive(false);
            HTML.SetActive(false);
            Java.SetActive(false);
            JavaScript.SetActive(true);
            Kotlin.SetActive(false);
            Lua.SetActive(false);
            PHP.SetActive(false);
            Python.SetActive(false);
            React.SetActive(false);
            SQL.SetActive(false);
            Swift.SetActive(false);
            TypeScript.SetActive(false);
            Flutter.SetActive(false);
            Dart.SetActive(false);
        }
        
        if (CurrentButton == 8)
        {
            C.SetActive(false);
            CS.SetActive(false);
            CPP.SetActive(false);
            CSS.SetActive(false);
            GO.SetActive(false);
            HTML.SetActive(false);
            Java.SetActive(false);
            JavaScript.SetActive(false);
            Kotlin.SetActive(true);
            Lua.SetActive(false);
            PHP.SetActive(false);
            Python.SetActive(false);
            React.SetActive(false);
            SQL.SetActive(false);
            Swift.SetActive(false);
            TypeScript.SetActive(false);
            Flutter.SetActive(false);
            Dart.SetActive(false);
        }
        
        if (CurrentButton == 9)
        {
            C.SetActive(false);
            CS.SetActive(false);
            CPP.SetActive(false);
            CSS.SetActive(false);
            GO.SetActive(false);
            HTML.SetActive(false);
            Java.SetActive(false);
            JavaScript.SetActive(false);
            Kotlin.SetActive(false);
            Lua.SetActive(true);
            PHP.SetActive(false);
            Python.SetActive(false);
            React.SetActive(false);
            SQL.SetActive(false);
            Swift.SetActive(false);
            TypeScript.SetActive(false);
            Flutter.SetActive(false);
            Dart.SetActive(false);
        }
        
        if (CurrentButton == 10)
        {
            C.SetActive(false);
            CS.SetActive(false);
            CPP.SetActive(false);
            CSS.SetActive(false);
            GO.SetActive(false);
            HTML.SetActive(false);
            Java.SetActive(false);
            JavaScript.SetActive(false);
            Kotlin.SetActive(false);
            Lua.SetActive(false);
            PHP.SetActive(true);
            Python.SetActive(false);
            React.SetActive(false);
            SQL.SetActive(false);
            Swift.SetActive(false);
            TypeScript.SetActive(false);
            Flutter.SetActive(false);
            Dart.SetActive(false);
        }
        
        if (CurrentButton == 11)
        {
            C.SetActive(false);
            CS.SetActive(false);
            CPP.SetActive(false);
            CSS.SetActive(false);
            GO.SetActive(false);
            HTML.SetActive(false);
            Java.SetActive(false);
            JavaScript.SetActive(false);
            Kotlin.SetActive(false);
            Lua.SetActive(false);
            PHP.SetActive(false);
            Python.SetActive(true);
            React.SetActive(false);
            SQL.SetActive(false);
            Swift.SetActive(false);
            TypeScript.SetActive(false);
            Flutter.SetActive(false);
            Dart.SetActive(false);
        }

        if (CurrentButton == 12)
        {
            C.SetActive(false);
            CS.SetActive(false);
            CPP.SetActive(false);
            CSS.SetActive(false);
            GO.SetActive(false);
            HTML.SetActive(false);
            Java.SetActive(false);
            JavaScript.SetActive(false);
            Kotlin.SetActive(false);
            Lua.SetActive(false);
            PHP.SetActive(false);
            Python.SetActive(false);
            React.SetActive(true);
            SQL.SetActive(false);
            Swift.SetActive(false);
            TypeScript.SetActive(false);
            Flutter.SetActive(false);
            Dart.SetActive(false);
        }

        if (CurrentButton == 13)
        {
            C.SetActive(false);
            CS.SetActive(false);
            CPP.SetActive(false);
            CSS.SetActive(false);
            GO.SetActive(false);
            HTML.SetActive(false);
            Java.SetActive(false);
            JavaScript.SetActive(false);
            Kotlin.SetActive(false);
            Lua.SetActive(false);
            PHP.SetActive(false);
            Python.SetActive(false);
            React.SetActive(false);
            SQL.SetActive(true);
            Swift.SetActive(false);
            TypeScript.SetActive(false);
            Flutter.SetActive(false);
            Dart.SetActive(false);
        }

        if (CurrentButton == 14)
        {
            C.SetActive(false);
            CS.SetActive(false);
            CPP.SetActive(false);
            CSS.SetActive(false);
            GO.SetActive(false);
            HTML.SetActive(false);
            Java.SetActive(false);
            JavaScript.SetActive(false);
            Kotlin.SetActive(false);
            Lua.SetActive(false);
            PHP.SetActive(false);
            Python.SetActive(false);
            React.SetActive(false);
            SQL.SetActive(false);
            Swift.SetActive(true);
            TypeScript.SetActive(false);
            Flutter.SetActive(false);
            Dart.SetActive(false);
        }

        if (CurrentButton == 15)
        {
            C.SetActive(false);
            CS.SetActive(false);
            CPP.SetActive(false);
            CSS.SetActive(false);
            GO.SetActive(false);
            HTML.SetActive(false);
            Java.SetActive(false);
            JavaScript.SetActive(false);
            Kotlin.SetActive(false);
            Lua.SetActive(false);
            PHP.SetActive(false);
            Python.SetActive(false);
            React.SetActive(false);
            SQL.SetActive(false);
            Swift.SetActive(false);
            TypeScript.SetActive(true);
            Flutter.SetActive(false);
            Dart.SetActive(false);
        }

        if (CurrentButton == 16)
        {
            C.SetActive(false);
            CS.SetActive(false);
            CPP.SetActive(false);
            CSS.SetActive(false);
            GO.SetActive(false);
            HTML.SetActive(false);
            Java.SetActive(false);
            JavaScript.SetActive(false);
            Kotlin.SetActive(false);
            Lua.SetActive(false);
            PHP.SetActive(false);
            Python.SetActive(false);
            React.SetActive(false);
            SQL.SetActive(false);
            Swift.SetActive(false);
            TypeScript.SetActive(false);
            Flutter.SetActive(true);
            Dart.SetActive(false);
        }

        if (CurrentButton == 17)
        {
            C.SetActive(false);
            CS.SetActive(false);
            CPP.SetActive(false);
            CSS.SetActive(false);
            GO.SetActive(false);
            HTML.SetActive(false);
            Java.SetActive(false);
            JavaScript.SetActive(false);
            Kotlin.SetActive(false);
            Lua.SetActive(false);
            PHP.SetActive(false);
            Python.SetActive(false);
            React.SetActive(false);
            SQL.SetActive(false);
            Swift.SetActive(false);
            TypeScript.SetActive(false);
            Flutter.SetActive(false);
            Dart.SetActive(true);
        }
    }
}

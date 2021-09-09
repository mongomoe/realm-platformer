using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AuthenticationManager : MonoBehaviour
{

    public static VisualElement root;
    public static Label subtitle;
    public static Button startButton;
    public static bool isShowingRegisterUI = false;
    public static string loggedInUser;
    public static TextField userInput;

    void Start()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        subtitle = root.Q<Label>("subtitle");
        startButton = root.Q<Button>("start-button");

        userInput = root.Q<TextField>("username-input");


        startButton.clicked += () =>
        {
            onPressLogin();
        };
    }



    public static void onPressLogin()
    {
        try
        {
            root.AddToClassList("hide");
            loggedInUser = userInput.value;
            RealmController.setLoggedInUser(loggedInUser);
            ScoreCardManager.setLoggedInUser(loggedInUser);
            LeaderboardManager.Instance.setLoggedInUser(loggedInUser);
        }
        catch (Exception ex)
        {
            Debug.Log("an exception was thrown:" + ex.Message);
        }
    }

}


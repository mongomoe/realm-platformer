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
    public static Realms.Sync.User syncUser;
    private static TextField passInput;
    public static Button toggleLoginOrRegisterUIButton;
    public static Player currentPlayer;


    void Start()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        subtitle = root.Q<Label>("subtitle");
        startButton = root.Q<Button>("start-button");
        userInput = root.Q<TextField>("username-input");
        passInput = root.Q<TextField>("password-input");
        passInput.isPasswordField = true; // sync line
        toggleLoginOrRegisterUIButton = root.Q<Button>("toggle-login-or-register-ui-button");

        toggleLoginOrRegisterUIButton.clicked += () =>
        {
            // if the registerUI is already visible, switch to the loginUI and set isShowingRegisterUI to false	
            if (isShowingRegisterUI == true)
            {
                switchToLoginUI();
                isShowingRegisterUI = false;
            }
            else
            {
                switchToRegisterUI();
                isShowingRegisterUI = true;
            }
        };

        startButton.clicked += async () =>
        {
            if (isShowingRegisterUI == true)
            {
                onPressRegister();
            }
            else
            {
                onPressLogin();
            }
        };
    }

    public static void switchToLoginUI()
    {
        subtitle.text = "Login";
        startButton.text = "Login & Start Game";
        toggleLoginOrRegisterUIButton.text = "Don't have an account yet? Register";
    }
    public static void switchToRegisterUI()
    {
        subtitle.text = "Register";
        startButton.text = "Signup & Start Game";
        toggleLoginOrRegisterUIButton.text = "Have an account already? Login";
    }


    public static async void onPressLogin()
    {
        try
        {
            currentPlayer = await RealmController.setLoggedInUser(userInput.value, passInput.value);
            if (currentPlayer != null)
            {
                root.AddToClassList("hide");
            }
            ScoreCardManager.setLoggedInUser(currentPlayer.Name);
            LeaderboardManager.Instance.setLoggedInUser(currentPlayer.Name);
        }
        catch (Exception ex)
        {
            Debug.Log("an exception was thrown:" + ex.Message);
        }
    }
    public static async void onPressRegister()
    {
        try
        {
            currentPlayer = await RealmController.OnPressRegister(userInput.value, passInput.value);

            if (currentPlayer != null)
            {
                root.AddToClassList("hide");
            }
            ScoreCardManager.setLoggedInUser(currentPlayer.Name);
            LeaderboardManager.Instance.setLoggedInUser(currentPlayer.Name);

        }
        catch (Exception ex)
        {
            Debug.Log("an exception was thrown:" + ex.Message);
        }
    }
}


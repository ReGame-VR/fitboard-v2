using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Login : MonoBehaviour {

    public static string currentUser;
    public static Dictionary<string, string> userDict;
    public InputField username;
    public InputField password;
    public InputField newUser;
    public InputField newPass;
    public bool setDefault;
    public GameObject wrong;
    public GameObject badRegister;
    public GameObject goodRegister;

    // Use this for initialization
    void Start() {
        if (setDefault) {
            ResetUsers();
        }
        InitUsers();
    }

    public void ClearFields() {
        username.text = "";
        password.text = "";
        newUser.text = "";
        newPass.text = "";
    }

    public void LoginSubmit() {
        if (Submit(username.text, password.text)) {
            Login.currentUser = username.text;
            Debug.Log("current user: " + username.text);
            LevelManager.instance.LoadLevel("Patient Selection");
        } else {
            wrong.SetActive(true);
            Debug.Log(username.text + "," +  password.text);
            Debug.Log(username.text.GetHashCode().ToString() + "," + userDict[username.text]);
        }
    }

    public void RegisterSubmit() {
        if (Register(newUser.text, newPass.text)) {
            goodRegister.SetActive(true);
        } else {
            badRegister.SetActive(false);
        }
    }

    /// <summary>
    /// Checks the given username and password in the dictionary of users.
    /// </summary>
    /// <param name="user"> The inputted username. </param>
    /// <param name="pass"> The inputted password. </param>
    /// <returns> Returns whether or not the username password pair succeeded. </returns>
    public bool Submit(string user, string pass) {
        if (userDict.ContainsKey(user)) {
            if (Mathf.Abs(pass.GetHashCode()).ToString().Equals(userDict[user])) {
                return true;
            }
        }
        return false;
    }

    
    private void InitUsers() {
        string[] info = PlayerPrefsManager.GetUsers().Split('.');
        Debug.Log("password1".GetHashCode());
        Debug.Log(PlayerPrefsManager.GetUsers());
        string usernames = info[0];
        Debug.Log(usernames);
        string passwords = info[1];
        Debug.Log(passwords);
        List<string> users = usernames.Split('-').ToList();
        List<string> pass = passwords.Split('-').ToList();
        Debug.Log(users);
        Debug.Log(pass);
        userDict = users.ToDictionary(x => x, x => pass[users.IndexOf(x)]);
    }

    /// <summary>
    /// Adds the given user info to the saved String in the format "user1-user2-user3.pass1-pass2-pass3" . 
    /// </summary>
    /// <param name="username"> The plaintext username passed from the input field. </param>
    /// <param name="password"> The plaintext password passed from the input field.</param>
    public bool Register(string username, string password) {
        #region invalid input checking
        if (username.Length > 15 || 
            userDict.ContainsKey(username) || 
            username.Contains(",") || 
            password.Contains(",") || 
            username.Contains("-") || 
            password.Contains("-")) {
            return false;
        }
        #endregion 
    

        string[] info = PlayerPrefsManager.GetUsers().Split('.');
        string usernames = info[0];
        string passwords = info[1];
        usernames = usernames + "-" + username + ".";
        passwords = passwords + "-" + Mathf.Abs(password.GetHashCode());
        PlayerPrefsManager.SetUsers(usernames + passwords);
        userDict.Add(username, Mathf.Abs(password.GetHashCode()).ToString());
        return true;
    }

    /// <summary>
    /// Resets the user information to empty. Only used in testing.
    /// </summary>
    public void ResetUsers() {
        PlayerPrefsManager.SetUsers("default1-default2." + Mathf.Abs("password1".GetHashCode()) + "-" + Mathf.Abs("password2".GetHashCode()));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using Newtonsoft.Json;


public class PlayFabManager : MonoBehaviour
{
    public InputField emailInput;
    public InputField userNameInput;
    public InputField passwordInput;
    public Text notice;

    public Leaderboard Leaderboard;
    public Score score;
    //public ListFoderVocabulary foder;
    public FoderScriptAble foder;
    public VocaScriptAble voca;
    public static PlayFabManager instance;
    // Start is called before the first frame update


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
       
    }


    //  public void Login()
    //{
    //    var request = new LoginWithCustomIDRequest
    //    {
    //        CustomId = SystemInfo.deviceUniqueIdentifier, CreateAccount = true
    //    };
    //    PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);

    //}

    public void SendFeedBack(string topic,string message)
    {
        var request = new ExecuteCloudScriptRequest
        {
            FunctionName = "sendFeedback",
            FunctionParameter = new
            {
                topic = topic,
                message = message
            }
        };
        PlayFabClientAPI.ExecuteCloudScript(request, OnExecuteSuccess, OnError);
    }

    void OnExecuteSuccess (ExecuteCloudScriptResult result)
    {
        Debug.Log("Execute Cloud Script Success");
    }
    public void Register()
    {
        if (passwordInput.text.Length < 6) Debug.Log("Password too short !!");

        var request = new RegisterPlayFabUserRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text,
            Username = userNameInput.text,

            RequireBothUsernameAndEmail = true
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, RegisterSuccess, OnError);
    }

    void RegisterSuccess(RegisterPlayFabUserResult result)
    {
        notice.text = "Register Success !!";
        Debug.Log("Register Success !!");
    }

 
    public void LoginWithAccount()
    {
        PlayFabClientAPI.ForgetAllCredentials();
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true
            }

        };
      
        PlayFabClientAPI.LoginWithEmailAddress(request, OnSuccess, OnError);
    }

    public void SaveVoca()
    {
        List<Vocabulary> listVoca = new List<Vocabulary>();
        //Vocabulary a = new Vocabulary("1", "book1", "sach1", 5);
        //Vocabulary b = new Vocabulary("1", "book2", "sach2", 8);
        //Vocabulary c = new Vocabulary("1", "book3", "sach3", 7);
        //listVoca.Add(a);
        //listVoca.Add(b);
        //listVoca.Add(c);
        foreach (var item in voca.vocabularyList)
        {
            listVoca.Add(item);
        }
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                {"Vocabulary" ,JsonConvert.SerializeObject(listVoca)}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);

    }
    public void SaveFoder()
    {
        List<Foder> listFoder = new List<Foder>();
        //Foder a = new Foder("1");
        //Foder b = new Foder("2");
        //Foder c = new Foder("3");
        //listFoder.Add(a);
        //listFoder.Add(b);
        //listFoder.Add(c);
        foreach (var item in foder.foderList)
        {
            listFoder.Add(item);
        }
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                {"Foder" ,JsonConvert.SerializeObject(listFoder)}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
    }

    public void GetVoca()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnVocaRecieved, OnError);
    }

    void OnVocaRecieved(GetUserDataResult result)
    {
        if (result != null && result.Data.ContainsKey("Vocabulary"))
        {
            List<Vocabulary> listVoca = JsonConvert.DeserializeObject<List<Vocabulary>>(result.Data["Vocabulary"].Value);
            voca.vocabularyList.Clear();
            voca.vocabularyList = listVoca;
            foreach (var item in voca.vocabularyList)
            {
                Debug.Log(item.english + " +" + item.vietnam +" + "+ item.know);
            }
        }
    }

    public void GetFoder()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnFoderRecieved, OnError);
    }

     void OnFoderRecieved(GetUserDataResult result)
    {
        if (result != null && result.Data.ContainsKey("Foder"))
        {
            List<Foder> listFoder = JsonConvert.DeserializeObject<List<Foder>>(result.Data["Foder"].Value);
            foder.foderList.Clear();
            foder.foderList = listFoder;
            foreach(var item in foder.foderList)
            {
                Debug.Log( item.name);
            }
        }
    }

    public void SaveTotalScore()
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                { "TotalScore", score.score.ToString() }
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
    }

    void OnDataSend(UpdateUserDataResult result)
    {
        Debug.Log("Send Data Successful");
    }

    public void GetTotalScore()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataRecieved, OnError);
    }

    void OnDataRecieved(GetUserDataResult result)
    {

        if (result != null && result.Data.ContainsKey("TotalScore"))
        {
            score.score = int.Parse(result.Data["TotalScore"].Value);
            Debug.Log("Set Total Score Successful");
        }
    }

    public void SendLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "TotalScore", Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    public void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Successfull leaderboard sent");
    }


    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "TotalScore",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnGetLeaderboardGet, OnError);
    }

    void OnGetLeaderboardGet(GetLeaderboardResult result)
    {
        Leaderboard.Players.Clear();
        foreach (var item in result.Leaderboard)
        {
            Leaderboard.AddPlayerRank(item.DisplayName, (item.Position + 1).ToString(), item.StatValue.ToString());
            Debug.Log(item.Position + " " + item.DisplayName + " " + item.StatValue);
        }
    }
    void OnSuccess(LoginResult result)
    {
        notice.text = "Login Succes";
        Debug.Log("Login Succes / Account create");
        string name = null;
        if (result.InfoResultPayload.PlayerProfile != null)
            name = result.InfoResultPayload.PlayerProfile.DisplayName;
        if (name == null)
        {
            SummitUserName();
        }
    }

    void SummitUserName()
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = userNameInput.text
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisPlayNameUpdate, OnError);
    }

    void OnDisPlayNameUpdate(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("Update display name ");
    }
    void OnError(PlayFabError error)
    {
        Debug.Log("Login Error / NOT Account create");
        Debug.Log(error.GenerateErrorReport());

    }


}

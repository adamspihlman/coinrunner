using UnityEngine;
using UnityEngine.UI;

/************************************************************************************
 * 
 *							        Leaderboard Manager
 *							  
 *				         Handles the backend of the manager script.
 *			
 *			                        Script written by: 
 *			           Jonathan Carter (https://jonathan.carter.games)
 *			        
 *									Version: 1.0.2
 *						   Last Updated: 07/10/2020 (d/m/y)					
 * 
*************************************************************************************/

public class LeaderboardDisplay3 : MonoBehaviour
{
    /// <summary>
    /// The parent that all row UI elements to be attached to.
    /// </summary>
    [Tooltip("The 'Content' that is in the scroll view for the leaderboard.")]
    [SerializeField] private GameObject leaderboardDisplay;

    /// <summary>
    /// The row prefab the holds enough text components for all elements saved in the leaderboard data that you wish to show.
    /// </summary>
    [Tooltip("A Prefab that holds 3 text elements and an image for a leaderboard entry.")]
    [SerializeField] private GameObject leaderboardRowPrefab;

    /// <summary>
    /// Boolean that controls whether or not to only show a specific number of entries.
    /// </summary>
    [Tooltip("Should the display only show 'x' amount of entries?")]
    [SerializeField] private bool showSpecificAmount = true;

    /// <summary>
    /// The number of entries to show (only used if the the 'showSpecificAmount' bool is true).
    /// </summary>
    [Tooltip("The amount of entries the display will show. This is ignored if the value is null.")]
    [SerializeField] private int numberToShow = 25;

    /// <summary>
    /// The local reference for a leaderboard data array, used for the entries in the leaderboard
    /// </summary>
    private LeaderboardData[] _data;



    /// <summary>
    /// Enum of options for the ordering of the leaderboard entries.
    /// </summary>
    public enum DisplayOptions { Unordered, Descending, Ascending };

    /// <summary>
    /// The choice for how the leaderboard should be displayed
    /// </summary>
    [Tooltip("How should the entries be displayed.")]
    public DisplayOptions displayChoice;


    void Start()
    {
        RefreshLBDisplay();
    }

    void Update()
    {

    }

    /// <summary>
    /// Updates the Leaderboard Display with the entries in the leaderboard.
    /// </summary>
    private void RefreshLBDisplay()
    {
        var blue = new Color32(0, 215, 255, 255);
        var black = new Color32(41, 41, 41, 255);
        var red = new Color32(255, 0, 0, 255);
        var green = new Color32(0, 255, 0, 255);
        var purple = new Color32(234, 0, 255, 255);
        var yellow = new Color32(251, 255, 0, 255);
        var orange = new Color32(255, 96, 0, 255);
        var white = new Color32(255, 255, 255, 255);
        var navy = new Color32(0, 0, 255, 255);

        // Goes through your choice from the inspector to get the right leaderbaord data to use in the display
        switch (displayChoice)
        {
            case DisplayOptions.Unordered:
                _data = LeaderboardManager.LoadLeaderboardData(3);
                break;
            case DisplayOptions.Descending:
                _data = LeaderboardManager.LoadLeaderboardDataDescending(3);
                break;
            case DisplayOptions.Ascending:
                _data = LeaderboardManager.LoadLeaderboardDataAscending(3);
                break;
            default:
                break;
        }

        // Checks to see if there has been a request for a specific amount of entries...
        // If Yes, it uses the amount put in the inspector...
        // Else it uses the length of the data...
        if (!showSpecificAmount)
        {
            numberToShow = _data.Length;
        }


        // Adds a display row prefab for each row, if they exsist already for the row it will enable it, otherwise it will create a new row. 
        // Meaning it only uses instantiate when needed.... 
        for (int i = 0; i < numberToShow && i < _data.Length; i++)
        {
            if (i >= leaderboardDisplay.transform.childCount - 1)
            {
                GameObject _go = Instantiate(leaderboardRowPrefab, leaderboardDisplay.transform);
                _go.GetComponentsInChildren<Text>()[0].text = "#" + (i + 1).ToString();
                _go.GetComponentsInChildren<Text>()[1].text = _data[i].playerName;
                _go.GetComponentsInChildren<Text>()[2].text = _data[i].playerScore.ToString();

                Debug.Log(_data[i].playerPowerup);
                if (_data[i].playerPowerup == 0)//none
                {
                    _go.GetComponentsInChildren<Image>()[0].enabled = false;
                    _go.GetComponentsInChildren<Image>()[1].enabled = false;
                    _go.GetComponentsInChildren<Image>()[2].enabled = false;
                }
                else if (_data[i].playerPowerup == 1)//coin
                {
                    _go.GetComponentsInChildren<Image>()[0].enabled = true;
                    _go.GetComponentsInChildren<Image>()[1].enabled = false;
                    _go.GetComponentsInChildren<Image>()[2].enabled = false;
                }
                else if (_data[i].playerPowerup == 2)//jmp
                {
                    _go.GetComponentsInChildren<Image>()[0].enabled = false;
                    _go.GetComponentsInChildren<Image>()[1].enabled = true;
                    _go.GetComponentsInChildren<Image>()[2].enabled = false;
                }
                else if (_data[i].playerPowerup == 3)//invinc
                {
                    _go.GetComponentsInChildren<Image>()[0].enabled = false;
                    _go.GetComponentsInChildren<Image>()[1].enabled = false;
                    _go.GetComponentsInChildren<Image>()[2].enabled = true;
                }


                switch (_data[i].playerColor)
                {
                    case Globals.PLAYER_BLUE:
                        _go.GetComponentsInChildren<Image>()[3].color = blue;
                        break;
                    case Globals.PLAYER_BLACK:
                        _go.GetComponentsInChildren<Image>()[3].color = black;
                        break;
                    case Globals.PLAYER_RED:
                        _go.GetComponentsInChildren<Image>()[3].color = red;
                        break;
                    case Globals.PLAYER_GREEN:
                        _go.GetComponentsInChildren<Image>()[3].color = green;
                        break;
                    case Globals.PLAYER_PURPLE:
                        _go.GetComponentsInChildren<Image>()[3].color = purple;
                        break;
                    case Globals.PLAYER_YELLOW:
                        _go.GetComponentsInChildren<Image>()[3].color = yellow;
                        break;
                    case Globals.PLAYER_ORANGE:
                        _go.GetComponentsInChildren<Image>()[3].color = orange;
                        break;
                    case Globals.PLAYER_WHITE:
                        _go.GetComponentsInChildren<Image>()[3].color = white;
                        break;
                    case Globals.PLAYER_NAVY:
                        _go.GetComponentsInChildren<Image>()[3].color = navy;
                        break;
                }

                if (_data[i].playerPowerup == 2)
                    _go.GetComponentsInChildren<Image>()[1].color = _go.GetComponentsInChildren<Image>()[3].color;
            }

            if (i <= leaderboardDisplay.transform.childCount - 1)
            {
                if (!leaderboardDisplay.transform.GetChild(i + 1).gameObject.activeInHierarchy)
                {
                    GameObject _go = leaderboardDisplay.transform.GetChild(i + 1).gameObject;
                    _go.SetActive(true);
                    _go.GetComponentsInChildren<Text>()[0].text = "#" + (i + 1).ToString();
                    _go.GetComponentsInChildren<Text>()[1].text = _data[i].playerName;
                    _go.GetComponentsInChildren<Text>()[2].text = _data[i].playerScore.ToString();


                    if (_data[i].playerPowerup == 0)//none
                    {
                        _go.GetComponentsInChildren<Image>()[0].enabled = false;
                        _go.GetComponentsInChildren<Image>()[1].enabled = false;
                        _go.GetComponentsInChildren<Image>()[2].enabled = false;
                    }
                    else if (_data[i].playerPowerup == 1)//coin
                    {
                        _go.GetComponentsInChildren<Image>()[0].enabled = true;
                        _go.GetComponentsInChildren<Image>()[1].enabled = false;
                        _go.GetComponentsInChildren<Image>()[2].enabled = false;
                    }
                    else if (_data[i].playerPowerup == 2)//jmp
                    {
                        _go.GetComponentsInChildren<Image>()[0].enabled = false;
                        _go.GetComponentsInChildren<Image>()[1].enabled = true;
                        _go.GetComponentsInChildren<Image>()[2].enabled = false;
                    }
                    else if (_data[i].playerPowerup == 3)//invinc
                    {
                        _go.GetComponentsInChildren<Image>()[0].enabled = false;
                        _go.GetComponentsInChildren<Image>()[1].enabled = false;
                        _go.GetComponentsInChildren<Image>()[2].enabled = true;
                    }

                    switch (_data[i].playerColor)
                    {
                        case Globals.PLAYER_BLUE:
                            _go.GetComponentsInChildren<Image>()[3].color = blue;
                            break;
                        case Globals.PLAYER_BLACK:
                            _go.GetComponentsInChildren<Image>()[3].color = black;
                            break;
                        case Globals.PLAYER_RED:
                            _go.GetComponentsInChildren<Image>()[3].color = red;
                            break;
                        case Globals.PLAYER_GREEN:
                            _go.GetComponentsInChildren<Image>()[3].color = green;
                            break;
                        case Globals.PLAYER_PURPLE:
                            _go.GetComponentsInChildren<Image>()[3].color = purple;
                            break;
                        case Globals.PLAYER_YELLOW:
                            _go.GetComponentsInChildren<Image>()[3].color = yellow;
                            break;
                        case Globals.PLAYER_ORANGE:
                            _go.GetComponentsInChildren<Image>()[3].color = orange;
                            break;
                        case Globals.PLAYER_WHITE:
                            _go.GetComponentsInChildren<Image>()[3].color = white;
                            break;
                        case Globals.PLAYER_NAVY:
                            _go.GetComponentsInChildren<Image>()[3].color = navy;
                            break;
                    }

                    if (_data[i].playerPowerup == 2)
                        _go.GetComponentsInChildren<Image>()[1].color = _go.GetComponentsInChildren<Image>()[3].color;
                }
            }
        }
    }


    /// <summary>
    /// Clears the leaderboard via disabeling the old objects...
    /// </summary>
    public void ClearLeaderboard()
    {
        if (!showSpecificAmount)
        {
            numberToShow = leaderboardDisplay.transform.childCount;
        }

        for (int i = 1; i < numberToShow; i++)
        {
            leaderboardDisplay.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void ClearAll()
    {
        LeaderboardManager.ClearLeaderboardData();
        ClearLeaderboard();
        RefreshLBDisplay();
    }
}
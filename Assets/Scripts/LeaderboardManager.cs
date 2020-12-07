using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Linq;

/************************************************************************************
 * 
 *							        Leaderboard Manager
 *							  
 *				                Leaderboard Manager Script
 *				         Handles the backend of the manager script.
 *			
 *			                        Script written by: 
 *			           Jonathan Carter (https://jonathan.carter.games)
 *			        
 *									Version: 1.0.2
 *						   Last Updated: 07/10/2020 (d/m/y)					
 * 
*************************************************************************************/
public class LeaderboardManager : MonoBehaviour
{
    /// <summary>
    /// Adds a new entry into the leaderboard and saves it.
    /// </summary>
    /// <param name="name">the player name to add with the new entry</param>
    /// <param name="score">the player score to add with the new entry</param>
    public static void AddToLeaderboard(string name, float score, int level, int color, int powerup)
    {
        string SavePath = Application.persistentDataPath + "/Leaderboard/" + level + ".lsf";

        if (File.Exists(SavePath))
        {
            LeaderboardStore _storedData = LoadLeaderboardStore(level);
            _storedData.leaderboardData.Add(new LeaderboardData(name, score, color, powerup));
            BinaryFormatter Formatter = new BinaryFormatter();
            FileStream Stream = new FileStream(SavePath, FileMode.OpenOrCreate);
            Formatter.Serialize(Stream, _storedData);
            Stream.Close();
        }
        else
        {
            SaveLeaderboardStore(new LeaderboardStore(), level);
            LeaderboardStore _storedData = new LeaderboardStore();
            _storedData.leaderboardData.Add(new LeaderboardData(name, score, color, powerup));
            BinaryFormatter Formatter = new BinaryFormatter();
            FileStream Stream = new FileStream(SavePath, FileMode.OpenOrCreate);
            Formatter.Serialize(Stream, _storedData);
            Stream.Close();
            Debug.LogWarning("* Leaderboard Manager * | Creating Leaderboard " + level);
        }
    }


    /// <summary>
    /// Removes an entry from the leaderboard
    /// </summary>
    /// <param name="playerName">(String) the players name to check for</param>
    /// <param name="playerScore">(Float) the player score to check for</param>
    /// Not needed for now
    /*
    public static void RemoveEntryFromLeaderboard(string playerName, float playerScore)
    {
        LeaderboardStore _store = LoadLeaderboardStore();

        for (int i = 0; i < _store.leaderboardData.Count; i++)
        {
            if (_store.leaderboardData[i].playerName.Equals(playerName) && _store.leaderboardData[i].playerScore.Equals(playerScore))
            {
                _store.leaderboardData.RemoveAt(i);
                break;
            }
        }

        SaveLeaderboardStore(_store);
    }
    */


    /// <summary>
    /// Saves the leaderboard store into the save file.
    /// Also checks to see if the leaderboard directory exsists in your games default save location
    /// </summary>
    /// <param name="_storedData">LeaderboardStore to save in the file</param>
    public static void SaveLeaderboardStore(LeaderboardStore _storedData, int level)
    {
        string SavePath = Application.persistentDataPath + "/Leaderboard/" + level + ".lsf";

        if (File.Exists(SavePath))
        {
            BinaryFormatter Formatter = new BinaryFormatter();
            FileStream Stream = new FileStream(SavePath, FileMode.OpenOrCreate);
            Formatter.Serialize(Stream, _storedData);
            Stream.Close();
        }
        else
        {
            if (!Directory.Exists(Application.persistentDataPath + "/Leaderboard"))
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/Leaderboard");
                BinaryFormatter Formatter = new BinaryFormatter();
                FileStream Stream = new FileStream(SavePath, FileMode.OpenOrCreate);
                Formatter.Serialize(Stream, _storedData);
                Stream.Close();
            }
            else
            {
                BinaryFormatter Formatter = new BinaryFormatter();
                FileStream Stream = new FileStream(SavePath, FileMode.OpenOrCreate);
                Formatter.Serialize(Stream, _storedData);
                Stream.Close();
            }
        }
    }


    /// <summary>
    /// Loads the saved LeaderboardStore from the save file used for the leaderboard
    /// </summary>
    /// <returns></returns>
    public static LeaderboardStore LoadLeaderboardStore(int level)
    {
        string SavePath = Application.persistentDataPath + "/Leaderboard/" + level + ".lsf";

        if (File.Exists(SavePath))
        {
            BinaryFormatter Formatter = new BinaryFormatter();
            FileStream Stream = new FileStream(SavePath, FileMode.Open);

            LeaderboardStore _data = Formatter.Deserialize(Stream) as LeaderboardStore;

            Stream.Close();

            return _data;
        }
        else
        {
            Debug.LogError("* Leaderboard Manager * | Level " + level + " Leaderboard File Not Found");
            return null;
        }
    }


    /// <summary>
    /// Loads the saved LeaderboardData from the save file used for the leaderboard
    /// </summary>
    /// <returns></returns>
    public static LeaderboardData[] LoadLeaderboardData(int level)
    {
        string SavePath = Application.persistentDataPath + "/Leaderboard/" + level + ".lsf";

        if (File.Exists(SavePath))
        {
            BinaryFormatter Formatter = new BinaryFormatter();
            FileStream Stream = new FileStream(SavePath, FileMode.Open);

            LeaderboardStore _data = Formatter.Deserialize(Stream) as LeaderboardStore;

            Stream.Close();

            return _data.leaderboardData.ToArray();
        }
        else
        {
            Debug.LogError("* Leaderboard Manager * | Level " + level + " Leaderboard File Not Found");
            return null;
        }
    }


    /// <summary>
    /// Loads the leaderboard values in a decesnding order based on the players scores.
    /// </summary>
    /// <returns>(Array of LeaderboardData) Entries in the save file ordered by score</returns>
    public static LeaderboardData[] LoadLeaderboardDataDescending(int level)
    {
        string SavePath = Application.persistentDataPath + "/Leaderboard/" + level + ".lsf";

        if (File.Exists(SavePath))
        {
            BinaryFormatter Formatter = new BinaryFormatter();
            FileStream Stream = new FileStream(SavePath, FileMode.Open);
            LeaderboardStore _store = Formatter.Deserialize(Stream) as LeaderboardStore;
            Stream.Close();

            List<LeaderboardData> _array = new List<LeaderboardData>();
            _array = _store.SortedLBD.ToList();
            _array.Reverse();

            return _array.ToArray();
        }
        else
        {
            Debug.LogError("* Leaderboard Manager * | Level " + level + " Leaderboard File Not Found");
            return null;
        }
    }


    /// <summary>
    /// Loads the leaderboard values in a ascending order based on the players scores.
    /// </summary>
    /// <returns>(Array of LeaderboardData) Entries in the save file ordered by score</returns>
    public static LeaderboardData[] LoadLeaderboardDataAscending(int level)
    {
        string SavePath = Application.persistentDataPath + "/Leaderboard/" + level + ".lsf";

        if (File.Exists(SavePath))
        {
            BinaryFormatter Formatter = new BinaryFormatter();
            FileStream Stream = new FileStream(SavePath, FileMode.Open);
            LeaderboardStore _store = Formatter.Deserialize(Stream) as LeaderboardStore;
            Stream.Close();

            List<LeaderboardData> _array = new List<LeaderboardData>();
            _array = _store.SortedLBD.ToList();

            return _array.ToArray();
        }
        else
        {
            Debug.LogError("* Leaderboard Manager * | Level " + level + " Leaderboard File Not Found");
            return null;
        }
    }


    /// <summary>
    /// Clears the leaderboard data at the file level.
    /// </summary>
    public static void ClearLeaderboardData()
    {
        for(int i = 1; i <= Globals.NUM_LEVELS; i++)
        {
            string SavePath = Application.persistentDataPath + "/Leaderboard/" + i + ".lsf";
            LeaderboardStore _storedData = new LeaderboardStore();

            if (File.Exists(SavePath))
            {
                BinaryFormatter Formatter = new BinaryFormatter();
                FileStream Stream = new FileStream(SavePath, FileMode.OpenOrCreate);
                Formatter.Serialize(Stream, _storedData);
                Stream.Close();
            }
            else
            {
                if (!Directory.Exists(Application.persistentDataPath + "/Leaderboard"))
                {
                    Directory.CreateDirectory(Application.persistentDataPath + "/Leaderboard");
                    BinaryFormatter Formatter = new BinaryFormatter();
                    FileStream Stream = new FileStream(SavePath, FileMode.OpenOrCreate);
                    Formatter.Serialize(Stream, _storedData);
                    Stream.Close();
                }
                else
                {
                    BinaryFormatter Formatter = new BinaryFormatter();
                    FileStream Stream = new FileStream(SavePath, FileMode.OpenOrCreate);
                    Formatter.Serialize(Stream, _storedData);
                    Stream.Close();
                }
            }
        }
    }    
}
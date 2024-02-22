using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public static SoccerPlayer selectedPlayer { get; private set; }
    public static void SetSelectedPlayer(SoccerPlayer player)
    {
        if(selectedPlayer != null)
        {
            selectedPlayer.selected(false);
        }
        selectedPlayer = player;
        player.selected(true);
    }
}

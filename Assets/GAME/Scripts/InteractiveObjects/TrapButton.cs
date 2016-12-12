using System;
using UnityEngine;

public class TrapButton : InteractiveObject
{
    Game_Manager game;
    AudioSource deadSound;

    protected new void Start()
    {
        base.Start();
        game = GameObject.Find("GameManager").GetComponent<Game_Manager>();
        deadSound = GetComponent<AudioSource>();
    }

    public override void OnFocus(PlayerController playerCtrl)
    {
        this.ui.SetInteractionInfo(ControlDesc.INTERACT + " Push " + objectName);
    }

    public override void OnTrigger(PlayerController playerCtrl)
    {
        deadSound.Play();
        game.Lose();
    }
}
﻿using UnityEngine;
using System.Collections;
//this script can be found in the Component section under the option Character Set Up 
//Character Handler
public class CharacterHandler : MonoBehaviour 
{
    [Header("Character")]
    #region Character 
    //bool to tell if the player is alive
    public bool alive;
    //connection to players character controller
    public CharacterController controller;
    #endregion
    [Header("Health")]
    #region Health
    //max and current health
    public float maxHealth;
    public float curHealth;
    public GUIStyle healthBar;
    #endregion
    [Header("Levels and Exp")]
    #region Level and Exp
    //players current level
    //max and min experience 
    #endregion
    [Header("Camera Connection")]
    #region MiniMap
    //render texture for the mini map that we need to connect to a camera
    public RenderTexture miniMap;
    #endregion
    #region Start
    private void Start()
    {
        //set max health to 100
        maxHealth = 100f;
        //set current health to max
        curHealth = maxHealth;
        //make sure player is alive
        alive = true
        //max exp starts at 60
        maxExp = 60;
        //connect the Character Controller to the controller variable
        controller = this.GetComponent<CharacterController>();

    }

    #endregion
    #region Update
    private void Update()
    {
        //if our current experience is greater or equal to the maximum experience
        //then the current experience is equal to our experience minus the maximum amount of experience
        curExp -= maxExp;
        //our level goes up by one
        level++;
        //the maximum amount of experience is increased by 50
        maxEcp += 50;
    }

    #endregion
    #region LateUpdate
    private void LateUpdate()
    {
        //if our current health is greater than our maximum amount of health
        if (curHealth > maxHealth)
        {
            //then our current health is equal to the max health
            curHealth = maxHealth;
        }
        //if our current health is less than 0 or we are not alive
        if (curHealth <0 || !alive)
        {
            //current health equals 0
            curHealth = 0;
        }
        //if the player is alive
        if (alive)
        {
            //and our health is less than or equal to 0
            if (curHealth == 0)
            {
                //alive is false
                alive = false;
                //controller is turned off
                controller.enabled = false;
                Debug.Log("Disable on yeet");
            }
        }

        
        
    }
    #endregion
    #region OnGUI
    private void OnGUI()
    {
        //set up our aspect ratio for the GUI elements
        //scrW - 16
        float scrW = Screen.width / 16;
        //scrH - 9
        float scrH = Screen.height / 9;

        for (int x = 0; x < 16; x++)

        //GUI Box on screen for the healthbar background
        GUI.Box(new Rect(6 * scrW, 0.25f * scrH, 4 * scrW, 0.5f * scrH), "");
        //GUI Box for current health that moves in same place as the background bar
        GUI.Box(new Rect(6*scrW, 0.25f * scrH, curHealth*(4 * scrW)/maxHealth, 0.5f * scrH), "");
        //current Health divided by the posistion on screen and timesed by the total max health
        GUI.Box(new Rect(6 * scrW, 0.25f * scrH, curHealth*(4 * scrW)/maxHealth,0.5f * scrH), "", healthBar);
        //GUI Box on screen for the experience background
        //GUI Box for current experience that moves in same place as the background bar
        //current experience divided by the posistion on screen and timesed by the total max experience
        GUI.Box(new Rect(6 * scrW, 0.75f * scrH, curExp * (4 * scrW) / maxExp, 0.25f * scrH), "");
        //GUI Draw Texture on the screen that has the mini map render texture attached    
    }

    #endregion
}










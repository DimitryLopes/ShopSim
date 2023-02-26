using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager
{
    private ScreenDatabase screenDatabase;
    private EventSystem eventSystem;

    public UIManager(ScreenDatabase database, EventSystem eventSystem)
    {
        screenDatabase = database;
        this.eventSystem = eventSystem;
        screenDatabase.CreateDictionary();
    }

    public IUIScreen GetScreen(ScreenType type)
    {
        return screenDatabase.Screens[type];
    }

    public void AllowClick(bool value)
    {
        eventSystem.enabled = value;
    }
}

[Serializable]
public struct ScreenDatabase
{
    [SerializeField]
    private List<IUIScreen> screens;
    [SerializeField]
    private List<ScreenType> types;

    public Dictionary<ScreenType, IUIScreen> Screens;

    public void CreateDictionary()
    {
        Screens = new Dictionary<ScreenType, IUIScreen>();
        for(int i = 0; i < screens.Count; i++)
        {
            Screens.Add(types[i], screens[i]);
        }
    }
}


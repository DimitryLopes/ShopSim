using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class UIManager
{
    private ScreenDatabase screenDatabase;
    private EventSystem eventSystem;
    private UIScreen currentOpenedScreen;

    public UIScreen CurrentOpenedScreen => currentOpenedScreen;

    public UIManager(ScreenDatabase database, SignalBus signalBus, EventSystem eventSystem)
    {
        screenDatabase = database;
        this.eventSystem = eventSystem;
        screenDatabase.CreateDictionary();
        signalBus.Subscribe<OnScreenOpenedSignal>(OnScreenOpened);
        signalBus.Subscribe<OnScreenClosedSignal>(OnScreenClosed);
        currentOpenedScreen = screenDatabase.Screens[ScreenType.MainMenuScreen];
    }

    public UIScreen GetScreen(ScreenType type)
    {
        return screenDatabase.Screens[type];
    }

    public void AllowClick(bool value = true)
    {
        eventSystem.enabled = value;
    }

    public void OnScreenOpened(OnScreenOpenedSignal signal)
    {
        if(currentOpenedScreen != null)
        {
            currentOpenedScreen.Hide();
        }
        currentOpenedScreen = signal.Screen;
    }

    public void OnScreenClosed(OnScreenClosedSignal signal)
    {
        currentOpenedScreen = null;
    }
}

[Serializable]
public struct ScreenDatabase
{
    [SerializeField]
    private List<UIScreen> screens;
    [SerializeField]
    private List<ScreenType> types;

    public Dictionary<ScreenType, UIScreen> Screens;

    public void CreateDictionary()
    {
        Screens = new Dictionary<ScreenType, UIScreen>();
        for(int i = 0; i < screens.Count; i++)
        {
            Screens.Add(types[i], screens[i]);
        }
    }
}


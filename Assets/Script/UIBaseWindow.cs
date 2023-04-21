using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBaseWindow : Observer
{

    private void Awake()
    {
        //注册观察者
        ObserverManaager.RegisterObserver(this);
        //注册观察者消息通知
        ObserverManaager.RegisterNotification(this);

        _AwakeImpl();
    }
    private void OnEnable()
    {

        _EnableImpl();
    }
    private void Start()
    {
        _StartImpl();
    }

    private void Update()
    {
        _UpdateImpl();
    }
    private void OnDisable()
    {
        _DisableImpl();
    }

    private void OnDestroy()
    {
        //撤消观察者
        ObserverManaager.UnregiserObserver(this);
        //撤消观察者消息通知
        ObserverManaager.UnregiserNotification(this);
        _DestroyImpl();
    }

    protected virtual void _AwakeImpl()
    {

    }

    protected virtual void _EnableImpl()
    {
    }

    protected virtual void _StartImpl()
    {

    }

    protected virtual void _UpdateImpl()
    {
    }

    protected virtual void _DisableImpl()
    {
    }

    protected virtual void _DestroyImpl()
    {
    }

}
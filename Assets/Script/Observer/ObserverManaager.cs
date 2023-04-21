using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 消息控制类
/// </summary>
public class ObserverManaager{

    //观察者本地池
    private static Dictionary<string, List<Observer>> _observerDict = new Dictionary<string, List<Observer>>();
    //观察者通知池 
    private static Dictionary<string, List<Observer>> _notifierDict = new Dictionary<string, List<Observer>>();


    /// <summary>
    /// 注册观察者本体
    /// </summary>
    /// <param name="obs_"></param>
    public static void RegisterObserver(Observer obs_)
    {
        string name = obs_.GetName();
        if (string.IsNullOrEmpty(name))
        {
            return;
        }
        List<Observer> obsList = null;
        if (_observerDict.ContainsKey(name))
        {
            obsList = _observerDict[name];
        }
        else
        {
            obsList = new List<Observer>();
            _observerDict.Add(name, obsList);
        }

        obsList.Add(obs_);
    }


    /// <summary>
    /// 撤消观察者
    /// </summary>
    /// <param name="obs_"></param>
    public static void UnregiserObserver(Observer obs_)
    {
        string name = obs_.GetName();
        if (string.IsNullOrEmpty(name))
        {
            return;
        }

        List<Observer> obsList = new List<Observer>();
        if (_observerDict.ContainsKey(name))
        {
            obsList = _observerDict[name];
        }
        else
        {
            obsList = new List<Observer>();
            _observerDict.Add(name, obsList);
        }

        obsList.Remove(obs_);

        if (obsList.Count == 0)
        {
            _observerDict.Remove(name);
        }
    }

    /// <summary>
    /// 注册观察者消息通知
    /// </summary>
    /// <param name="obs_"></param>
    public static void RegisterNotification(Observer obs_)
    {
        string[] obsNote = obs_.GetNote();
        if (obsNote != null)
        {
            for (int i = 0; i < obsNote.Length; ++i)
            {
                List<Observer> obsList = null;
                if (_notifierDict.ContainsKey(obsNote[i]))
                {
                    obsList = _notifierDict[obsNote[i]];
                }
                else
                {
                    obsList = new List<Observer>();
                    _notifierDict.Add(obsNote[i], obsList);
                }

                obsList.Add(obs_);
            }
        }
    }

    /// <summary>
    /// 撤消观察者消息通知
    /// </summary>
    /// <param name="obs_"></param>
    public static void UnregiserNotification(Observer obs_)
    {
        string[] obsNote = obs_.GetNote();
        if (obsNote != null)
        {
            for (int i = 0; i < obsNote.Length; ++i)
            {
                if (_notifierDict.ContainsKey(obsNote[i]))
                {
                    List<Observer> obsList = _notifierDict[obsNote[i]];
                    obsList.Remove(obs_);
                    if (obsList.Count == 0)
                    {
                        _notifierDict.Remove(obsNote[i]);
                    }
                }
               
            }
        }
    }


    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="name_">观察者名字</param>
    /// <param name="note_">消息id</param>
    /// <param name="data_">消息数据</param>
    public static void SendNotification(string name_, string note_, EventParm data_)
    {
        if (_observerDict.ContainsKey(name_))
        {
            List<Observer> obsList = _observerDict[name_];
            for (int i = 0; i < obsList.Count; ++i)
            {
                if (obsList[i].enabled)
                {
                    obsList[i].OnNotification(note_, data_);
                }
            }
        }
    }

    /// <summary>
    /// 广播消息
    /// </summary>
    /// <param name="note_">消息id</param>
    /// <param name="data_">消息数据</param>
    public static void PostNotifcation(string note_, EventParm data_)
    {
        if (_notifierDict.ContainsKey(note_))
        {
            List<Observer> obsList = _notifierDict[note_];
            for (int i = 0; i < obsList.Count; ++i)
            {
                if (obsList[i].enabled)
                {
                    obsList[i].OnNotification(note_, data_);
                }
            }
        }
    }

}

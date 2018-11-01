using System.Collections;
using System.Collections.Generic;
using Streetball;
using UnityEngine;
using UnityEngine.UI;

public class Observer_Test : UIBaseWindow
{
    private Text send_Text, post_text;

    protected override void _AwakeImpl()
    {
        base._AwakeImpl();
        send_Text = this.transform.Find("SendNotification/Text").GetComponent<Text>();
        post_text = this.transform.Find("PostNotifcation/Text").GetComponent<Text>();
    }
    protected override void _StartImpl()
    {
        base._StartImpl();
    }

    public override string GetName()
    {
        return "observer_test";
    }

    public override string[] GetNote()
    {
        return new string[]
        {
            NoteConstant.POST_TEST,NoteConstant.SEND_TEST
        };
    }

    public override void OnNotification(string note_, EventParm data_)
    {
        switch (note_)
        {
            case NoteConstant.POST_TEST:
                {
                    if (data_.IsExist("postNotification"))
                    {
                        post_text.text = (string)data_["postNotification"];
                    }

                    break;
                }
            case NoteConstant.SEND_TEST:
                {
                    if (data_.IsExist("sendNotification"))
                    {
                        send_Text.text = (string)data_["sendNotification"];
                    }

                    break;
                }
            default:
                break;
        }
    }
}

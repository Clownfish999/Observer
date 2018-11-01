using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Demo_Test : UIBaseWindow {


    public void OnClickSendNotificationBtn()
    {
        SendNotification("observer_test", "Send_test", new Streetball.EventParm("sendNotification","发送消息"));
    }

    public void OnClickPostNotificationBtn()
    {
        PostNotification("post_test", new Streetball.EventParm("postNotification", "广播消息"));
    }


}

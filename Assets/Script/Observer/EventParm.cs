using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    /// <summary>
    ///  事件消息参数
    /// </summary>
    public class EventParm
    {

        /// <summary>
        /// 参数索引，存入事件消息参数
        /// </summary>
        private Dictionary<string, object> _argsDict = new Dictionary<string, object>();

        /// <summary>
        /// 构造函数
        /// 这里因为传入进来的参数都会转为  object  所以用的时候传的什么类型的参数，要转成什么类型才行
        /// </summary>
        /// <param name="args_"></param>
        public EventParm(params object[] args_)
        {
            for (int i = 1; i < args_.Length; ++i)  
            {
                _argsDict.Add((string) args_[i - 1], args_[i]);            //构造的时候因为传的是一个list，这里把里面的数据遍历出来，第一个为key，第二个值的格式存入到字典里面
            }
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="key_"></param>
        /// <returns></returns>
        public bool IsExist(string key_)
        {

            return _argsDict.ContainsKey(key_);
        }


        /// <summary>
        /// 清除事件参数
        /// </summary>
        public void Clear()
        {
            _argsDict.Clear();
        }


        /// <summary>
        /// 索引参数，如果有就传出参数，没有传出空
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object this[string key]
        {
            get { return _argsDict.ContainsKey(key) ? _argsDict[key] : null; }
        }

    }


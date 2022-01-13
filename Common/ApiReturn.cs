using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ApiReturn
    {
        [JsonProperty("code")]
        public int Code { get; private set; }
        [JsonProperty("msg")]
        public string Msg { get; private set; }
        [JsonProperty("success")]
        public bool Success { get; private set; }
        [JsonProperty("data")]
        public object Data { get; private set; }

        public ApiReturn()
        {

        }

        public ApiReturn(bool success,int code,string msg)
        {
            this.Success = success;
            this.Code = code;
            this.Msg = msg;
        }

        public ApiReturn SetMsg(string msg)
        {
            this.Msg = msg;
            return this;
        }
        public ApiReturn SetCode(int code)
        {
            this.Code = code;
            return this;
        }
        public ApiReturn SetData(object data)
        {
            this.Data = data;
            return this;
        }

        public ApiReturn SetDatas(params object[] data)
        {
            if ((data.Length & 1) == 1)
            {
                throw new ArgumentException("参数错误，参数个数必须是2的倍数");
            }
            Hashtable ht = new Hashtable();
            for (int i = 0; i < data.Length; i+=2)
            {
                ht[data[i]] = data[i + 1];
            }
            this.Data = ht;
            return this;
        }

        public static ApiReturn Succeed
        {
            get
            {
                return new ApiReturn(true, ReturnCode.Success, "操作成功");
            }
        }
        public static ApiReturn Failed
        {
            get
            {
                return new ApiReturn(false, ReturnCode.Failed, "操作失败");
            }
        }
        public static ApiReturn NoPermision
        {
            get
            {
                return new ApiReturn(false, ReturnCode.NoPermision, "无权限");
            }
        }        
        public static ApiReturn NoLogin
        {
            get
            {
                return new ApiReturn(false, ReturnCode.NoPermision, "未登录");
            }
        }
        public static ApiReturn NoRecord
        {
            get
            {
                return new ApiReturn(false, ReturnCode.NoPermision, "无记录");
            }
        }
        public static ApiReturn NoRecordOrNoPermision
        {
            get
            {
                return new ApiReturn(false, ReturnCode.NoPermision, "无权限或无记录");
            }
        }
        public static ApiReturn NoReason
        {
            get
            {
                return new ApiReturn(false, ReturnCode.NoReason, " 未知");
            }
        }
        public static ApiReturn ParamaError
        {
            get
            {
                return new ApiReturn(false, ReturnCode.ParamaError, " 参数错误");
            }
        }
    }

    public class ReturnCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        public const int Success = 0;
        /// <summary>
        /// 失败
        /// </summary>
        public const int Failed = 99;
        /// <summary>
        /// 无权限
        /// </summary>
        public const int NoPermision = 98;
        /// <summary>
        /// 未登录
        /// </summary>
        public const int NoLogin = 97;
        /// <summary>
        /// 无记录
        /// </summary>
        public const int NoRecord = 96;
        /// <summary>
        /// 无权限或无记录
        /// </summary>
        public const int NoRecordOrNoPermision = 95;
        /// <summary>
        /// 未知异常
        /// </summary>
        public const int NoReason = 94;
        /// <summary>
        /// 参数错误
        /// </summary>
        public const int ParamaError = 93;
    }
}

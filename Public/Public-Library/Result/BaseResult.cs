namespace Public.Result
{
    public class BaseResult
    {
        //执行结果是成功还是失败
        public BaseResult()
        {
            State = false;
            Value = 0;
            Info = "";
            Desc = "方法未完成";
        }

        // 设置执行结果为成功对应的值
        public void Success()
        {
            State = true;
            Value = 1;
            Info = "";
            Desc = "方法执行成功";            
        }

        // 设置失败
        public void Failed(int value,string desc,string info="")
        {
            State = false;
            Value = value;
            Desc = desc;
            Info = info;
        }

        public bool State { set; get; }

        //执行失败时的失败原因值
        public int Value { set; get; }

        //执行失败时的失败原因说明
        public string Desc { set; get; }

        /// <summary>
        ///     返回界面错误提示信息
        /// </summary>
        public string Info { set; get; }
    }
}

namespace SMS.Model.Addr
{
    public class ContactWay
    {
        /// <summary>
        /// 联系方式ID
        /// </summary>
        public int ContactWayID { get; set; }
        /// <summary>
        /// 联系方式类型
        /// 1 手机 2 固话 3 邮箱
        /// </summary>
        public int ContactWayType { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string Way { get; set; }
    }
}

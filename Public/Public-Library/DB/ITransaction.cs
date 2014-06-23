

namespace Public.DB
{
   public interface ITransaction
    {
        /// <summary>
        /// 开始事务处理
        /// </summary>
        void BeginTrans();

        /// <summary>
        /// 提交事务处理
        /// </summary>
        void CommitTrans();

        /// <summary>
        /// 回滚事务处理
        /// </summary>
        void RollbackTrans();

        /// <summary>
        /// 获取在同一个事务处理中的连接
        /// </summary>
        IDatabase DataAccess { get; }
    }
}

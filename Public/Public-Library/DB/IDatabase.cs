////==========================================================================
////类名:DBUtility\IDatabase.cs
////
////功能描述：数据库访问接口
////历史记录：
//// NO        日期          版本       姓名            内容
////--------------------------------------------------------------------------
//// 1         2013-03-05    V2.0      刘鹏程           
////==========================================================================

using System.Data;
using System.Data.SqlClient;

namespace Public.DB
{
    public interface IDatabase
    {
        /// <summary>
        /// 执行SQL
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <returns></returns>
        int ExecuteSql(string strSql);

        /// <summary>
        /// todo
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="prams"></param>
        /// <returns></returns>
        int ExecuteSql(string strSql, SqlParameter[] prams);

        /// <summary>
        /// todo
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="prams"></param>
        /// <param name="dataReader"></param>
        void ExecuteSql(string strSql, SqlParameter[] prams, out SqlDataReader dataReader);

        /// <summary>
        /// 执行SQL
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <returns></returns>
        object ExecuteObjSql(string strSql);

        /// <summary>
        /// todo
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="prams"></param>
        /// <returns></returns>
        object ExecuteObjSql(string strSql, SqlParameter[] prams);

        /// <summary>
        /// 执行SQL
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <returns>dt</returns>
        DataTable ExecuteTableSql(string strSql);

        /// <summary>
        /// 执行SQL
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <param name="prams"></param>
        /// <returns>dt</returns>
        DataTable ExecuteTableSql(string strSql, SqlParameter[] prams);

        /// <summary>
        /// 执行SQL
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <returns>ds</returns>
        DataSet ExecuteDataSetSql(string strSql);

        /// <summary>
        /// todo
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="prams"></param>
        /// <returns></returns>
        DataSet ExecuteDataSetSql(string strSql, SqlParameter[] prams);

        /// <summary>
        /// todo
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        DataTable ExecutePageSql(string strSql, int pageSize, int pageIndex, out int rows);

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="prams">存储过程所需参数</param>
        /// <param name="result"></param>
        /// <returns>返回存储过程restultValue值</returns>
        void ExecuteProc(string procName, SqlParameter[] prams, out int result);

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程的名称</param>
        /// <param name="dataReader">返回存储过程返回值</param>
        void ExecuteProc(string procName, out SqlDataReader dataReader);

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程的名称</param>
        /// <param name="prams">存储过程所需参数</param>
        /// <param name="dataReader">返回存储过程返回值</param>
        void ExecuteProc(string procName, SqlParameter[] prams, out SqlDataReader dataReader);

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程的名称</param>
        /// <param name="prams">存储过程所需参数</param>
        /// <param name="ds">返回存储过程返回值</param>
        void ExecuteProc(string procName, SqlParameter[] prams, out DataSet ds);

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程的名称</param>
        /// <param name="ds">返回存储过程返回值</param>
        void ExecuteProc(string procName, out DataSet ds);

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程的名称</param>
        /// <param name="dt">返回存储过程返回值</param>
        void ExecuteProc(string procName, out DataTable dt);

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程的名称</param>
        /// <param name="prams">存储过程所需参数</param>
        /// <param name="dt">返回存储过程返回值</param>
        void ExecuteProc(string procName, SqlParameter[] prams, out DataTable dt);

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程的名称</param>
        /// <param name="prams">存储过程所需参数</param>
        /// <returns>返回存储过程返回值</returns>
        object ExecuteProc(string procName, SqlParameter[] prams);

        /// <summary>
        /// 创建一个SqlCommand对象以此来执行存储过程
        /// </summary>
        /// <param name="commandType">命令类型 是执行存储过程 还是SQl语句</param>
        /// <param name="commandText">文本</param>
        /// <param name="prams">存储过程所需参数</param>
        /// <returns>返回SqlCommand对象</returns>
        SqlCommand CreateCommand(CommandType commandType, string commandText, SqlParameter[] prams);

        /// <summary>
        /// 创建一个SqlCommand对象以此来执行存储过程
        /// </summary>
        /// <param name="commandText"> 文本 </param>
        /// <returns>返回SqlCommand对象</returns>
        SqlCommand CreateCommand(string commandText);
    }
}
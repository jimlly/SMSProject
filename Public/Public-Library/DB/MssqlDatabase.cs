

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Public.DB
{
    public class MssqlDatabase : IDatabase, ITransaction
    {
        private readonly SqlCommand _cmd;
        private SqlConnection _con;
        private SqlTransaction _trans;

        public MssqlDatabase(string connectionString)
        {
            _con = new SqlConnection(connectionString);
            _cmd = new SqlCommand {Connection = _con};
        }

        public MssqlDatabase(DBSource dbsrc)
        {
            string connectionString;
            switch (dbsrc)
            {
                case DBSource.DBYtNetCC:
                    connectionString = GetConnectString("CenterDBNetCC");
                    break;
                case DBSource.DBYtConf:
                    connectionString = GetConnectString("CenterDBConf");
                    break;
                case DBSource.DBYuantel:
                    connectionString = GetConnectString("CenterDBYuantel");
                    break;
                case DBSource.DBYtFax:
                    connectionString = GetConnectString("CenterDBFax");
                    break;
                case DBSource.DBYtSms:
                    connectionString = GetConnectString("CenterDBSms");
                    break;
                case DBSource.DBYtSys:
                    connectionString = GetConnectString("CenterDBSys");
                    break;
                case DBSource.DBYtAddressBook:
                    connectionString = GetConnectString("CenterDBAddr");
                    break;
                case DBSource.DBYtMail:
                    connectionString = GetConnectString("CenterDBMail");
                    break;
                default:
                    connectionString = "";
                    break;
            }
            _con = new SqlConnection(connectionString);
            _cmd = new SqlCommand {Connection = _con};
        }

        /// <summary>
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public int ExecuteSql(string strSql)
        {
            var cmd = CreateCommand(CommandType.Text, strSql, null);
            int result = cmd.ExecuteNonQuery();

            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="prams"></param>
        /// <returns></returns>
        public int ExecuteSql(string strSql, SqlParameter[] prams)
        {
            SqlCommand cmd = CreateCommand(CommandType.Text, strSql, prams);
            int result = cmd.ExecuteNonQuery();

            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="prams"></param>
        /// <param name="dataReader"></param>
        public void ExecuteSql(string strSql, SqlParameter[] prams, out SqlDataReader dataReader)
        {
            var cmd = CreateCommand(CommandType.Text, strSql, prams);
            dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        /// <summary>
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public object ExecuteObjSql(string strSql)
        {
            var cmd = CreateCommand(CommandType.Text, strSql, null);
            object obj = cmd.ExecuteScalar();

            return obj;
        }

        /// <summary>
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="prams"></param>
        /// <returns></returns>
        public object ExecuteObjSql(string strSql, SqlParameter[] prams)
        {
            var cmd = CreateCommand(CommandType.Text, strSql, prams);
            object obj = cmd.ExecuteScalar();

            return obj;
        }

        /// <summary>
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public DataTable ExecuteTableSql(string strSql)
        {
            var dap = new SqlDataAdapter {SelectCommand = CreateCommand(strSql)};

            var dt = new DataTable();
            dap.Fill(dt);
            return dt;
        }

        /// <summary>
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="prams"></param>
        /// <returns></returns>
        public DataTable ExecuteTableSql(string strSql, SqlParameter[] prams)
        {
            var dap = new SqlDataAdapter {SelectCommand = CreateCommand(CommandType.Text, strSql, prams)};

            var dt = new DataTable();
            dap.Fill(dt);
            return dt;
        }

        /// <summary>
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public DataSet ExecuteDataSetSql(string strSql)
        {
            var dap = new SqlDataAdapter {SelectCommand = CreateCommand(strSql)};

            var ds = new DataSet();
            dap.Fill(ds);
            return ds;
        }

        /// <summary>
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="prams"></param>
        /// <returns></returns>
        public DataSet ExecuteDataSetSql(string strSql, SqlParameter[] prams)
        {
            var dap = new SqlDataAdapter {SelectCommand = CreateCommand(CommandType.Text, strSql, prams)};

            var ds = new DataSet();
            dap.Fill(ds);
            return ds;
        }

        /// <summary>
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public DataTable ExecutePageSql(string strSql, int pageSize, int pageIndex, out int rows)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="prams"></param>
        /// <param name="result"></param>
        public void ExecuteProc(string procName, SqlParameter[] prams, out int result)
        {
            var cmd = CreateCommand(procName, prams);
            cmd.ExecuteNonQuery();

            if (cmd.Parameters["ReturnValue"] != null)
            {
                result = (int) cmd.Parameters["ReturnValue"].Value;
            }
            else
            {
                result = 0;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="dataReader"></param>
        public void ExecuteProc(string procName, out SqlDataReader dataReader)
        {
            var cmd = CreateCommand(procName, null);

            dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        /// <summary>
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="prams"></param>
        /// <param name="dataReader"></param>
        public void ExecuteProc(string procName, SqlParameter[] prams, out SqlDataReader dataReader)
        {
            var cmd = CreateCommand(procName, prams);
            dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        /// <summary>
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="prams"></param>
        /// <param name="ds"></param>
        public void ExecuteProc(string procName, SqlParameter[] prams, out DataSet ds)
        {
            using (var adpt = new SqlDataAdapter())
            {
                adpt.SelectCommand = CreateCommand(procName, prams);

                ds = new DataSet("DataSet");
                adpt.Fill(ds);
            }
            Close();
        }

        /// <summary>
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="ds"></param>
        public void ExecuteProc(string procName, out DataSet ds)
        {
            using (var adpt = new SqlDataAdapter())
            {
                adpt.SelectCommand = CreateCommand(procName, null);

                ds = new DataSet("DataSet");
                adpt.Fill(ds);
            }
            Close();
        }

        /// <summary>
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="dt"></param>
        public void ExecuteProc(string procName, out DataTable dt)
        {
            using (var adpt = new SqlDataAdapter())
            {
                adpt.SelectCommand = CreateCommand(procName, null);

                dt = new DataTable("DataTable");
                adpt.Fill(dt);
            }
            Close();
        }

        /// <summary>
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="prams"></param>
        /// <param name="dt"></param>
        public void ExecuteProc(string procName, SqlParameter[] prams, out DataTable dt)
        {
            using (var adpt = new SqlDataAdapter())
            {
                adpt.SelectCommand = CreateCommand(procName, prams);

                dt = new DataTable("DataTable");
                // Adpt.Fill(ds, "Table");
                adpt.Fill(dt);
            }
            Close();
        }

        /// <summary>
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="prams"></param>
        /// <returns></returns>
        public object ExecuteProc(string procName, SqlParameter[] prams)
        {
            var cmd = CreateCommand(procName, prams);
            return cmd.ExecuteScalar();
        }

        /// <summary>
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public SqlCommand CreateCommand(CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {
            if (_con.State != ConnectionState.Open)
                _con.Open();
            _cmd.Connection = _con;
            _cmd.CommandType = cmdType;
            _cmd.CommandText = cmdText;

            _cmd.Transaction = _trans != null ? _trans : null;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    _cmd.Parameters.Add(parm);
            }
            // 加入返回参数
            _cmd.Parameters.Add(
                new SqlParameter("ReturnValue", SqlDbType.Int, 4,
                                 ParameterDirection.ReturnValue, false, 0, 0,
                                 string.Empty, DataRowVersion.Default, null));
            return _cmd;
        }

        /// <summary>
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public SqlCommand CreateCommand(string cmdText)
        {
            if (_con.State != ConnectionState.Open)
                _con.Open();
            _cmd.Connection = _con;
            _cmd.CommandType = CommandType.Text;
            _cmd.CommandText = cmdText;

            _cmd.Transaction = _trans != null ? _trans : null;


            return _cmd;
        }

        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConnectString(string key)
        {
            try
            {
                var cs = ConfigurationManager.ConnectionStrings[key];
                if (cs == null)
                {
                    return string.Empty;
                }

                return cs.ConnectionString == string.Empty ? string.Empty : cs.ConnectionString;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// </summary>
        ~MssqlDatabase()
        {
            Close();
        }

        /// <summary>
        ///     打开数据库连接.
        /// </summary>
        public void Open()
        {
            // 打开数据库连接
            if (_con == null)
            {
                _con =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString_ytSms"].ConnectionString);
            }
            if (_con.State == ConnectionState.Closed)
                _con.Open();
        }

        /// <summary>
        /// </summary>
        public void Close()
        {
            if (_con != null && _con.State != ConnectionState.Closed)
            {
                _con.Close();
            }
        }

        public void Dispose()
        {
            if(_con!=null)
            {
                _con.Close();
                _con = null;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="prams"></param>
        /// <param name="result"></param>
        public void ExecuteSql(string strSql, SqlParameter[] prams, out int result)
        {
            SqlCommand cmd = CreateCommand(CommandType.Text, strSql, prams);
            cmd.ExecuteNonQuery();

            if (cmd.Parameters["ReturnValue"] != null)
            {
                result = (int) cmd.Parameters["ReturnValue"].Value;
            }
            else
            {
                result = 0;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="prams"></param>
        /// <returns></returns>
        public SqlCommand CreateCommand(string procName, SqlParameter[] prams)
        {
            // 确认打开连接

            Open();

            _cmd.CommandText = procName;

            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.Clear();
            _cmd.Transaction = _trans != null ? _trans : null;

            // 依次把参数传入存储过程

            if (prams != null)
            {
                foreach (var parameter in prams)
                {
                    _cmd.Parameters.Add(parameter);
                }
            }

            // 加入返回参数
            _cmd.Parameters.Add(
                new SqlParameter("ReturnValue", SqlDbType.Int, 4,
                                 ParameterDirection.ReturnValue, false, 0, 0,
                                 string.Empty, DataRowVersion.Default, null));

            return _cmd;
        }

        /// <summary>
        ///     传入输入参数
        /// </summary>
        /// <param name="paramName">参数名称</param>
        /// <param name="dbType">参数类型</param>
        /// <param name="size">参数大小</param>
        /// <param name="value">参数值</param>
        /// <returns>新的 parameter 对象</returns>
        public SqlParameter MakeInParam(string paramName, SqlDbType dbType, int size, object value)
        {
            return MakeParam(paramName, dbType, size, ParameterDirection.Input, value);
        }

        /// <summary>
        ///     传入输入参数
        /// </summary>
        /// <param name="paramName">参数名称</param>
        /// <param name="dbType">参数类型</param>
        /// <param name="value">参数值</param>
        /// <returns>新的 parameter 对象</returns>
        public SqlParameter MakeInParam(string paramName, SqlDbType dbType, object value)
        {
            return MakeParam(paramName, dbType, ParameterDirection.Input, value);
        }

        /// <summary>
        ///     传入输入参数
        /// </summary>
        /// <param name="paramName">参数名称</param>
        /// <param name="dbType">参数类型</param>
        /// <param name="size">参数大小</param>
        /// <param name="value">参数值</param>
        /// <returns>新的 parameter 对象</returns>
        public SqlParameter MakeInOutParam(string paramName, SqlDbType dbType, int size, object value)
        {
            return MakeParam(paramName, dbType, size, ParameterDirection.InputOutput, value);
        }

        /// <summary>
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="dbType"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public SqlParameter MakeInOutParam(string paramName, SqlDbType dbType, object value)
        {
            return MakeParam(paramName, dbType, ParameterDirection.InputOutput, value);
        }

        /// <summary>
        ///     传入返回值参数
        /// </summary>
        /// <param name="paramName">参数名称</param>
        /// <param name="dbType">参数类型</param>
        /// <param name="size">参数大小</param>
        /// <returns>新的 parameter 对象</returns>
        public SqlParameter MakeOutParam(string paramName, SqlDbType dbType, int size)
        {
            return MakeParam(paramName, dbType, size, ParameterDirection.Output, null);
        }

        /// <summary>
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="dbType"></param>
        /// <returns></returns>
        public SqlParameter MakeOutParam(string paramName, SqlDbType dbType)
        {
            return MakeParam(paramName, dbType, ParameterDirection.Output, null);
        }

        /// <summary>
        ///     传入返回值参数
        /// </summary>
        /// <param name="paramName">参数名称</param>
        /// <param name="dbType">参数类型</param>
        /// <param name="size">参数大小</param>
        /// <returns>新的 parameter 对象</returns>
        public SqlParameter MakeReturnParam(string paramName, SqlDbType dbType, int size)
        {
            return MakeParam(paramName, dbType, size, ParameterDirection.ReturnValue, null);
        }

        /// <summary>
        ///     生成存储过程参数
        /// </summary>
        /// <param name="paramName">参数名称</param>
        /// <param name="dbType">参数类型</param>
        /// <param name="direction">参数方向</param>
        /// <param name="value">参数值</param>
        /// <returns>新的 parameter 对象</returns>
        public static SqlParameter MakeParam(string paramName, SqlDbType dbType, ParameterDirection direction,
                                             object value)
        {
            var param = new SqlParameter(paramName, dbType) { Direction = direction };

            if (!(direction == ParameterDirection.Output && value == null))
                param.Value = value;

            return param;
        }

        /// <summary>
        ///     生成存储过程参数
        /// </summary>
        /// <param name="paramName">参数名称</param>
        /// <param name="dbType">参数类型</param>
        /// <param name="size">参数大小</param>
        /// <param name="direction">参数方向</param>
        /// <param name="value">参数值</param>
        /// <returns>新的 parameter 对象</returns>
        public static SqlParameter MakeParam(string paramName, SqlDbType dbType, Int32 size,
                                             ParameterDirection direction, object value)
        {
            var param = size > 0 ? new SqlParameter(paramName, dbType, size) : new SqlParameter(paramName, dbType);

            param.Direction = direction;
            if (!(direction == ParameterDirection.Output && value == null))
                param.Value = value;

            return param;
        }

        #region 事务处理

        /// <summary>
        /// </summary>
        public void BeginTrans()
        {
            if (_con.State != ConnectionState.Open)
            {
                _con.Open();
            }
            if (_trans == null)
            {
                _trans = _con.BeginTransaction();
            }
            else
            {
                throw new Exception("事务已经开始,无法在同一连接上再次启动事务！");
            }
        }

        /// <summary>
        /// </summary>
        public void CommitTrans()
        {
            if (_trans == null)
            {
                throw new Exception("事务尚未开始,没有可用的事务用于提交！");
            }
            _trans.Commit();
            _trans = null;
        }

        //事务尚未开始,没有可用的事务用于回滚！
        /// <summary>
        /// </summary>
        public void RollbackTrans()
        {
            if (_trans == null)
            {
                throw new Exception("事务尚未开始,没有可用的事务用于回滚！");
            }
            _trans.Rollback();
            _trans = null;
        }

        /// <summary>
        /// </summary>
        public IDatabase DataAccess
        {
            get { return this; }
        }

        #endregion
    }
}
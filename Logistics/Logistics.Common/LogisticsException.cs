using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logistics_Model;
using Akmii;

namespace Logistics.Common
{
    [Serializable]
    public class LogisticsException : Exception
    {
        public SystemStatusEnum Status { get; set; } = SystemStatusEnum.ServerError;

        public LogisticsException(string message) : base(message)
        {
        }

        public LogisticsException(Exception innerException, string message) : base(message, innerException)
        {

        }

        public LogisticsException(string formatMessage, params object[] param) : this(string.Format(formatMessage, param))
        {

        }

        public LogisticsException(Exception innerException, string formatMessage, params object[] param) : this(innerException, string.Format(formatMessage, param))
        {

        }

        public LogisticsException(SystemStatusEnum status) : base(status.GetEnumDescription())
        {
            this.Status = status;
        }

        public LogisticsException(SystemStatusEnum status, string message) : base(message)
        {
            this.Status = status;
        }

        public LogisticsException(SystemStatusEnum status, Exception innerException, string message) : base(message, innerException)
        {
            this.Status = status;
        }

        public LogisticsException(SystemStatusEnum status, string formatMessage, params object[] param) : this(string.Format(formatMessage, param))
        {
            this.Status = status;
        }

        public LogisticsException(SystemStatusEnum status, Exception innerException, string formatMessage, params object[] param) : this(innerException, string.Format(formatMessage, param))
        {
            this.Status = status;
        }
    }
}

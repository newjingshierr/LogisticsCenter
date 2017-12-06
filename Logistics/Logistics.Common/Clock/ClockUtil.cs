using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Common
{
    public class ClockUtil
    {
        private TimeZoneInfo _timeZoneInfo;
        private bool isUTC;
        private bool isLocal;

        public ClockUtil(TimeZoneInfo timeZoneInfo)
        {
            if (timeZoneInfo == null)
            {
                _timeZoneInfo = TimeZoneInfo.Utc;
            }

            _timeZoneInfo = timeZoneInfo;
            isUTC = _timeZoneInfo == TimeZoneInfo.Utc;
            isLocal = _timeZoneInfo == TimeZoneInfo.Local;
        }

        public ClockUtil(string timeZoneId) : this(timeZoneId == null ? null : TimeZoneInfo.FindSystemTimeZoneById(timeZoneId))
        {
        }

        /// <summary>
        /// 根据系统初始化的时区获取当前时间
        /// </summary>
        public DateTime Now
        {
            get
            {
                return isUTC ? DateTime.UtcNow : (isLocal ? DateTime.Now : TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, _timeZoneInfo));
            }
        }
    }
}

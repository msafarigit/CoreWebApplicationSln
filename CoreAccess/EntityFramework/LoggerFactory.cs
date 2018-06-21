using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.EventLog;
using Microsoft.EntityFrameworkCore;

namespace CoreAccess.EntityFramework
{
    public partial class EntityContext
    {
        public static readonly LoggerFactory ConsoleLoggerFactory = new LoggerFactory(new[] { new ConsoleLoggerProvider((_, __) => true, true) });

        public static readonly LoggerFactory ConsoleCommandLoggerFactory = new LoggerFactory(new[] { new ConsoleLoggerProvider((category, level) => category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information, true) });

        public static readonly LoggerFactory EventLoggerFactory = new LoggerFactory(new[] { new EventLogLoggerProvider(new EventLogSettings { SourceName = "CoreFramework", LogName = "Application", Filter = (category, level) => true }) });

        public static readonly LoggerFactory EventCommandLoggerFactory = new LoggerFactory(new[] { new EventLogLoggerProvider(new EventLogSettings { SourceName = "CoreFramework", LogName = "Application", Filter = (category, level) => category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information }) });
    }
}

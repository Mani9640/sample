using System;


namespace LoggingLibrary
{
  public interface ILogger
  {
    void LogMessage(string componentName, string action, TimeSpan timeSpan, string message);
  }
}

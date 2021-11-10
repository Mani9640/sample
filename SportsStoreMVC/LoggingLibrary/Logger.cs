using System;

using System.Diagnostics;


namespace LoggingLibrary
{
  public class Logger : ILogger
  {
    public void LogMessage(string componentName, string action, TimeSpan timeSpan, string message)
    {
      string str = $"-----------------------------------------------------" + $"\n\tComponentName:{componentName},Action:{action},TimeSpan:{timeSpan} and Message:{message}\n" + "---------------------------";
      Debug.WriteLine(str);
      Trace.WriteLine(str);
    }
  }
}

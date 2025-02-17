﻿using StatisticsAnalysisTool.Common;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Threading;

namespace StatisticsAnalysisTool;

public partial class App
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        _ = ServiceRegistration.RegisterServices();
    }

    // Fixes a issue in the WPF clipboard handler.
    // It is necessary to handle the unhandled exception in the Application.DispatcherUnhandledException event.
    private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        if (e.Exception is COMException { ErrorCode: -2147221040 })
        {
            e.Handled = true;
        }
    }
}
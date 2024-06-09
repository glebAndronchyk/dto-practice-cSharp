using System;
using System.ComponentModel;
using System.Windows;

namespace lb4.abstractions;

public class WindowHelper
{
    public static void OnWindowClose(CancelEventArgs e, Action callback)
    {
        MessageBoxResult result = MessageBox.Show(
            "You have unsaved changes, do you want to quit without saving?", 
            "Warning!", 
            MessageBoxButton.YesNo, 
            MessageBoxImage.Warning);
        
        if (result == MessageBoxResult.No)
        {
            e.Cancel = true;
        }
        else
        {
            callback();
        }
    }
}
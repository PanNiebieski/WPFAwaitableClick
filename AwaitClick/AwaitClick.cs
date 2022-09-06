using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AwaitClick
{
public static class  StaticExtensionAwaitClick
{
    public static Task WhenClicked(this Button btn)
    {
        var tcs = new TaskCompletionSource<object>();
        RoutedEventHandler lambda = null;

        lambda = (s, e) =>
        {
            btn.Click -= lambda;
            tcs.SetResult(null);
        };

        btn.Click += lambda;
        return tcs.Task;
    }

public static Task WhenClicked(this Button btn,Action action)
{
    var tcs = new TaskCompletionSource<object>();
    RoutedEventHandler lambda = null;

    lambda = (s, e) =>
    {

        action.Invoke();
        tcs.SetResult(null);
    };

    btn.Click += lambda;
    return tcs.Task;
}
}
}

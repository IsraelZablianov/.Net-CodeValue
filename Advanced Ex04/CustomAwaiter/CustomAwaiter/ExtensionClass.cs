using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CustomAwaiter
{
    public static class ExtensionClass
    {
        public static TaskAwaiter GetAwaiter(this int delay)
        {
            return Task.Delay(delay).GetAwaiter();
        }

        public static TaskAwaiter GetAwaiter(this Process process)
        {
            return ProcessTaskAsync(process).GetAwaiter();
        }

        public static async Task ProcessTaskAsync(this Process process)
        {
            var tcs = new TaskCompletionSource<object>();
            EventHandler lambda = (s, e) =>
            {
                tcs.TrySetResult(null);
            };

            process.Exited += lambda;
            await tcs.Task;
            process.Exited -= lambda;
        }
    }
}

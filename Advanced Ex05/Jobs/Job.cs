using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Jobs
{
    static class NativeJob
    {
        [DllImport("kernel32")]
        public static extern IntPtr CreateJobObject(IntPtr sa, string name);

        [DllImport("kernel32", SetLastError = true)]
        public static extern bool AssignProcessToJobObject(IntPtr hjob, IntPtr hprocess);

        [DllImport("kernel32")]
        public static extern bool CloseHandle(IntPtr h);

        [DllImport("kernel32")]
        public static extern bool TerminateJobObject(IntPtr hjob, uint code);
    }

    public class Job : IDisposable
    {
        private IntPtr _hJob;
        private List<Process> _processes;
        private bool _disposed;
        private long __sizeOfNativeMemoryInMegaByte = 10 * 1000000;

        public Job(string name)
        {
            _hJob = NativeJob.CreateJobObject(IntPtr.Zero, name);
            if (_hJob == IntPtr.Zero)
            {
                throw new InvalidOperationException();
            }

            _processes = new List<Process>();
            GC.AddMemoryPressure(__sizeOfNativeMemoryInMegaByte);
            Console.WriteLine("Job was created");
        }

        ~Job()
        {
            Dispose(false);
        }

        public Job()
            : this(null)
        {
        }

        protected void AddProcessToJob(IntPtr hProcess)
        {
            IfDisposedThrowException();

            if (!NativeJob.AssignProcessToJobObject(_hJob, hProcess))
                throw new InvalidOperationException("Failed to add process to job");
        }

        public void AddProcessToJob(int pid)
        {
            IfDisposedThrowException();
            AddProcessToJob(Process.GetProcessById(pid));
        }

        public void AddProcessToJob(Process proc)
        {
            IfDisposedThrowException();

            Debug.Assert(proc != null);
            AddProcessToJob(proc.Handle);
            _processes.Add(proc);
        }

        public void Kill()
        {
            IfDisposedThrowException();
            var succeed = NativeJob.TerminateJobObject(_hJob, 0);

            if(!succeed)
            {
                throw new Exception("Job object is not succeed to terminate");
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                foreach (var prop in _processes)
                {
                    prop.Dispose();
                }
            }

            Marshal.FreeHGlobal(_hJob);
            GC.RemoveMemoryPressure(__sizeOfNativeMemoryInMegaByte);
            Console.WriteLine("Job disposed");
            _disposed = true;
        }

        private void IfDisposedThrowException()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(Job));
            }
        }
    }
}

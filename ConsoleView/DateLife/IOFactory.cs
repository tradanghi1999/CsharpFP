using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
namespace DateLife
{
    public class IOFactory
    {
        public  N Using<TDisp, N>(TDisp disposable, Func<TDisp, N> f) where TDisp : IDisposable
        {
            using (disposable) return f(disposable);
        }
        public void Using<TDisp>(TDisp disposable, Action<TDisp> f) where TDisp : IDisposable
        {
            using (disposable)  f(disposable);
        }
        public void WriteObjToFile<T>(T t, string fileName)
        => fileName.IF(
            File.Exists,
            (truE) => 
            {
                Debug.WriteLine("File Existed");
                Debug.WriteLine("Try Overwrite");
                TryWriteFile(t, fileName);
            },
            (falsE) =>
            {
                Debug.WriteLine("File Not Existed");
                TryWriteFile(t, fileName);
            });

        public void TryWriteFile<T>(T t,string fileName)
        => Using<StreamWriter>(
                new StreamWriter(fileName),
                (strW) =>
                {
                    ((Action<object>)strW.WriteLine).With(
                            ((Func<T, string>)ClassConverter.ToJson).With(t));
                    Debug.WriteLine("Successful WriteFile");
                }
            );
    }
}

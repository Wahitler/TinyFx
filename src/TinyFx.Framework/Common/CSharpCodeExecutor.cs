using System;
using Microsoft.CSharp;
using System.Collections.Specialized;
using System.CodeDom.Compiler;

namespace TinyFx
{
    /// <summary>
    /// C#代码动态编译执行
    /// </summary>
    public class CSharpCodeExecutor:IDisposable
    {
        private string _code;
        private CSharpCodeProvider _compiler;
        private CompilerParameters _parameters;

        /// <summary>
        /// 获取当前项目所引用的程序集。
        /// </summary>
        public StringCollection ReferencedAssemblies { get { return _parameters.ReferencedAssemblies; } }

        /// <summary>
        ///  构造函数
        /// </summary>
        /// <param name="code">动态代码</param>
        public CSharpCodeExecutor(string code)
        {
            _compiler = new CSharpCodeProvider();
            _parameters = new CompilerParameters();
            _parameters.ReferencedAssemblies.Add("System.dll");
            _parameters.ReferencedAssemblies.Add("System.Core.dll");
            _parameters.ReferencedAssemblies.Add("System.Data.dll");
            _parameters.GenerateExecutable = false;
            _parameters.GenerateInMemory = true;

            _code = code;
        }

        /// <summary>
        /// 执行动态代码中的方法
        /// </summary>
        /// <param name="typeName">类名</param>
        /// <param name="methodName">方法名</param>
        /// <param name="parameters">执行参数</param>
        /// <returns></returns>
        public object Execute(string typeName, string methodName, params object[] parameters)
        {
            object ret = null;

            CompilerResults cr = _compiler.CompileAssemblyFromSource(_parameters, _code);
            if (!cr.Errors.HasErrors)
            {
                var obj = cr.CompiledAssembly.CreateInstance(typeName);
                var method = obj.GetType().GetMethod(methodName);
                ret = method.Invoke(obj, parameters);
            }
            else
            {
                string errText = string.Empty;
                foreach (CompilerError err in cr.Errors)
                {
                    errText += err.ErrorText;
                }
                throw new Exception(errText);
            }

            return ret;
        }
        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            _compiler?.Dispose();
        }
    }
}

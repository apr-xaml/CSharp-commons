using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace nItCIT.nCommon.nExecution
{
    public class AsynchFunction<TResult> : AbstractExecutionUnit
    {

        Func<Task<TResult>> _oxExecute;


        public AsynchFunction(Func<Task<TResult>> oxExecute, Func<bool> oxCanExecute, string commandName)
            : base(commandName, oxCanExecute)
        {
            _oxExecute = oxExecute;
        }

        public async Task<TResult> ExecuteAsync()
        {
            this._ThrowIfDisabled(this.IsDisabled);

            try
            {
                this.IsExecuting = true;
                return await _oxExecute();
            }
            finally
            {

                this.IsExecuting = false;
            }


        }



    }




}

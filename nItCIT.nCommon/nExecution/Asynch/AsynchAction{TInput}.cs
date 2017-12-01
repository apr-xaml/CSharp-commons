using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace nItCIT.nCommon.nExecution
{
    public class AsynchAction<TInput> : AbstractExecutionUnit
    {

        Func<TInput, Task> _oxAction;


        public AsynchAction(Func<TInput, Task> oxExecute, Func<bool> oxCanExecute, string commandName)
            : base(commandName, oxCanExecute)
        {
            _oxAction = oxExecute;
        }

        public async Task ExecuteAsync(TInput arg)
        {
            this.IsExecuting = true;
            try
            {
                await _oxAction(arg);
            }
            finally
            {

                this.IsExecuting = false;
            }


        }


    }




}

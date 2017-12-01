using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace nItCIT.nCommon.nExecution
{
    public class AsynchAction : AbstractExecutionUnit
    {

        Func<Task> _oxAction;


        public AsynchAction(Func<Task> oxExecute, Func<bool> oxCanExecute, string commandName)
            : base(commandName, oxCanExecute)
        {
            _oxAction = oxExecute;
        }



        public async Task ExecuteAync()
        {
           this._ThrowIfDisabled(this.IsDisabled);

            try
            {
                this.IsExecuting = true;
                await _oxAction();
            }
            finally
            {
                this.IsExecuting = false;
            }


        }

    }




}
